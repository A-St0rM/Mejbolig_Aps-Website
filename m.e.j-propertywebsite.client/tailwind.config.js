module.exports = {
    corePlugins: {
        preflight: false, // Deaktiverer Tailwind's reset
    },
    content: [
        "./src/**/*.{js,jsx,ts,tsx}", // Sikrer at alle JSX/TSX-filer er inkluderet
    ],
    theme: {
        extend: {
            keyframes: {
                wiggle: {
                    "0%": { transform: "rotate(0deg)" },
                    "20%": { transform: "rotate(-1deg)" },
                    "40%": { transform: "rotate(1deg)" },
                    "60%": { transform: "rotate(0deg)" },  
                    "100%": { transform: "rotate(0deg)" },
                },
            },
            animation: {
                wiggle: "wiggle 3s ease-in-out infinite",
            },
        },
    },
    plugins: [],
};