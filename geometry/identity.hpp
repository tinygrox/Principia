﻿
#pragma once

#include "base/macros.hpp"
#include "base/mappable.hpp"
#include "geometry/grassmann.hpp"
#include "geometry/linear_map.hpp"
#include "geometry/sign.hpp"
#include "serialization/geometry.pb.h"

namespace principia {
namespace geometry {

FORWARD_DECLARE_FROM(orthogonal_map,
                     TEMPLATE(typename FromFrame, typename ToFrame) class,
                     OrthogonalMap);
FORWARD_DECLARE_FROM(
    symmetric_bilinear_form,
    TEMPLATE(typename Scalar,
             typename Frame,
             template<typename, typename> typename Multivector) class,
    SymmetricBilinearForm);

namespace internal_identity {

using base::not_null;

// The identity map.
template<typename FromFrame, typename ToFrame>
class Identity : public LinearMap<FromFrame, ToFrame> {
  static_assert(FromFrame::handedness == ToFrame::handedness,
                "Cannot identity frames with different handedness");

 public:
  Identity() = default;

  Sign Determinant() const override;

  Identity<ToFrame, FromFrame> Inverse() const;

  template<typename Scalar>
  Vector<Scalar, ToFrame> operator()(
      Vector<Scalar, FromFrame> const& vector) const;

  template<typename Scalar>
  Bivector<Scalar, ToFrame> operator()(
      Bivector<Scalar, FromFrame> const& bivector) const;

  template<typename Scalar>
  Trivector<Scalar, ToFrame> operator()(
      Trivector<Scalar, FromFrame> const& trivector) const;

  template<typename Scalar,
           template<typename, typename> typename Multivector>
  SymmetricBilinearForm<Scalar, ToFrame, Multivector> operator()(
      SymmetricBilinearForm<Scalar, FromFrame, Multivector> const& form) const;

  template<typename T>
  typename base::Mappable<Identity, T>::type operator()(T const& t) const;

  template<template<typename, typename> typename LinearMap>
  LinearMap<FromFrame, ToFrame> Forget() const;

  void WriteToMessage(not_null<serialization::LinearMap*> message) const;
  template<typename F = FromFrame,
           typename T = ToFrame,
           typename = std::enable_if_t<base::is_serializable_v<F> &&
                                       base::is_serializable_v<T>>>
  static Identity ReadFromMessage(serialization::LinearMap const& message);

  void WriteToMessage(not_null<serialization::Identity*> message) const;
  template<typename F = FromFrame,
           typename T = ToFrame,
           typename = std::enable_if_t<base::is_serializable_v<F> &&
                                       base::is_serializable_v<T>>>
  static Identity ReadFromMessage(serialization::Identity const& message);

 private:
  template<typename Scalar>
  R3Element<Scalar> operator()(R3Element<Scalar> const& r3_element) const;
};

template<typename FromFrame, typename ThroughFrame, typename ToFrame>
Identity<FromFrame, ToFrame> operator*(
    Identity<ThroughFrame, ToFrame> const& left,
    Identity<FromFrame, ThroughFrame> const& right);

template<typename FromFrame, typename ToFrame>
std::ostream& operator<<(std::ostream& out,
                         Identity<FromFrame, ToFrame> const& identity);

}  // namespace internal_identity

using internal_identity::Identity;

}  // namespace geometry
}  // namespace principia

#include "geometry/identity_body.hpp"
