$(document).ready(function () {
    var _windowScrollTop = $(window).scrollTop(),
        _windowScrollTopLast = _windowScrollTop, // 0 = down : 1 = up
        $scrollHeader = $('.navbar-under');

    $(window).scroll(function () {
        // console.log(_windowScrollTop);
        _windowScrollTop = $(this).scrollTop();
        var marginTop = 0;
        if ((_windowScrollTopLast < _windowScrollTop) && (_windowScrollTop >= 100)) {
            $scrollHeader.removeAttr('style');
            $scrollHeader.addClass('scroll-header-hide');
        } else {
            $scrollHeader.removeClass('scroll-header-hide');
            if (_windowScrollTop < 100 && parseInt($scrollHeader.css('top')) != 0) {
                marginTop = (0 - _windowScrollTop + 'px');
                $scrollHeader.css('top', marginTop);
            }
        }
        _windowScrollTopLast = _windowScrollTop;
    });
});