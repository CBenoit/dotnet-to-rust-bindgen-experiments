#ifndef PickyPem_HPP
#define PickyPem_HPP
#include <stdint.h>
#include <stddef.h>
#include <stdbool.h>
#include <algorithm>
#include <memory>
#include <variant>
#include <optional>
#include "diplomat_runtime.hpp"

namespace capi {
#include "PickyPem.h"
}

class PickyPem;
class PickyError;

/**
 * A destruction policy for using PickyPem with std::unique_ptr.
 */
struct PickyPemDeleter {
  void operator()(capi::PickyPem* l) const noexcept {
    capi::PickyPem_destroy(l);
  }
};
class PickyPem {
 public:
  static diplomat::result<PickyPem, PickyError> load_from_file(const std::string_view path);

  /**
   * Parses a PEM-encoded string representation into a PEM object.
   */
  static diplomat::result<PickyPem, PickyError> parse(const std::string_view input);

  /**
   * Creates a PEM object with a copy of the data.
   */
  static diplomat::result<PickyPem, PickyError> create(const std::string_view label, const diplomat::span<uint8_t> data);

  /**
   * Copy the label associated to the data contained in the PEM object.
   */
  template<typename W> diplomat::result<std::monostate, PickyError> label_to_writeable(W& writeable) const;

  /**
   * Copy the label associated to the data contained in the PEM object.
   */
  diplomat::result<std::string, PickyError> label() const;
  void print_label() const;
  inline const capi::PickyPem* AsFFI() const { return this->inner.get(); }
  inline capi::PickyPem* AsFFIMut() { return this->inner.get(); }
  inline PickyPem(capi::PickyPem* i) : inner(i) {}
  PickyPem() = default;
  PickyPem(PickyPem&&) noexcept = default;
  PickyPem& operator=(PickyPem&& other) noexcept = default;
 private:
  std::unique_ptr<capi::PickyPem, PickyPemDeleter> inner;
};

#include "PickyError.hpp"

inline diplomat::result<PickyPem, PickyError> PickyPem::load_from_file(const std::string_view path) {
  auto diplomat_result_raw_out_value = capi::PickyPem_load_from_file(path.data(), path.size());
  diplomat::result<PickyPem, PickyError> diplomat_result_out_value;
  if (diplomat_result_raw_out_value.is_ok) {
    diplomat_result_out_value = diplomat::Ok(PickyPem(diplomat_result_raw_out_value.ok));
  } else {
    diplomat_result_out_value = diplomat::Err(PickyError(diplomat_result_raw_out_value.err));
  }
  return diplomat_result_out_value;
}
inline diplomat::result<PickyPem, PickyError> PickyPem::parse(const std::string_view input) {
  auto diplomat_result_raw_out_value = capi::PickyPem_parse(input.data(), input.size());
  diplomat::result<PickyPem, PickyError> diplomat_result_out_value;
  if (diplomat_result_raw_out_value.is_ok) {
    diplomat_result_out_value = diplomat::Ok(PickyPem(diplomat_result_raw_out_value.ok));
  } else {
    diplomat_result_out_value = diplomat::Err(PickyError(diplomat_result_raw_out_value.err));
  }
  return diplomat_result_out_value;
}
inline diplomat::result<PickyPem, PickyError> PickyPem::create(const std::string_view label, const diplomat::span<uint8_t> data) {
  auto diplomat_result_raw_out_value = capi::PickyPem_create(label.data(), label.size(), data.data(), data.size());
  diplomat::result<PickyPem, PickyError> diplomat_result_out_value;
  if (diplomat_result_raw_out_value.is_ok) {
    diplomat_result_out_value = diplomat::Ok(PickyPem(diplomat_result_raw_out_value.ok));
  } else {
    diplomat_result_out_value = diplomat::Err(PickyError(diplomat_result_raw_out_value.err));
  }
  return diplomat_result_out_value;
}
template<typename W> inline diplomat::result<std::monostate, PickyError> PickyPem::label_to_writeable(W& writeable) const {
  capi::DiplomatWriteable writeable_writer = diplomat::WriteableTrait<W>::Construct(writeable);
  auto diplomat_result_raw_out_value = capi::PickyPem_label(this->inner.get(), &writeable_writer);
  diplomat::result<std::monostate, PickyError> diplomat_result_out_value;
  if (diplomat_result_raw_out_value.is_ok) {
    diplomat_result_out_value = diplomat::Ok(std::monostate());
  } else {
    diplomat_result_out_value = diplomat::Err(PickyError(diplomat_result_raw_out_value.err));
  }
  return diplomat_result_out_value;
}
inline diplomat::result<std::string, PickyError> PickyPem::label() const {
  std::string diplomat_writeable_string;
  capi::DiplomatWriteable diplomat_writeable_out = diplomat::WriteableFromString(diplomat_writeable_string);
  auto diplomat_result_raw_out_value = capi::PickyPem_label(this->inner.get(), &diplomat_writeable_out);
  diplomat::result<std::monostate, PickyError> diplomat_result_out_value;
  if (diplomat_result_raw_out_value.is_ok) {
    diplomat_result_out_value = diplomat::Ok(std::monostate());
  } else {
    diplomat_result_out_value = diplomat::Err(PickyError(diplomat_result_raw_out_value.err));
  }
  return diplomat_result_out_value.replace_ok(std::move(diplomat_writeable_string));
}
inline void PickyPem::print_label() const {
  capi::PickyPem_print_label(this->inner.get());
}
#endif
