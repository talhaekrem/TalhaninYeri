(function () {

    window.inputNumber = function (el) {

        var min = el.attr('min') || false;
        var max = el.attr('max') || false;

        var els = {};

        els.dec = el.prev();
        els.inc = el.next();

        el.each(function () {
            init($(this));
        });

        function init(el) {

            els.dec.on('click', decrement);
            els.inc.on('click', increment);

            function decrement() {
                var value = el[0].value;
                value--;
                if (!min || value >= min) {
                    el[0].value = value;
                }
            }

            function increment() {
                var value = el[0].value;
                value++;
                if (!max || value <= max) {
                    el[0].value = value++;
                }
            }
        }
    }
})();

inputNumber($('.input-number'));

/*ürün detay slick*/
$('.mainPhoto').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: true,
    fade: true,
    dots: false,
    asNavFor: '.ProductGallery'
});
$('.ProductGallery').slick({
    slidesToShow: 4,
    slidesToScroll: 1,
    asNavFor: '.mainPhoto',
    arrows: false,
    dots: false,
    centerMode: true,
    focusOnSelect: true,
    autoplay: false,
    responsive: [
        {
            breakpoint: 1200,
            settings: {
                slidesToShow: 4,
                slidesToScroll: 1,
            }
        },
        {
            breakpoint: 768,
            settings: {
                slidesToShow: 3,
                slidesToScroll: 1
            }
        },
        {
            breakpoint: 480,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 1
            }
        }
    ]
});

$('.firsatUrunSlick').slick({
    dots: true,
    speed: 450,
    slidesToShow: 4,
    slidesToScroll: 1,
    infinite: true,
    arrows: false,
    centerMode: false,
    autoplay: true,
    responsive: [
        {
            breakpoint: 1200,
            settings: {
                slidesToShow: 3,
                slidesToScroll: 1,
            }
        },
        {
            breakpoint: 768,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 1
            }
        },
        {
            breakpoint: 480,
            settings: {
                slidesToShow: 1,
                slidesToScroll: 1
            }
        }
    ]
});

$('.sonEklenenSlick').slick({
    dots: true,
    speed: 450,
    slidesToShow: 4,
    slidesToScroll: 1,
    infinite: true,
    arrows: false,
    centerMode: false,
    autoplay: true,
    responsive: [
        {
            breakpoint: 1200,
            settings: {
                slidesToShow: 3,
                slidesToScroll: 1,
            }
        },
        {
            breakpoint: 768,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 1
            }
        },
        {
            breakpoint: 480,
            settings: {
                slidesToShow: 1,
                slidesToScroll: 1
            }
        }
    ]
});

$('.TopSaleSlick').slick({
    dots: true,
    speed: 450,
    slidesToShow: 1,
    slidesToScroll: 1,
    infinite: true,
    arrows: false,
    centerMode: false,
    autoplay: false,
    fade: true

});

document.querySelectorAll(".price").forEach(item => {
    item.textContent = item.textContent.slice(0, -2);
});
