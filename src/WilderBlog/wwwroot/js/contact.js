// contact.js
(function (Vue, VeeValidate) {

  Vue.use(VeeValidate);

  var app = new Vue({
    el: "#contact-form",
    data: {
      mail: {
        name: "",
        email: "",
        subject: "Pick One...",
        msg: "",
        recaptcha: ""
      },
      subjects: [
        "Pick One...",
        "Training",
        "Coaching",
        "Course Question",
        "Business Proposition",
        "Film Question",
        "Other"
      ],
      errorMessage: "",
      statusMessage: ""
    },
    computed: {
      isPristine: function () {
        var val = (this.mail.name === "" || this.mail.email === "" || this.mail.msg === "" || this.mail.subject === this.subjects[0]);
        return val;
      }
    },
    methods: {
      onSubmit: function () {

        var me = this;

        me.statusMessage = "";
        
        var captcha = document.getElementById("g-recaptcha-response");
        if (captcha && captcha.value) {
          me.mail.recaptcha = captcha.value;
        } else {
          me.statusMessage = "Please confirm Captcha";
          return;
        }

        // Validate All returns a promise and provides the validation result.
        this.$validator.validateAll().then(function (success) {
          if (!success) {
            me.errorMessage = "Please fix one or more validation errors...";
            return;
          }
          me.statusMessage = "Sending...";
          me.errorMessage = "";

          me.$http.post("/contact", me.mail)
            .then(function () {
              me.mail.name = "";
              me.mail.email = "";
              me.mail.subject = me.subjects[0];
              me.mail.msg = "";
              this.$validator.reset();
              me.statusMessage = "Message Sent...";
            }, function (response) {
              me.statusMessage = "";
              if (response.body && response.body.reason) {
                me.errorMessage = response.body.reason;
              }
              else {
                me.errorMessage = "Failed to send message!";
              }
            });
        });
      }
    },
    created: function () {
      this.$set(this, 'errors', this.$validator.errorBag);
    }
  });

})(Vue, VeeValidate);