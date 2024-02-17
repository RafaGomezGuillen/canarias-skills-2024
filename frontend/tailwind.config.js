/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}", "node_modules/preline/dist/*.js"],
  theme: {
    extend: {
      colors: {
        "default": "var(--default)",
        "primary": "var(--primary)",
        "secondary": "var(--secondary)",
        "accent": "var(--accent)",
        "neutral": "var(--neutral)",
        "base-100": "var(--base-100)",
        "info": "var(--info)",
        "success": "var(--success)",
        "warning": "var(--warning)",
        "error": "var(--error)",
      },
    },
  },
  plugins: [require("@tailwindcss/forms"), require("preline/plugin")],
};
