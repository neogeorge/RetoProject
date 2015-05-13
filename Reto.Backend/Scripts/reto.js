(function ($, undefined) {
    //Grid分頁
    $.fn.PagingGrid = function (ContainerSelector, submitSelector, url, options) {
        function postPage(selector, page) {

            if ($(selector).size() > 0) {
                $('#searchType').remove();
                $('#page').remove();
                $('<input>')
                    .attr({ type: 'hidden', id: 'page', name: 'page', value: page })
                    .appendTo($(selector));
                $(selector).submit();
            }
        };

        function exportData(selector) {
            if ($(selector).size() > 0) {
                $('#searchType').remove();
                $('<input>')
                    .attr({ type: 'hidden', id: 'searchType', name: 'searchType', value: 'Export' })
                    .appendTo($(selector));
                $(selector).submit();
            }
        };

        function getUrlParameter(url, sParam) {
            if (url == '#')
                return url;

            var sPageURL = url.split('?')[1];
            var sURLVariables = sPageURL.split('&');
            for (var i = 0; i < sURLVariables.length; i++) {
                var sParameterName = sURLVariables[i].split('=');
                if (sParameterName[0] == sParam) {
                    return sParameterName[1];
                }
            }
        }



        //標準設定值
        var $options = {
            'submitAjaxCheck': null,
            'submitEventBefor': null,
            'submitEventAfter': null,
            'submitEventError': null,
            'excelSelector': null
        }

        //合併設定值options有的部份填入 $options
        $options = $.extend({}, $options, options)


        this.each(function () {

            var $form = 'form#' + $(this).attr('id');
            var $container = ContainerSelector;
            var $messgeContainer = '.page-content';


            $($form).unbind("submit");

            //設定Form的ubmit事件
            $($form).submit(function (e) {


                //Stop form from submitting normally
                event.preventDefault();

                //事前檢查
                if ($options.submitAjaxCheck != null) {
                    if ($options.submitAjaxCheck() == false) {
                        return true;
                    }
                }

                //清除訊息
                $($messgeContainer).alertClean();

                $.ajax({
                    cache: false,
                    url: url,
                    type: 'POST',
                    data: $(this).serialize(),
                    datatype: 'html',
                    success: function (result) {
                        $($container).html('');
                        $($container).html(result);

                        $($messgeContainer).alertClean();

                        //事後準備事件
                        if ($options.submitEventAfter != null) {
                            $options.submitEventAfter();
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {

                        $($messgeContainer).LoadingTagClean();

                        $($messgeContainer).alertDanger(xhr.status + ' ' + thrownError, {});

                        //錯誤
                        if ($options.submitEventBefor != null) {
                            $options.submitEventBefor();
                        }

                    }
                });
                $($messgeContainer).alertInfo("資料查詢中..", { 'loading': true });
                return false;

            }
            );

            //換頁
            $(document).on('click', '.pagination > li > a', function (e) {
                e.preventDefault();
                if ($(this).attr('href') == '#')
                    return true;

                var page = getUrlParameter($(this).attr('href'), 'page');
                postPage($form, page);
                return false;
            });

            //查詢
            $(submitSelector).click(function () {
                postPage($form, 1);
            });

            //匯出Excel
            if ($options.excelSelector != null) {
                $(document).on('click', $options.excelSelector, function (e) {
                    e.preventDefault();
                    exportData($form);
                    return false;
                });
            }


        });
    }
})(window.jQuery);