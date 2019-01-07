// Do Ajax function
function AjaxPost(ajaxActionType){
    $.ajax({
        type: 'POST',
        url: 'SaveDataAjax.aspx',
        data: {
            ajaxActionType : ajaxActionType
            ,tbxPlanNo_key:$('#tbxPlanNo_key').val()
            ,tbxChkNo_key:$('#tbxChkNo_key').val()
            ,tbxMakeNo_key:$('#tbxMakeNo_key').val()
            ,tbxCode_key:$('#tbxCode_key').val()
            ,tbxLineId_key:$('#tbxLineId_key').val()
            ,tbxPlanNo:$('#tbxPlanNo').val()
            ,tbxChkNo:$('#tbxChkNo').val()
            ,tbxMakeNo:$('#tbxMakeNo').val()
            ,tbxCode:$('#tbxCode').val()
            ,tbxLineId:$('#tbxLineId').val()
            ,tbxSuu:$('#tbxSuu').val()
            ,tbxYoteiChkDate:$('#tbxYoteiChkDate').val()
            ,tbxStatus:$('#tbxStatus').val()
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
    //Dim tbxPlanNo_key As String = Request.Form("tbxPlanNo_key")
    //Dim tbxChkNo_key As String = Request.Form("tbxChkNo_key")
    //Dim tbxMakeNo_key As String = Request.Form("tbxMakeNo_key")
    //Dim tbxCode_key As String = Request.Form("tbxCode_key")
    //Dim tbxLineId_key As String = Request.Form("tbxLineId_key")
    //Dim tbxPlanNo As String = Request.Form("tbxPlanNo")
    //Dim tbxChkNo As String = Request.Form("tbxChkNo")
    //Dim tbxMakeNo As String = Request.Form("tbxMakeNo")
    //Dim tbxCode As String = Request.Form("tbxCode")
    //Dim tbxLineId As String = Request.Form("tbxLineId")
    //Dim tbxSuu As String = Request.Form("tbxSuu")
    //Dim tbxYoteiChkDate As String = Request.Form("tbxYoteiChkDate")
    //Dim tbxStatus As String = Request.Form("tbxStatus")
    //Dim tbxInsUser As String = Request.Form("tbxInsUser")
    //Dim tbxInsDate As String = Request.Form("tbxInsDate")

//専嶕
//       Return BC.SelTCheckPlan(tbxPlanNo_key ,tbxChkNo_key ,tbxMakeNo_key ,tbxCode_key ,tbxLineId_key)
//搊榐
//       Return BC.InsTCheckPlan(tbxPlanNo ,tbxChkNo ,tbxMakeNo ,tbxCode ,tbxLineId ,tbxSuu ,tbxYoteiChkDate ,tbxStatus ,tbxInsUser ,tbxInsDate)
//嶍彍
//       Return BC.DelTCheckPlan(tbxPlanNo_key ,tbxChkNo_key ,tbxMakeNo_key ,tbxCode_key ,tbxLineId_key)
//峏怴
//       Return BC.UpdTCheckPlan(tbxPlanNo_key ,tbxChkNo_key ,tbxMakeNo_key ,tbxCode_key ,tbxLineId_key ,tbxPlanNo ,tbxChkNo ,tbxMakeNo ,tbxCode ,tbxLineId ,tbxSuu ,tbxYoteiChkDate ,tbxStatus ,tbxInsUser ,tbxInsDate)