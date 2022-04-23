$(function(){

    $('.owl-carousel').owlCarousel({
        autoplay: false,

        margin: 20,
        responsiveClass: true,
        autoHeight: true,
        autoplayTimeout: 2000,
        smartSpeed: 400,
        nav: true,
        dots:false,
        responsive: {
            0: {
            items: 1
            },

            300: {
            items: 2
            },
            400: {
            items: 3
            },

            500: {
            items: 4
            },
            600: {
            items: 5
            },

            1024: {
            items: 6
            },

            1366: {
            items: 7
            }
        }
            });
});