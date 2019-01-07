// Do Ajax function
function AjaxPost(ajaxActionType){
    $.ajax({
        type: 'POST',
        url: 'SaveDataAjax.aspx',
        data: {
            ajaxActionType : ajaxActionType
            ,tbxToolId_key:$('#tbxToolId_key').val()
            ,tbxLineId_key:$('#tbxLineId_key').val()
            ,tbxToolId:$('#tbxToolId').val()
            ,tbxLineId:$('#tbxLineId').val()
            ,tbxProjectName:$('#tbxProjectName').val()
            ,tbxToolName:$('#tbxToolName').val()
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
    //Dim tbxToolId_key As String = Request.Form("tbxToolId_key")
    //Dim tbxLineId_key As String = Request.Form("tbxLineId_key")
    //Dim tbxToolId As String = Request.Form("tbxToolId")
    //Dim tbxLineId As String = Request.Form("tbxLineId")
    //Dim tbxProjectName As String = Request.Form("tbxProjectName")
    //Dim tbxToolName As String = Request.Form("tbxToolName")

//専嶕
//       Return BC.SelMTools(tbxToolId_key ,tbxLineId_key)
//搊榐
//       Return BC.InsMTools(tbxToolId ,tbxLineId ,tbxProjectName ,tbxToolName)
//嶍彍
//       Return BC.DelMTools(tbxToolId_key ,tbxLineId_key)
//峏怴
//       Return BC.UpdMTools(tbxToolId_key ,tbxLineId_key ,tbxToolId ,tbxLineId ,tbxProjectName ,tbxToolName)