#pragma once

#include "base/not_null.hpp"

#include "glog/logging.h"

namespace principia {
namespace base {

template<typename Pointer>
not_null<Pointer>::not_null() : pointer_(pointer) {
  CHECK(pointer_ != nullptr);
}

template<typename Pointer>
bool not_null<Pointer>::operator Pointer const() const {
  return pointer_;
}

template<typename Pointer>
bool not_null<Pointer>::operator==(nullptr_t other) const {
  return false;
}

template<typename Pointer>
not_null<Pointer>::operator bool() const {
  return false;
}

template<typename Pointer>
not_null<Pointer> check_not_null(Pointer const pointer) {
  return not_null<Pointer>(pointer);
}

template<typename Pointer>
not_null<Pointer> check_not_null(not_null<Pointer> const pointer) {
  return pointer;
}

}  // namespace base
}  // namespace principia
