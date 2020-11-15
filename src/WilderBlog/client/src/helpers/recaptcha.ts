import logger from "@/logger";

// Override for sharing with data
declare global {
  interface Window {
    captchaId: string
  }
}

// Just ignore type safety for Google Recaptcha
// Need this to support our resetting of the object
declare var grecaptcha: any;

export default {
  checkCaptcha: (): Promise<string> => {
    return new Promise<string>((resolve, reject) => {
      grecaptcha.ready(() => {
        grecaptcha.execute(window.captchaId, { action: 'submit' })
          .then((token: string) => {
            logger.log("Recaptcha Success");
            resolve(token);
          })
          .catch(() => {
            logger.error("Recaptcha Failed");
            reject();
          });
      });
    });

  }
}