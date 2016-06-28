// main.ts
import { bootstrap } from '@angular/platform-browser-dynamic';
import { ContactForm } from './components/contact';
import {HTTP_PROVIDERS} from '@angular/http';
import { EmailService } from "./common/emailservice";

bootstrap(ContactForm, [HTTP_PROVIDERS, EmailService]);