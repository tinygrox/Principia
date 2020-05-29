﻿#pragma once

#include <vector>

#include "base/not_null.hpp"
#include "geometry/frame.hpp"
#include "geometry/grassmann.hpp"
#include "geometry/named_quantities.hpp"
#include "numerics/polynomial.hpp"
#include "numerics/polynomial_evaluators.hpp"
#include "physics/oblate_body.hpp"
#include "quantities/named_quantities.hpp"

namespace principia {
namespace physics {
namespace internal_geopotential {

using base::not_null;
using geometry::Displacement;
using geometry::Frame;
using geometry::Instant;
using geometry::Vector;
using numerics::PolynomialInMonomialBasis;
using quantities::Acceleration;
using quantities::Angle;
using quantities::Exponentiation;
using quantities::GravitationalParameter;
using quantities::Infinity;
using quantities::Inverse;
using quantities::Length;
using quantities::Quotient;
using quantities::Square;

// Specification of the damping of a spherical harmonic, acting as a radial
// multiplier on the potential:
//   V_damped = σ(‖r‖) V(r).
class HarmonicDamping final {
 public:
  HarmonicDamping() = default;
  explicit HarmonicDamping(Length const& inner_threshold);

  // Above this threshold, the contribution to the potential from this
  // harmonic is 0, i.e., σ = 0.
  Length const& outer_threshold() const;
  // Below this threshold, the contribution to the potential from this
  // harmonic is undamped, σ = 1.
  // This class depends on the invariant: outer_threshold = 3 * inner_threshold.
  Length const& inner_threshold() const;

  // Sets σℜ_over_r and grad_σℜ according to σ as defined by |*this|.
  template<typename Frame>
  void ComputeDampedRadialQuantities(
      Length const& r_norm,
      Square<Length> const& r²,
      Vector<double, Frame> const& r_normalized,
      Inverse<Square<Length>> const& ℜ_over_r,
      Inverse<Square<Length>> const& ℜʹ,
      Inverse<Square<Length>>& σℜ_over_r,
      Vector<Inverse<Square<Length>>, Frame>& grad_σℜ) const;

 private:
  Length outer_threshold_ = Infinity<Length>;
  Length inner_threshold_ = Infinity<Length>;

  // For r in [outer_threshold, inner_threshold], σ is a polynomial with the
  // following coefficients in monomial basis.
  // The constant term is always 0, and is thus ignored in the evaluation.
  // TODO(phl): We have to specify an evaluator, but we do not use it; we use a
  // custom evaluation that ignores the constant term instead.  See #1922.
  PolynomialInMonomialBasis<
      double, Length, 3,
      numerics::EstrinEvaluator>::Coefficients sigmoid_coefficients_;
};

// Representation of the geopotential model of an oblate body.
template<typename Frame>
class Geopotential {
 public:
  // Spherical harmonics will not be damped if their contribution to the radial
  // force exceeds |tolerance| times the central force.
  Geopotential(not_null<OblateBody<Frame> const*> body,
               double tolerance);

  Vector<Quotient<Acceleration, GravitationalParameter>, Frame>
  SphericalHarmonicsAcceleration(
      Instant const& t,
      Displacement<Frame> const& r,
      Square<Length> const& r²,
      Exponentiation<Length, -3> const& one_over_r³) const;

  Vector<Quotient<Acceleration, GravitationalParameter>, Frame>
  GeneralSphericalHarmonicsAcceleration(
      Instant const& t,
      Displacement<Frame> const& r,
      Length const& r_norm,
      Square<Length> const& r²,
      Exponentiation<Length, -3> const& one_over_r³) const;

  std::vector<HarmonicDamping> const& degree_damping() const;
  HarmonicDamping const& sectoral_damping() const;

 private:
  // The frame of the surface of the celestial.
  using SurfaceFrame = geometry::Frame<enum class SurfaceFrameTag>;
  static const Vector<double, SurfaceFrame> x_;
  static const Vector<double, SurfaceFrame> y_;

  // This is the type that we return, so better have a name for it.
  using ReducedAcceleration = Quotient<Acceleration, GravitationalParameter>;

  // List of reduced accelerations computed for all degrees or orders.
  template<int size>
  using ReducedAccelerations =
      std::array<Vector<ReducedAcceleration, Frame>, size>;

  using UnitVector = Vector<double, Frame>;

  // Holds precomputed data for one evaluation of the acceleration.
  struct Precomputations;

  // Helper templates for iterating over the degrees/orders of the geopotential.
  template<int degree, int order>
  struct DegreeNOrderM;
  template<int degree, typename>
  struct DegreeNAllOrders;
  template<typename>
  struct AllDegrees;

  // If z is a unit vector along the axis of rotation, and r a vector from the
  // center of |body_| to some point in space, the acceleration computed here
  // is:
  //
  //   -(J₂ / (μ ‖r‖⁵)) (3 z (r.z) + r (3 - 15 (r.z)² / ‖r‖²) / 2)
  //
  // Where ‖r‖ is the norm of r and r.z is the inner product.  It is the
  // additional acceleration exerted by the oblateness of |body| on a point at
  // position r.  J₂, J̃₂ and J̄₂ are normally positive and C̃₂₀ and C̄₂₀ negative
  // because the planets are oblate, not prolate.  Note that this follows IERS
  // Technical Note 36 and it differs from
  // https://en.wikipedia.org/wiki/Geopotential_model which seems to want J̃₂ to
  // be negative.
  Vector<Quotient<Acceleration, GravitationalParameter>, Frame>
  Degree2ZonalAcceleration(UnitVector const& axis,
                           Displacement<Frame> const& r,
                           Exponentiation<Length, -2> const& one_over_r²,
                           Exponentiation<Length, -3> const& one_over_r³) const;

  not_null<OblateBody<Frame> const*> body_;

  // The contribution from the harmonics of degree n is damped by
  // degree_damping_[n].
  // degree_damping_[0] and degree_damping_[1] have infinite thresholds, and are
  // not used (this class does not compute the central force and disregards
  // degree 1, which is equivalent to a translation of the centre of mass).
  std::vector<HarmonicDamping> degree_damping_;

  // The contribution of the degree 2 sectoral harmonics is damped by
  // |sectoral_damping_|; |degree_damping_[2]| affects only J2.
  // The monotonicity relation
  //   degree_damping[2] ≼ sectoral_damping_ ≼ degree_damping[3]
  // holds, where ≼ denotes the ordering of the thresholds.
  HarmonicDamping sectoral_damping_;
};

}  // namespace internal_geopotential

using internal_geopotential::Geopotential;

}  // namespace physics
}  // namespace principia

#include "physics/geopotential_body.hpp"
