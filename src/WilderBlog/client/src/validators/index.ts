export const notEqual = (checkValue: any) => ({
  $validator: (value: any) => {
    if (typeof value === "undefined" || value === null || value === "") {
      return true;
    }
    return value !== checkValue;
  },
  $message: `Must pick a value.`,
});

export default {
  notEqual
};