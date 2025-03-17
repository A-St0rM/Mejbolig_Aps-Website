module.exports = {
    corePlugins: {
        preflight: false, // Deaktiverer Tailwind's reset
    },
    content: [
        "./src/*/.{js,jsx,ts,tsx}", // Sikrer at alle JSX/TSX-filer er inkluderet
    ],
    theme: {
        extend: {},
    },
    plugins: [],
};