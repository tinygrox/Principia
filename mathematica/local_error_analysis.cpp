
#include "mathematica/local_error_analysis.hpp"

#include <filesystem>
#include <vector>

#include "astronomy/stabilize_ksp.hpp"
#include "base/file.hpp"
#include "mathematica/mathematica.hpp"

namespace principia {
namespace mathematica {

using base::OFStream;
using base::make_not_null_unique;
using geometry::Position;
using physics::DegreesOfFreedom;
using physics::MassiveBody;
using quantities::Length;
using quantities::si::Day;
using quantities::si::Metre;
using quantities::si::Milli;
using quantities::si::Minute;

namespace {

constexpr Length fitting_tolerance = 1 * Milli(Metre);

}  // namespace

LocalErrorAnalyser::LocalErrorAnalyser(
    not_null<std::unique_ptr<SolarSystem<ICRS>>> solar_system,
    FixedStepSizeIntegrator<Ephemeris<ICRS>::NewtonianMotionEquation> const&
        integrator,
    Time const& step)
    : solar_system_(std::move(solar_system)),
      integrator_(integrator),
      step_(step) {
  // The system might not be defined from Keplerian elements, so we cannot
  // always turn it into a hierarchical system to take its fingerprint.
  // TODO(egg): arbitrary solar system fingerprinting.
  if (solar_system_->names()[0] == "Bop") {
    LOG(INFO) << "All hail retrobop!";
    astronomy::StabilizeKSP(*solar_system_);
  }
}

void LocalErrorAnalyser::WriteLocalErrors(
    std::filesystem::path const& path,
    FixedStepSizeIntegrator<Ephemeris<ICRS>::NewtonianMotionEquation> const&
        fine_integrator,
    Time const& fine_step,
    Time const& granularity,
    Time const& duration) const {
  auto const reference_ephemeris = solar_system_->MakeEphemeris(
      /*accuracy_parameters=*/{fitting_tolerance,
                               /*geopotential_tolerance=*/0x1p-24},
      Ephemeris<ICRS>::FixedStepParameters(integrator_, step_));
  reference_ephemeris->Prolong(solar_system_->epoch());
  std::vector<std::vector<Length>> errors;
  for (Instant t0 = solar_system_->epoch(),
               t = t0 + granularity;
       t < solar_system_->epoch() + duration;
       t0 = t, t += granularity) {
    std::unique_ptr<Ephemeris<ICRS>> refined_ephemeris =
        ForkEphemeris(*reference_ephemeris, t0, fine_integrator, fine_step);
    reference_ephemeris->Prolong(t);
    refined_ephemeris->Prolong(t);
    LOG_EVERY_N(INFO, 10) << "Prolonged to "
                          << (t - solar_system_->epoch()) / Day << " days.";

    errors.emplace_back();
    for (auto const& body_name : solar_system_->names()) {
      int const body_index = solar_system_->index(body_name);
      errors.back().push_back(
          (reference_ephemeris
               ->trajectory(reference_ephemeris->bodies()[body_index])
               ->EvaluatePosition(t) -
           refined_ephemeris
               ->trajectory(refined_ephemeris->bodies()[body_index])
               ->EvaluatePosition(t)).Norm());
    }
  }
  OFStream file(path);
  file << Assign("bodyNames", solar_system_->names());
  file << Assign("errors", errors, ExpressIn(Metre));
}

not_null<std::unique_ptr<Ephemeris<ICRS>>> LocalErrorAnalyser::ForkEphemeris(
    Ephemeris<ICRS> const& original,
    Instant const& t,
    FixedStepSizeIntegrator<Ephemeris<ICRS>::NewtonianMotionEquation> const&
        integrator,
    Time const& step) const {
  std::vector<DegreesOfFreedom<ICRS>> degrees_of_freedom;
  for (not_null<MassiveBody const*> const body : original.bodies()) {
    degrees_of_freedom.emplace_back(
        original.trajectory(body)->EvaluateDegreesOfFreedom(t));
  }
  return make_not_null_unique<Ephemeris<ICRS>>(
      solar_system_->MakeAllMassiveBodies(),
      degrees_of_freedom,
      t,
      Ephemeris<ICRS>::AccuracyParameters(fitting_tolerance,
                                          /*geopotential_tolerance=*/0x1p-24),
      Ephemeris<ICRS>::FixedStepParameters(integrator, step));
}

}  // namespace mathematica
}  // namespace principia
