/** @type {import('tailwindcss').Config} */
import daisyui from 'daisyui'
import typography from '@tailwindcss/typography'


export default {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  daisyui: {
    themes: ["emerald"],
  },
  theme: {
    fontFamily: {
      'bungee': ['Bungee'],
      'rubik': ['Rubik'],
      'tourney': ['Tourney']
    },
    extend: {},
  },
  plugins: [
    daisyui,
    typography,
  ],
}