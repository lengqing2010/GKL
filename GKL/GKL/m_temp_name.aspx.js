// Do Ajax function
function AjaxPost(ajaxActionType){
    $.ajax({
        type: 'POST',
        url: 'SaveDataAjax.aspx',
        data: {
            ajaxActionType : ajaxActionType
            ,tbxTempId_key:$('#tbxTempId_key').val()
            ,tbxTempId:$('#tbxTempId').val()
            ,tbxTempName:$('#tbxTempName').val()
        },
        datatype: 'html',//'xml', 'html', 'script', 'json', 'jsonp', 'text'.
        beforeSend: function () {
        },
        //when success
        success: function (data) {
        },
        //when complete
        complete: function (XMLHttpRequest, textStatus) {
            //alert(XMLHttpRequest.responseText);
            alert(textStatus);
        },
        //when error
        error: function () {
        }
    });
}
// 更新
function ajax_update(){
    AjaxPost('update');
}
// 削除
function ajax_delete(){
    AjaxPost('delete');
}
// 登録
function ajax_insert(){
    AjaxPost('insert');
}
// 検索
function ajax_select(){
    AjaxPost('select');
}
// Ajax page use
    //Dim tbxTempId_key As String = Request.Form("tbxTempId_key")
    //Dim tbxTempId As String = Request.Form("tbxTempId")
    //Dim tbxTempName As String = Request.Form("tbxTempName")

//検索
//       Return BC.SelMTempName(tbxTempId_key)
//登録
//       Return BC.InsMTempName(tbxTempId ,tbxTempName)
//削除
//       Return BC.DelMTempName(tbxTempId_key)
//更新
//       Return BC.UpdMTempName(tbxTempId_key ,tbxTempId ,tbxTempName)