/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./src/**/*.{js,jsx,ts,tsx}", // Sikrer, at Tailwind scanner dine React-filer
        "./public/index.html", // Hvis Tailwind bruges i index.html
    ],
    theme: {
        extend: {},
    },
    plugins: [],
}
