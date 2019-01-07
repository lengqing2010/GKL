// Do Ajax function
function AjaxPost(ajaxActionType){
    $.ajax({
        type: 'POST',
        url: 'SaveDataAjax.aspx',
        data: {
            ajaxActionType : ajaxActionType
            ,tbxChkNo_key:$('#tbxChkNo_key').val()
            ,tbxChkNo:$('#tbxChkNo').val()
            ,tbxChkMethodId:$('#tbxChkMethodId').val()
            ,tbxChkFlg:$('#tbxChkFlg').val()
            ,tbxIn1:$('#tbxIn1').val()
            ,tbxIn2:$('#tbxIn2').val()
            ,tbxChkResult:$('#tbxChkResult').val()
            ,tbxMark:$('#tbxMark').val()
            ,tbxKj0:$('#tbxKj0').val()
            ,tbxKj1:$('#tbxKj1').val()
            ,tbxKj2:$('#tbxKj2').val()
            ,tbxKjExplain:$('#tbxKjExplain').val()
            ,tbxInsUser:$('#tbxInsUser').val()
            ,tbxInsDate:$('#tbxInsDate').val()
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
    //Dim tbxChkNo_key As String = Request.Form("tbxChkNo_key")
    //Dim tbxChkNo As String = Request.Form("tbxChkNo")
    //Dim tbxChkMethodId As String = Request.Form("tbxChkMethodId")
    //Dim tbxChkFlg As String = Request.Form("tbxChkFlg")
    //Dim tbxIn1 As String = Request.Form("tbxIn1")
    //Dim tbxIn2 As String = Request.Form("tbxIn2")
    //Dim tbxChkResult As String = Request.Form("tbxChkResult")
    //Dim tbxMark As String = Request.Form("tbxMark")
    //Dim tbxKj0 As String = Request.Form("tbxKj0")
    //Dim tbxKj1 As String = Request.Form("tbxKj1")
    //Dim tbxKj2 As String = Request.Form("tbxKj2")
    //Dim tbxKjExplain As String = Request.Form("tbxKjExplain")
    //Dim tbxInsUser As String = Request.Form("tbxInsUser")
    //Dim tbxInsDate As String = Request.Form("tbxInsDate")

//専嶕
//       Return BC.SelTCheckMs(tbxChkNo_key)
//搊榐
//       Return BC.InsTCheckMs(tbxChkNo ,tbxChkMethodId ,tbxChkFlg ,tbxIn1 ,tbxIn2 ,tbxChkResult ,tbxMark ,tbxKj0 ,tbxKj1 ,tbxKj2 ,tbxKjExplain ,tbxInsUser ,tbxInsDate)
//嶍彍
//       Return BC.DelTCheckMs(tbxChkNo_key)
//峏怴
//       Return BC.UpdTCheckMs(tbxChkNo_key ,tbxChkNo ,tbxChkMethodId ,tbxChkFlg ,tbxIn1 ,tbxIn2 ,tbxChkResult ,tbxMark ,tbxKj0 ,tbxKj1 ,tbxKj2 ,tbxKjExplain ,tbxInsUser ,tbxInsDate)