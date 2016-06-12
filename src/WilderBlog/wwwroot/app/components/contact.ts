// contact.ts
import { Component } from '@angular/core';
import { FormBuilder, Validators, Control, ControlGroup } from '@angular/common';
import { CustomValidators } from '../common/validators';
import { EmailService, IContactMessage } from "../common/emailservice";

@Component({
    selector: "contact-form",
    templateUrl: "./app/components/contactForm.html"
})
export class ContactForm {
    subjects = ["Pick One...", "Course Question", "Business Proposal", "Other"];
    form: ControlGroup;
    errorMessage: string = "";
    statusMessage: string = "";
    isBusy: boolean = false;

    private _emailService: EmailService;

    constructor(fb: FormBuilder, emailService: EmailService) {

        this._emailService = emailService;

        this.form = fb.group({
            name: ["", Validators.compose([Validators.required, Validators.minLength(5)])],
            email: ["", Validators.compose([Validators.required, CustomValidators.validEmail])],
            subject: [this.subjects[1], (_: Control) => {
                if (_.value == this.subjects[0]) return { invalidSubject: true };
            }],
            msg: ["", Validators.compose([Validators.required, Validators.minLength(10)])]
        });

    }

    onSubmit() {
        this.statusMessage = "";
        this.errorMessage = "";
        this.isBusy = true;
        this._emailService.SendMessage({
            name: this.form.value.name,
            email: this.form.value.email,
            subject: this.form.value.subject,
            msg: this.form.value.msg
        })
            .subscribe(res => {
                // Deserialize
                var value = res.json();

                // If successful
                if (value.success) {
                    this.statusMessage = "Sent...";
                    // Reset the controls
                    (<Control>this.form.controls['name']).updateValue("");
                    (<Control>this.form.controls['email']).updateValue("");
                    (<Control>this.form.controls['subject']).updateValue(this.subjects[0]);
                    (<Control>this.form.controls['msg']).updateValue("");
                } else {
                    this.errorMessage = value.message;
                }
            },
            res => { // Error
                var error = res.json();
                this.errorMessage = "Failed to send message:" + error.message;
            },
            () => {
                this.isBusy = false;
            });
    }
}
