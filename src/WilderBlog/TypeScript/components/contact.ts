// contact.ts
import { Component } from 'angular2/core';
import { FormBuilder, Validators, Control, ControlGroup } from 'angular2/common';
import { CustomValidators } from '../common/validators';

@Component({
  selector: "contact-form",
  templateUrl: "./tmpl/contactForm.html"
})
export class ContactForm {
  subjects = ["Pick One...", "Course Question", "Business Proposal", "Other"];
  form: ControlGroup;

  constructor(fb: FormBuilder) {

    this.form = fb.group({
      name: ["", Validators.compose([Validators.required, Validators.minLength(5)])],
      email: ["", Validators.compose([Validators.required, CustomValidators.validEmail])],
      subject: ["", ],
      msg: ["", Validators.compose([Validators.required, Validators.minLength(10)])]
    });

  }

  onSubmit() {
    alert(this.form.value.name); 
  }
}

function validSubject(c: Control) {
  if (c.value == "Pick One...") return { invalidChoice: true };
}
