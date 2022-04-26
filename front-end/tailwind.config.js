module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: '#0052cc',
        'gray-main': '#f4f5f7'
      },
      spacing: {
        'full': '100%',
        '80%': '80%',
        '50%': '50%',
        'main-backlog': "var(--header-height)",
      }
    },
  },
  plugins: [],
}
