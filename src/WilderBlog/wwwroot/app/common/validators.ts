// validators.ts
import { Control } from '@angular/common';

export class CustomValidators {
    static validEmail(ctrl: Control) {
        var EMAIL_REGEXP = /^[a-z0-9!#$%&'*+\/=?^_`{|}~.-]+@[a-z0-9]([a-z0-9-]*[a-z0-9])?(\.[a-z0-9]([a-z0-9-]*[a-z0-9])?)*$/i;
        if (!EMAIL_REGEXP.test(ctrl.value.trim())) {
            return { invalidEmail: true };
        }
    }
}