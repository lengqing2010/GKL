// Do Ajax function
function AjaxPost(ajaxActionType){
    $.ajax({
        type: 'POST',
        url: 'SaveDataAjax.aspx',
        data: {
            ajaxActionType : ajaxActionType
            ,tbxProjectId_key:$('#tbxProjectId_key').val()
            ,tbxLineId_key:$('#tbxLineId_key').val()
            ,tbxProjectId:$('#tbxProjectId').val()
            ,tbxLineId:$('#tbxLineId').val()
            ,tbxProjectName:$('#tbxProjectName').val()
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
    //Dim tbxProjectId_key As String = Request.Form("tbxProjectId_key")
    //Dim tbxLineId_key As String = Request.Form("tbxLineId_key")
    //Dim tbxProjectId As String = Request.Form("tbxProjectId")
    //Dim tbxLineId As String = Request.Form("tbxLineId")
    //Dim tbxProjectName As String = Request.Form("tbxProjectName")

//検索
//       Return BC.SelMProject(tbxProjectId_key ,tbxLineId_key)
//登録
//       Return BC.InsMProject(tbxProjectId ,tbxLineId ,tbxProjectName)
//削除
//       Return BC.DelMProject(tbxProjectId_key ,tbxLineId_key)
//更新
//       Return BC.UpdMProject(tbxProjectId_key ,tbxLineId_key ,tbxProjectId ,tbxLineId ,tbxProjectName)