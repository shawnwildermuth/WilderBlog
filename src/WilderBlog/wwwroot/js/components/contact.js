var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
// contact.ts
var core_1 = require('angular2/core');
var common_1 = require('angular2/common');
var validators_1 = require('../common/validators');
var ContactForm = (function () {
    function ContactForm(fb) {
        this.subjects = ["Pick One...", "Course Question", "Business Proposal", "Other"];
        this.form = fb.group({
            name: ["", common_1.Validators.compose([common_1.Validators.required, common_1.Validators.minLength(5)])],
            email: ["", common_1.Validators.compose([common_1.Validators.required, validators_1.CustomValidators.validEmail])],
            subject: ["",],
            msg: ["", common_1.Validators.compose([common_1.Validators.required, common_1.Validators.minLength(10)])]
        });
    }
    ContactForm.prototype.onSubmit = function () {
        alert(this.form.value.name);
    };
    ContactForm = __decorate([
        core_1.Component({
            selector: "contact-form",
            templateUrl: "./tmpl/contactForm.html"
        }), 
        __metadata('design:paramtypes', [common_1.FormBuilder])
    ], ContactForm);
    return ContactForm;
})();
exports.ContactForm = ContactForm;
function validSubject(c) {
    if (c.value == "Pick One...")
        return { invalidChoice: true };
}
//# sourceMappingURL=contact.js.map