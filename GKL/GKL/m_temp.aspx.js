// Do Ajax function
function AjaxPost(ajaxActionType){
    $.ajax({
        type: 'POST',
        url: 'SaveDataAjax.aspx',
        data: {
            ajaxActionType : ajaxActionType
            ,tbxLineId_key:$('#tbxLineId_key').val()
            ,tbxTempId_key:$('#tbxTempId_key').val()
            ,tbxChkMethodId_key:$('#tbxChkMethodId_key').val()
            ,tbxLineId:$('#tbxLineId').val()
            ,tbxTempId:$('#tbxTempId').val()
            ,tbxChkMethodId:$('#tbxChkMethodId').val()
            ,tbxProjectId:$('#tbxProjectId').val()
            ,tbxProjectName:$('#tbxProjectName').val()
            ,tbxPicId:$('#tbxPicId').val()
            ,tbxPicName:$('#tbxPicName').val()
            ,tbxChkKmName:$('#tbxChkKmName').val()
            ,tbxPicSign:$('#tbxPicSign').val()
            ,tbxChkId:$('#tbxChkId').val()
            ,tbxChkName:$('#tbxChkName').val()
            ,tbxToolId:$('#tbxToolId').val()
            ,tbxKj0:$('#tbxKj0').val()
            ,tbxKj1:$('#tbxKj1').val()
            ,tbxKj2:$('#tbxKj2').val()
            ,tbxKjExplain:$('#tbxKjExplain').val()
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
// 峏怴
function ajax_update(){
    AjaxPost('update');
}
// 嶍彍
function ajax_delete(){
    AjaxPost('delete');
}
// 搊榐
function ajax_insert(){
    AjaxPost('insert');
}
// 専嶕
function ajax_select(){
    AjaxPost('select');
}
// Ajax page use
    //Dim tbxLineId_key As String = Request.Form("tbxLineId_key")
    //Dim tbxTempId_key As String = Request.Form("tbxTempId_key")
    //Dim tbxChkMethodId_key As String = Request.Form("tbxChkMethodId_key")
    //Dim tbxLineId As String = Request.Form("tbxLineId")
    //Dim tbxTempId As String = Request.Form("tbxTempId")
    //Dim tbxChkMethodId As String = Request.Form("tbxChkMethodId")
    //Dim tbxProjectId As String = Request.Form("tbxProjectId")
    //Dim tbxProjectName As String = Request.Form("tbxProjectName")
    //Dim tbxPicId As String = Request.Form("tbxPicId")
    //Dim tbxPicName As String = Request.Form("tbxPicName")
    //Dim tbxChkKmName As String = Request.Form("tbxChkKmName")
    //Dim tbxPicSign As String = Request.Form("tbxPicSign")
    //Dim tbxChkId As String = Request.Form("tbxChkId")
    //Dim tbxChkName As String = Request.Form("tbxChkName")
    //Dim tbxToolId As String = Request.Form("tbxToolId")
    //Dim tbxKj0 As String = Request.Form("tbxKj0")
    //Dim tbxKj1 As String = Request.Form("tbxKj1")
    //Dim tbxKj2 As String = Request.Form("tbxKj2")
    //Dim tbxKjExplain As String = Request.Form("tbxKjExplain")

//専嶕
//       Return BC.SelMTemp(tbxLineId_key ,tbxTempId_key ,tbxChkMethodId_key)
//搊榐
//       Return BC.InsMTemp(tbxLineId ,tbxTempId ,tbxChkMethodId ,tbxProjectId ,tbxProjectName ,tbxPicId ,tbxPicName ,tbxChkKmName ,tbxPicSign ,tbxChkId ,tbxChkName ,tbxToolId ,tbxKj0 ,tbxKj1 ,tbxKj2 ,tbxKjExplain)
//嶍彍
//       Return BC.DelMTemp(tbxLineId_key ,tbxTempId_key ,tbxChkMethodId_key)
//峏怴
//       Return BC.UpdMTemp(tbxLineId_key ,tbxTempId_key ,tbxChkMethodId_key ,tbxLineId ,tbxTempId ,tbxChkMethodId ,tbxProjectId ,tbxProjectName ,tbxPicId ,tbxPicName ,tbxChkKmName ,tbxPicSign ,tbxChkId ,tbxChkName ,tbxToolId ,tbxKj0 ,tbxKj1 ,tbxKj2 ,tbxKjExplain)