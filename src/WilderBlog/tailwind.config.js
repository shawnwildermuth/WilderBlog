module.exports = {
  purge: {
    content: [
      './views//**/*.cshtml',
      './client/**/*.vue'
    ]
  },
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {
      fontFamily: {
        sans: ['Roboto', 'Helvetica Neue', 'Helvetica', 'Arial', 'sans-serif'],
        serif: ['Atkinson-Hyperlegible', 'Georgia', 'Times New Roman', 'serif']
      },
      animation: {
        'spin-slow': 'spin 2s linear infinite',
      }
    },
  },
  variants: {
    extend: {
      animation: ['hover'],
    }
  },
  plugins: [],
}
