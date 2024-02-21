module.exports = {
    content: [
       './Pages/**/*.cshtml',
       './Views/**/*.cshtml'
],
    darkMode: 'class',
    theme: {
      container: {
        center : true,
        screens : {
          lg : '1140px',
          xl : '1140px',
          '2xl' : '1140px',
        }
      },
      fontSize: {
        xxs: '0.5rem',
        xs: '0.75rem',
        sm: '0.85rem',
        md: '0.92rem',
        lg: '1rem',
        xl: '1.25rem',
        '2xl': '1.563rem',
        '3xl': '1.953rem',
        '4xl': '2.441rem',
        '5xl': '3.052rem',
        },

        extend: {
          backgroundImage: {
            'my-home' : "url('~/images/home.jpg')"
          },
            colors: {
              "my-siyah" : "#2D2D2D",
              "my-mavi" : "#0099E5",
              "my-beyaz" : "#FFFFFF",
              "my-ebbeyaz" : "#EBEBEB",
              "my-kırmızı" : "#FF0000",
              "my-edbeyaz" : "#EDEFF1",
              "my-açıkgri" : "#737373",
              "my-4b4b4bgri" : "#4B4B4B",
              "my-sidebeyaz" : "#EDEFF1",
              "my-navgri" : "#AFAFAF",
              "my-141414" : "#141414",
              "my-ortamavi" : "#354C58",
                primary: { "50": "#eff6ff", "100": "#dbeafe", "200": "#bfdbfe", "300": "#93c5fd", "400": "#60a5fa", "500": "#3b82f6", "600": "#2563eb", "700": "#1d4ed8", "800": "#1e40af", "900": "#1e3a8a", "950": "#172554" }
            }
        },
        fontFamily: {
            'body': [
                'Inter',
                'ui-sans-serif',
                'system-ui',
                '-apple-system',
                'system-ui',
                'Segoe UI',
                'Roboto',
                'Helvetica Neue',
                'Arial',
                'Noto Sans',
                'sans-serif',
                'Apple Color Emoji',
                'Segoe UI Emoji',
                'Segoe UI Symbol',
                'Noto Color Emoji'
            ],
            'sans': [
                'Inter',
                'ui-sans-serif',
                'system-ui',
                '-apple-system',
                'system-ui',
                'Segoe UI',
                'Roboto',
                'Helvetica Neue',
                'Arial',
                'Noto Sans',
                'sans-serif',
                'Apple Color Emoji',
                'Segoe UI Emoji',
                'Segoe UI Symbol',
                'Noto Color Emoji'
            ],
            'poppins' : ['Poppins', 'sans-serif'],
            
        }
    },
    plugins: [],
    spacing: {
      100 : '26rem',
      128 : '32rem',
      140 : '38rem',
      180 : '44rem',
      192 : '48rem',
      200 : '56rem',
      216 : '64rem',
      256 : '70rem',
    }


}



