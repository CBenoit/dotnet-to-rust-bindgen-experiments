#ifndef PickyPem_H
#define PickyPem_H
#include <stdio.h>
#include <stdint.h>
#include <stddef.h>
#include <stdbool.h>
#include "diplomat_runtime.h"

#ifdef __cplusplus
extern "C" {
#endif

typedef struct PickyPem PickyPem;
#include "result_box_PickyPem_box_PickyError.h"
#include "result_void_box_PickyError.h"

pem_ffi_result_box_PickyPem_box_PickyError PickyPem_load_from_file(const char* path_data, size_t path_len);

pem_ffi_result_box_PickyPem_box_PickyError PickyPem_parse(const char* input_data, size_t input_len);

pem_ffi_result_box_PickyPem_box_PickyError PickyPem_create(const char* label_data, size_t label_len, const uint8_t* data_data, size_t data_len);

pem_ffi_result_void_box_PickyError PickyPem_label(const PickyPem* self, DiplomatWriteable* writeable);

void PickyPem_print_label(const PickyPem* self);
void PickyPem_destroy(PickyPem* self);

#ifdef __cplusplus
}
#endif
#endif
