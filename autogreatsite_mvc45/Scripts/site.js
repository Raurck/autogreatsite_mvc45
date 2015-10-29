$(document).ready(function (e) {
    $(".partialContent").each(function (index, item) {
        var url = $(item).data("url");
        if (url && url.length > 0) {
            $(item).load(url);
        }
    })

})