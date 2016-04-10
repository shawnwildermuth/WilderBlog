"use strict";
// main.ts
var browser_1 = require('angular2/platform/browser');
var contact_1 = require('./components/contact');
var http_1 = require('angular2/http');
var emailservice_1 = require("./common/emailservice");
browser_1.bootstrap(contact_1.ContactForm, [http_1.HTTP_PROVIDERS, emailservice_1.EmailService]);
//# sourceMappingURL=main.js.map