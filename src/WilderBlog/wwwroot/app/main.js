"use strict";
// main.ts
var platform_browser_dynamic_1 = require('@angular/platform-browser-dynamic');
var contact_1 = require('./components/contact');
var http_1 = require('@angular/http');
var emailservice_1 = require("./common/emailservice");
platform_browser_dynamic_1.bootstrap(contact_1.ContactForm, [http_1.HTTP_PROVIDERS, emailservice_1.EmailService]);
//# sourceMappingURL=main.js.map