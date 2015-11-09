$(function () {
    var renewFinderContent = function () {
        var $sel = $(this);
        var option = {
            url: $sel.attr('data-autogreat-ddl-finder-action')+$sel.val(),
            method:'post'
        };
        $.ajax(option).done(function (data) {
            var $target = $($sel.attr('data-autogreat-ddl-finder-replace'));
            $target.replaceWith(unescape(JSON.parse(data)));
        });
        return false;
    };
    $("select[data-autogreat-ddl-finder-ajax='true']").change(renewFinderContent);
});
$(function () {
    var finderDoSerch = function () {
        var $form = $(this);

        var $target = $($form.attr('data-autogreat-finder-replace'));
        if ($target.length == 0) {
            return true;
        }
        var option = {
            url: $form.attr('action'),
            method: $form.attr('method'),
            data:$form.serialize()
        };
        $.ajax(option).done(function (data) {
            var $target = $($form.attr('data-autogreat-finder-replace'));
            if ($target.length == 0)
            {
                return;
            }
            $target.replaceWith(data);
        });
       
        return false;
    };
    $("form[data-autogreat-finder='true']").submit(finderDoSerch);
});

$(function () {
    var selChangeFn = function (event,ui) {
        var $sl = $(this);
        $($sl.attr('data-autogreat-slider-min-edit')).val(ui.values[0]);
        $($sl.attr('data-autogreat-slider-max-edit')).val(ui.values[1]);
    };

    var $slidersArr = $(".slider");
    var index;
    for (index = 0; index < $slidersArr.length; ++index) {
        var $sl = $($slidersArr[index]);
        $sl.slider({
            range: Boolean($sl.attr('data-autogreat-slider-range')),
            min: Number($sl.attr('data-autogreat-slider-min')),
            max: Number($sl.attr('data-autogreat-slider-max')),
            values: [Number($sl.attr('data-autogreat-slider-min')), Number($sl.attr('data-autogreat-slider-max'))],
            change: selChangeFn,
            slide: selChangeFn
        });
        
    };

});


$(document).ready(function (e) {
    $(".partialContent").each(function (index, item) {
        var url = $(item).data("url");
        if (url && url.length > 0) {
            $(item).load(url);
        }
    })

});