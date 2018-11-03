$(function () {
    $.Kaadoto.Home = {};
    $.extend($.Kaadoto.Home, {
        initializing: function () {
            //var swiper = new Swiper('.swiper-container', {
            //    slidesPerView: 3,
            //    spaceBetween: 30,
            //    slidesPerGroup: 3,
            //    loop: true,
            //    loopFillGroupWithBlank: true,
            //    pagination: {
            //        el: '.swiper-pagination',
            //        clickable: true,
            //    },
            //    navigation: {
            //        nextEl: '.swiper-button-next',
            //        prevEl: '.swiper-button-prev',
            //    },
            //});

            $('.areas_items_carousel').owlCarousel({
                loop: false,
                dots: false,
                margin: 20,
                responsiveClass: true,
                responsive: {
                    0: {
                        items: 1,
                        nav: true
                    },
                    300: {
                        items: 2,
                        nav: false
                    },
                    450: {
                        items: 3,
                        nav: false
                    },
                    600: {
                        items: 4,
                        nav: false
                    },
                    1000: {
                        items: 6,
                        nav: true,
                        loop: false
                    }
                }
            });
        }
    });
    $.Kaadoto.Home.initializing();
});