﻿// Do Ajax function
function AjaxPost(ajaxActionType){
    $.ajax({
        type: 'POST',
        url: 'SaveDataAjax.aspx',
        data: {
            ajaxActionType : ajaxActionType
            ,tbxPicId_key:$('#tbxPicId_key').val()
            ,tbxLineId_key:$('#tbxLineId_key').val()
            ,tbxPicId:$('#tbxPicId').val()
            ,tbxLineId:$('#tbxLineId').val()
            ,tbxPicName:$('#tbxPicName').val()
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
    //Dim tbxPicId_key As String = Request.Form("tbxPicId_key")
    //Dim tbxLineId_key As String = Request.Form("tbxLineId_key")
    //Dim tbxPicId As String = Request.Form("tbxPicId")
    //Dim tbxLineId As String = Request.Form("tbxLineId")
    //Dim tbxPicName As String = Request.Form("tbxPicName")

//検索
//       Return BC.SelMPicture(tbxPicId_key ,tbxLineId_key)
//登録
//       Return BC.InsMPicture(tbxPicId ,tbxLineId ,tbxPicName)
//削除
//       Return BC.DelMPicture(tbxPicId_key ,tbxLineId_key)
//更新
//       Return BC.UpdMPicture(tbxPicId_key ,tbxLineId_key ,tbxPicId ,tbxLineId ,tbxPicName)