import axios from "axios";
import { Ref } from 'vue';
import ContactMail from './ContactMail';

export default {
  sendMail: async (mail: Ref<ContactMail>) => {
    try {
      var result = await axios.post<boolean>("/contact", mail.value);
      return result.data;
    } catch {
      return false;
    } 
  }
};