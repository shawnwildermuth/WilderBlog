"use strict";
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
var core_1 = require('@angular/core');
var common_1 = require('@angular/common');
var validators_1 = require('../common/validators');
var emailservice_1 = require("../common/emailservice");
var ContactForm = (function () {
    function ContactForm(fb, emailService) {
        var _this = this;
        this.subjects = ["Pick One...", "Course Question", "Business Proposal", "Other"];
        this.errorMessage = "";
        this.statusMessage = "";
        this.isBusy = false;
        this._emailService = emailService;
        this.form = fb.group({
            name: ["", common_1.Validators.compose([common_1.Validators.required, common_1.Validators.minLength(5)])],
            email: ["", common_1.Validators.compose([common_1.Validators.required, validators_1.CustomValidators.validEmail])],
            subject: [this.subjects[1], function (_) {
                    if (_.value == _this.subjects[0])
                        return { invalidSubject: true };
                }],
            msg: ["", common_1.Validators.compose([common_1.Validators.required, common_1.Validators.minLength(10)])]
        });
    }
    ContactForm.prototype.onSubmit = function () {
        var _this = this;
        this.statusMessage = "";
        this.errorMessage = "";
        this.isBusy = true;
        this._emailService.SendMessage({
            name: this.form.value.name,
            email: this.form.value.email,
            subject: this.form.value.subject,
            msg: this.form.value.msg
        })
            .subscribe(function (res) {
            // Deserialize
            var value = res.json();
            // If successful
            if (value.success) {
                _this.statusMessage = "Sent...";
                // Reset the controls
                _this.form.controls['name'].updateValue("");
                _this.form.controls['email'].updateValue("");
                _this.form.controls['subject'].updateValue(_this.subjects[0]);
                _this.form.controls['msg'].updateValue("");
            }
            else {
                _this.errorMessage = value.message;
            }
        }, function (res) {
            var error = res.json();
            _this.errorMessage = "Failed to send message:" + error.message;
        }, function () {
            _this.isBusy = false;
        });
    };
    ContactForm = __decorate([
        core_1.Component({
            selector: "contact-form",
            templateUrl: "./app/components/contactForm.html"
        }), 
        __metadata('design:paramtypes', [common_1.FormBuilder, emailservice_1.EmailService])
    ], ContactForm);
    return ContactForm;
}());
exports.ContactForm = ContactForm;
//# sourceMappingURL=contact.js.map