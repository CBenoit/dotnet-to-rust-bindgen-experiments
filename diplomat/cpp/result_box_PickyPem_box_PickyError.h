#ifndef result_box_PickyPem_box_PickyError_H
#define result_box_PickyPem_box_PickyError_H
#include <stdio.h>
#include <stdint.h>
#include <stddef.h>
#include <stdbool.h>
#include "diplomat_runtime.h"

#ifdef __cplusplus
extern "C" {
#endif
typedef struct PickyPem PickyPem;
typedef struct PickyError PickyError;
typedef struct pem_ffi_result_box_PickyPem_box_PickyError {
    union {
        PickyPem* ok;
        PickyError* err;
    };
    bool is_ok;
} pem_ffi_result_box_PickyPem_box_PickyError;
#ifdef __cplusplus
}
#endif
#endif
