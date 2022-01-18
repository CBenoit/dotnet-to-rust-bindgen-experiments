#ifndef PickyError_H
#define PickyError_H
#include <stdio.h>
#include <stdint.h>
#include <stddef.h>
#include <stdbool.h>
#include "diplomat_runtime.h"

#ifdef __cplusplus
extern "C" {
#endif

typedef struct PickyError PickyError;

void PickyError_display(const PickyError* self, DiplomatWriteable* writeable);

void PickyError_print(const PickyError* self);
void PickyError_destroy(PickyError* self);

#ifdef __cplusplus
}
#endif
#endif
