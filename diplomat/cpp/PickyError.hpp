#ifndef PickyError_HPP
#define PickyError_HPP
#include <stdint.h>
#include <stddef.h>
#include <stdbool.h>
#include <algorithm>
#include <memory>
#include <variant>
#include <optional>
#include "diplomat_runtime.hpp"

namespace capi {
#include "PickyError.h"
}


/**
 * A destruction policy for using PickyError with std::unique_ptr.
 */
struct PickyErrorDeleter {
  void operator()(capi::PickyError* l) const noexcept {
    capi::PickyError_destroy(l);
  }
};
class PickyError {
 public:
  template<typename W> void display_to_writeable(W& writeable) const;
  std::string display() const;
  void print() const;
  inline const capi::PickyError* AsFFI() const { return this->inner.get(); }
  inline capi::PickyError* AsFFIMut() { return this->inner.get(); }
  inline PickyError(capi::PickyError* i) : inner(i) {}
  PickyError() = default;
  PickyError(PickyError&&) noexcept = default;
  PickyError& operator=(PickyError&& other) noexcept = default;
 private:
  std::unique_ptr<capi::PickyError, PickyErrorDeleter> inner;
};


template<typename W> inline void PickyError::display_to_writeable(W& writeable) const {
  capi::DiplomatWriteable writeable_writer = diplomat::WriteableTrait<W>::Construct(writeable);
  capi::PickyError_display(this->inner.get(), &writeable_writer);
}
inline std::string PickyError::display() const {
  std::string diplomat_writeable_string;
  capi::DiplomatWriteable diplomat_writeable_out = diplomat::WriteableFromString(diplomat_writeable_string);
  capi::PickyError_display(this->inner.get(), &diplomat_writeable_out);
  return diplomat_writeable_string;
}
inline void PickyError::print() const {
  capi::PickyError_print(this->inner.get());
}
#endif
