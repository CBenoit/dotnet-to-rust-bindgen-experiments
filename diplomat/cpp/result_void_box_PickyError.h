#ifndef result_void_box_PickyError_H
#define result_void_box_PickyError_H
#include <stdio.h>
#include <stdint.h>
#include <stddef.h>
#include <stdbool.h>
#include "diplomat_runtime.h"

#ifdef __cplusplus
extern "C" {
#endif
typedef struct PickyError PickyError;
typedef struct pem_ffi_result_void_box_PickyError {
    union {
        PickyError* err;
    };
    bool is_ok;
} pem_ffi_result_void_box_PickyError;
#ifdef __cplusplus
}
#endif
#endif
