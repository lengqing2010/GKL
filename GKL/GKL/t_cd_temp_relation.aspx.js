// Do Ajax function
function AjaxPost(ajaxActionType){
    $.ajax({
        type: 'POST',
        url: 'SaveDataAjax.aspx',
        data: {
            ajaxActionType : ajaxActionType
            ,tbxLineId_key:$('#tbxLineId_key').val()
            ,tbxCode_key:$('#tbxCode_key').val()
            ,tbxTempId_key:$('#tbxTempId_key').val()
            ,tbxLineId:$('#tbxLineId').val()
            ,tbxCode:$('#tbxCode').val()
            ,tbxTempId:$('#tbxTempId').val()
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
    //Dim tbxLineId_key As String = Request.Form("tbxLineId_key")
    //Dim tbxCode_key As String = Request.Form("tbxCode_key")
    //Dim tbxTempId_key As String = Request.Form("tbxTempId_key")
    //Dim tbxLineId As String = Request.Form("tbxLineId")
    //Dim tbxCode As String = Request.Form("tbxCode")
    //Dim tbxTempId As String = Request.Form("tbxTempId")

//検索
//       Return BC.SelTCdTempRelation(tbxLineId_key ,tbxCode_key ,tbxTempId_key)
//登録
//       Return BC.InsTCdTempRelation(tbxLineId ,tbxCode ,tbxTempId)
//削除
//       Return BC.DelTCdTempRelation(tbxLineId_key ,tbxCode_key ,tbxTempId_key)
//更新
//       Return BC.UpdTCdTempRelation(tbxLineId_key ,tbxCode_key ,tbxTempId_key ,tbxLineId ,tbxCode ,tbxTempId)