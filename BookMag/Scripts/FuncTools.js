function replacer(str, offset, s) {
    var res = ""
    for (var j = 1; j < str.length; j++) {
        res += "*";
    }
    return res;
}

$('form').on('submit', function () {
    var library = ["отстой", "фигня"];
    var authorName = $('#Name').val();
    var textReview = $('#Review').val();
    for (var i = 0; i < library.length; i++) {
        if (textReview.indexOf(library[i]) !== -1) {
            var result = confirm("Нецензурная лексика, хотите заменить?")
            if (result) {
                var reg = new RegExp(library.join('|'), "gi");
                $('#Review').val(textReview.replace(reg, replacer));
            }
            else {
                return false;
            }
        }
    }
    return true;
});

$('.like-btn').click(function () {
    var reviewId = $(this).data('review');
    var $this = $(this).children('.like');
    $.post({
        'url': '/Review/AddLike',
        'data': { reviewId: reviewId },
        'success': function (Like) {
            $this.text(Like);
        },
        'error': function (_, error) {
            alert('error: ' + error)
        }
    });
});

$('.report-btn').click(function () {
    var result = confirm("Подтвердите действие!");
    var $this = $(this).parent();
    if (result) {
        var reviewId = $(this).data('review');
        var reason = prompt('Введите причину жалобы?!');
        if (reason.trim() !== '') {
            $.post({
                'url': '/Review/AddReport',
                'data': { reviewId: reviewId, reason: reason },
                'success': function () {
                    alert("Жалоба добавлена!");
                    $this.css('opacity', '0.5');
                },
                'error': function (_, error) {
                    alert('error: ' + error)
                }
            });
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
});