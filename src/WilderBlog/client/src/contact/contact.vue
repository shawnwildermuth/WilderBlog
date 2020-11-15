<template>
  <div class="row" v-cloak>
    <div class="col-12 col-lg-8 offset-lg-2 col-xl-6 offset-xl-3">
      <div v-if="isBusy" class="alert alert-info">
        <small><i class="fas fa-circle-notch fa-spin"></i> Sending...</small>
      </div>
      <form novalidate v-on:submit.prevent="onSubmit" id="contact-form">
        <div class="form-group">
          <label for="name">Your Name</label>
          <input
            type="text"
            class="form-control"
            v-model="model.name.$model"
            placeholder="e.g. John Smith"
            autofocus
            name="name"
            :class="{ error: model.name.$invalid }"
          />
          <ModelError :model="model.name" />
        </div>
        <div class="form-group">
          <label for="email">Email</label>
          <input
            type="email"
            class="form-control"
            v-model="model.email.$model"
            placeholder="e.g. john@aol.com"
            name="email"
            :class="{ error: model.email.$invalid }"
          />
          <ModelError :model="model.email" />
        </div>
        <div class="form-group">
          <label for="subject">Subject</label>
          <select
            v-model="model.subject.$model"
            class="form-control c-select"
            name="subject"
            :class="{ error: model.subject.$invalid }"
          >
            <option v-for="s in subjects" :key="s" :value="s">
              {{ s }}
            </option>
          </select>
          <ModelError :model="model.subject" />
        </div>
        <div class="form-group">
          <label for="msg">Message</label>
          <textarea
            class="form-control"
            rows="3"
            cols="40"
            name="msg"
            v-model="model.msg.$model"
            placeholder="e.g. Hey Shawn, you magnificent beast."
            :class="{ error: model.msg.$invalid }"
          ></textarea>
          <ModelError :model="model.msg" />
        </div>
        <div class="form-group">
          <div
            class="g-recaptcha"
            :data-sitekey="captchaId"
            data-size="compact"
            data-callback="__onCaptchaSuccess__"
          ></div>
          <ModelError :model="model.recaptcha">
            Must confirm you're not a robot. Seriously, HAL is no joke.
          </ModelError>
        </div>
        <div class="form-group">
          <div class="pull-right">
            <button
              class="btn btn-success"
              :disabled="model.$invalid || isBusy">
              Send Email
            </button>
            <a href="/" class="btn">Cancel</a>
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
import { defineComponent, Ref, ref } from "vue";
import ModelError from "@/components/ModelError.vue";
import ContactMail from "./ContactMail";
import { subjects } from "../lookups";
import http from "./http";

// Override for sharing with data
declare global {
  interface Window {
    captchaId: string,
    __captcha__callback: Function;
  }
}

// Just ignore type safety for Google Recaptcha
// Need this to support our resetting of the object
declare var grecaptcha: any;

export default defineComponent({
  components: {
    ModelError,
  },
  setup() {
    const error = ref("");
    const isBusy = ref(false);
    const status = ref("");
    const mail: Ref<ContactMail> = ref(new ContactMail());
    const captchaId = ref(window.captchaId);
    const model = mail.value.getModel();

    // Used to get value from Captcha
    // HACK
    window.__captcha__callback = function (value: string) {
      mail.value.recaptcha = value;
    };

    async function onSubmit() {
      // reset
      status.value = "";
      isBusy.value = false;
      error.value = "";

      if (model.value.$validate && (await model.value.$validate())) {
        // Save
        isBusy.value = true;
        if (await http.sendMail(mail)) {
          model.value.$reset();
          grecaptcha.reset();
          mail.value.reset();
          status.value = "Message Sent...";
        } else {
          error.value = "Failed to send message...";
        }
        isBusy.value = false;
      }
    }

    return {
      model,
      error,
      isBusy,
      subjects,
      status,
      captchaId,
      onSubmit,
    };
  },
});
</script>

<style lang="less">
#contact-form {
  input,
  textarea,
  select {
    &.error {
      border: solid rgba(255, 0, 0, 0.5) 0.2px;
      -webkit-box-shadow: 0px 0px 5px 0px rgba(255, 0, 0, 0.5);
      -moz-box-shadow: 0px 0px 5px 0px rgba(255, 0, 0, 0.5);
      box-shadow: 0px 0px 5px 0px rgba(255, 0, 0, 0.5);
    }
  }
}
</style>