// main.ts
import { bootstrap } from 'angular2/platform/browser';
import { ContactForm } from './components/contact'; 
import {HTTP_PROVIDERS} from 'angular2/http';
import { EmailService } from "./common/emailservice"; 

bootstrap(ContactForm, [HTTP_PROVIDERS, EmailService]);