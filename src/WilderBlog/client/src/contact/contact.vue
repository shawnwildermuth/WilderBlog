<template>
  <div class="row" v-cloak="true">
    <div class="col-12 col-lg-8 offset-lg-2 col-xl-6 offset-xl-3">
      <form novalidate v-on:submit.prevent="onSubmit">
        <div class="form-group">
          <label for="name">Your Name</label>
          <input type="text" class="form-control" v-model="model.name.$model" placeholder="e.g. John Smith" autofocus name="name" />
          <ModelError :model="model.name" />
        </div>
        <div class="form-group">
          <label for="email">Email</label>
          <input type="email" class="form-control" v-model="model.email.$model" placeholder="e.g. john@aol.com" name="email" />
          <ModelError :model="model.email" />
        </div>
        <div class="form-group">
          <label for="subject">Subject</label>
          <select v-model="model.subject.$model" class="form-control c-select" name="subject">
            <option v-for="s in subjects" :value="s">
              {{ s }}
            </option>
          </select>
          <ModelError :model="model.subject" />
        </div>
        <div class="form-group">
          <label for="msg">Message</label>
          <textarea class="form-control" rows="6" cols="40" name="msg" v-model="model.msg.$model" placeholder="e.g. Hey Shawn, you magnificent beast."></textarea>
          <ModelError :model="model.msg" />
        </div>
        <div class="form-group">
          <div class="g-recaptcha" :data-sitekey="captchaId" data-size="compact" data-callback="__onCaptchaSuccess__"></div>
          <ModelError :model="model.recaptcha" />
        </div>
        <div class="form-group">
          <div class="pull-right">
            <a href="/" class="btn">Cancel</a>
            <button class="btn btn-success" :disabled="model.$invalid">Send Email</button>
          </div>
          <div>
            <div v-if="status" class="text-primary">{{ status }}</div>
            <div v-if="error" class="text-warning">{{ error }}</div>
          </div>
        </div>
      </form>
    </div>
  </div>

</template>

<script lang="ts">
  import { defineComponent, ref } from "vue";
  import { required, email, minLength, not } from "@vuelidate/validators";
  import { useVuelidate } from "@vuelidate/core";
  import http from "axios";
  import ModelError from "@/components/ModelError.vue";
  import ContactMail from "./ContactMail";
  
  // Override for sharing with data
  declare global {
    interface Window { captchaId: string, __captcha__callback: Function }
  }

  // Just ignore type safety for Google Recaptcha
  // Need this to support our resetting of the object
  declare var grecaptcha: any;

  export default defineComponent({
    components: {
      ModelError
    },
    setup() {

      const error = ref("");
      const isBusy = ref(false);
      const status = ref("");

      const mail = ref<ContactMail>(cleanMail());

      window.__captcha__callback = function (value: string) {
        mail.value.recaptcha = value;
      }

      function cleanMail(): ContactMail {
        return {
          name: "",
          email: "",
          subject: "Pick One...",
          msg: "",
          recaptcha: ""
        };
      }

      const captchaId = ref(window.captchaId);
      const subjects = [
        "Pick One...",
        "Training",
        "Coaching",
        "Course Question",
        "Business Proposition",
        "Film Question",
        "Other"
      ];

      const notEqual = (checkValue: any) => ({
        $validator: (value: any) => {
          if (typeof value === 'undefined' || value === null || value === '') {
            return true
          }
          return value !== checkValue;
        }, $message: `Must pick a value`
      });

      const rules = {
        name: { required, minLength: minLength(5) },
        email: { required, email },
        subject: { required, minLength: minLength(5), notEqual: notEqual(subjects[0]) },
        msg: { required, minLength: minLength(20) },
        recaptcha: { required }
      }

      const model = useVuelidate(rules, mail);

      async function onSubmit() {
        // reset
        status.value = "";
        isBusy.value = false;
        error.value = "";

        if (model.value.$validate && await model.value.$validate()) {
          // Save
          try {
            isBusy.value = true;
            let result = await http.post<boolean>("/contact", mail.value);
            if (result.data) {
              model.value.$reset();
              grecaptcha.reset();
              mail.value = cleanMail();
              status.value = "Message Sent...";
            } else {
              error.value = "Failed to send message...";
            }
          } catch {
            error.value = "Failed to send message...";
          } finally {
            isBusy.value = true;
          }
        }
      }

      return {
        model,
        error,
        isBusy,
        subjects,
        captchaId,
        status,
        onSubmit
      };
    }
  });
</script>