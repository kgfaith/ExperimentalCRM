var AssociateWithArticle = function ($) {
    var LetsDoIt = function () {

        var $searchBox = $('#SearchArticles'),
            $articleSearchListTemplate = $('#articleSearchList'),
            $searchResultArea = $('.article-search-result table tbody'),
            $selectedArticleArea = $('.selected-article-table tbody'),
            $articleSelectedListTemplate = $('#articleSelectedList'),
            $addArticleButton = $('div.article-search-result span.plus-icon'),
            $removeSelectedArticleButton = $('.cross-icon'),
            $selectedArticleIdsInput = $('#SelectedArticles');

        $searchBox.on('keyup', function () {
            $searchResultArea.html('');
            $.ajax({
                url: '/Article/JsonQuickSearchArticle',
                dataType: 'json',
                data: {
                    Term: $searchBox.val(),
                    Excludes: $articleSearchListTemplate.val()
                },
                success: function (data) {
                    for (var i = 0; i < data.length; i++) {
                        var item = $articleSearchListTemplate.tmpl(data[i]);
                        $searchResultArea.append(item);
                    }
                }
            });
        });
        
        $('.article-search-result').delegate('.plus-icon', 'click', function () {
            var rowElement= $(this).parent().parent(),
            inputBox = $(rowElement).find('input[type="hidden"]');
            if (inputBox.length > 0) {
                var obj =  { value: "", label : ""};
                obj.value = $(rowElement).find('.value').text();
                obj.label = $(rowElement).find('.lbl').text();
                var item = $articleSelectedListTemplate.tmpl(obj);
                $selectedArticleArea.append(item);
                var ids = $selectedArticleIdsInput.val();
                $selectedArticleIdsInput.val(ids + ',' + obj.value);
                $(rowElement).remove();
            }
        });

        $('.selected-article-table').delegate('.cross-icon', 'click', function () {
            var rowElement = $(this).parent().parent();
            var articleId = $(rowElement).find('input[type="hidden"]').val();
            var idArray = $selectedArticleIdsInput.val().split(',');
            var len = idArray.length;
            var newIDList;
            for (var i = 0; i < len; i++) {
                if (articleId != idArray[i]) {
                    if (newIDList != null)
                        newIDList += ',' + idArray[i];
                    else
                        newIDList = idArray[i];
                }
            }
            $selectedArticleIdsInput.val(newIDList);
            $(rowElement).remove();
        });

    }
    return {
        LetsDoIt: LetsDoIt
    };
}
var obj = AssociateWithArticle(jQuery);
obj.LetsDoIt();