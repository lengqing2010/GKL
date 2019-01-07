// Do Ajax function
function AjaxPost(ajaxActionType){
    $.ajax({
        type: 'POST',
        url: 'SaveDataAjax.aspx',
        data: {
            ajaxActionType : ajaxActionType
            ,tbxUserCd_key:$('#tbxUserCd_key').val()
            ,tbxUserCd:$('#tbxUserCd').val()
            ,tbxLineId:$('#tbxLineId').val()
            ,tbxUserName:$('#tbxUserName').val()
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
    //Dim tbxUserCd_key As String = Request.Form("tbxUserCd_key")
    //Dim tbxUserCd As String = Request.Form("tbxUserCd")
    //Dim tbxLineId As String = Request.Form("tbxLineId")
    //Dim tbxUserName As String = Request.Form("tbxUserName")

//検索
//       Return BC.SelMUser(tbxUserCd_key)
//登録
//       Return BC.InsMUser(tbxUserCd ,tbxLineId ,tbxUserName)
//削除
//       Return BC.DelMUser(tbxUserCd_key)
//更新
//       Return BC.UpdMUser(tbxUserCd_key ,tbxUserCd ,tbxLineId ,tbxUserName)