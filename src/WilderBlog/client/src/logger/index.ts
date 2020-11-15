/* eslint-disable no-console */
import isProduction from "@/helpers/isProduction";

export default {
  log: (msg: string, arg: any = undefined) => {
    if (!isProduction) {
      if (arg) console.log(msg, { ...arg });
      else console.log(msg);
    }
  },
  error: (msg: string, arg: any = undefined) => {
    if (!isProduction) {
      if (arg) console.log(msg, { ...arg });
      else console.log(msg);
    }
  }
}
