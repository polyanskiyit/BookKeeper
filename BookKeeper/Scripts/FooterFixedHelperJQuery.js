$(window).load(function () {
    var height = $(window).height();
    $(".footerFixed").css('top', (height / 100) * 90);
    $(".footerFixed").css('width', '100%');
    $(".footerFixed").css("position", "fixed");
});