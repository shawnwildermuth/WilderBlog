"use strict";
var CustomValidators = (function () {
    function CustomValidators() {
    }
    CustomValidators.validEmail = function (ctrl) {
        var EMAIL_REGEXP = /^[a-z0-9!#$%&'*+\/=?^_`{|}~.-]+@[a-z0-9]([a-z0-9-]*[a-z0-9])?(\.[a-z0-9]([a-z0-9-]*[a-z0-9])?)*$/i;
        if (!EMAIL_REGEXP.test(ctrl.value.trim())) {
            return { invalidEmail: true };
        }
    };
    return CustomValidators;
}());
exports.CustomValidators = CustomValidators;
//# sourceMappingURL=validators.js.map