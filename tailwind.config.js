/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Views/**/*.cshtml", // Tüm Razor View'larýnýz için
        "./wwwroot/js/**/*.js" // JavaScript dosyalarýnýz için
    ],
    theme: {
        extend: {},
    },
    plugins: [],
}
