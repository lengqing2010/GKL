$(document).ready(function () {

    $.ajax({
        type: 'POST',
        url: 'AJAX.aspx?kbn=lines',
        async: true, //true:yibu
        datatype: 'html',//'xml', 'html', 'script', 'json', 'jsonp', 'text'.
        //when complete
        complete: function (XMLHttpRequest, textStatus) {
            $("#line_id_list")[0].innerHTML = XMLHttpRequest.responseText;
        }
    });

});
