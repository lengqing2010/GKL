// Do Ajax function
function AjaxPost(ajaxActionType){
    $.ajax({
        type: 'POST',
        url: 'SaveDataAjax.aspx',
        data: {
            ajaxActionType : ajaxActionType
            ,tbxChkNo_key:$('#tbxChkNo_key').val()
            ,tbxNen_key:$('#tbxNen_key').val()
            ,tbxLineId_key:$('#tbxLineId_key').val()
            ,tbxMakeNo_key:$('#tbxMakeNo_key').val()
            ,tbxChkNo:$('#tbxChkNo').val()
            ,tbxNen:$('#tbxNen').val()
            ,tbxPlanNo:$('#tbxPlanNo').val()
            ,tbxLineId:$('#tbxLineId').val()
            ,tbxMakeNo:$('#tbxMakeNo').val()
            ,tbxCode:$('#tbxCode').val()
            ,tbxSuu:$('#tbxSuu').val()
            ,tbxTempId:$('#tbxTempId').val()
            ,tbxChkResult:$('#tbxChkResult').val()
            ,tbxChkUser:$('#tbxChkUser').val()
            ,tbxChkStartDate:$('#tbxChkStartDate').val()
            ,tbxChkEndDate:$('#tbxChkEndDate').val()
            ,tbxParentChkNo:$('#tbxParentChkNo').val()
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
    //Dim tbxChkNo_key As String = Request.Form("tbxChkNo_key")
    //Dim tbxNen_key As String = Request.Form("tbxNen_key")
    //Dim tbxLineId_key As String = Request.Form("tbxLineId_key")
    //Dim tbxMakeNo_key As String = Request.Form("tbxMakeNo_key")
    //Dim tbxChkNo As String = Request.Form("tbxChkNo")
    //Dim tbxNen As String = Request.Form("tbxNen")
    //Dim tbxPlanNo As String = Request.Form("tbxPlanNo")
    //Dim tbxLineId As String = Request.Form("tbxLineId")
    //Dim tbxMakeNo As String = Request.Form("tbxMakeNo")
    //Dim tbxCode As String = Request.Form("tbxCode")
    //Dim tbxSuu As String = Request.Form("tbxSuu")
    //Dim tbxTempId As String = Request.Form("tbxTempId")
    //Dim tbxChkResult As String = Request.Form("tbxChkResult")
    //Dim tbxChkUser As String = Request.Form("tbxChkUser")
    //Dim tbxChkStartDate As String = Request.Form("tbxChkStartDate")
    //Dim tbxChkEndDate As String = Request.Form("tbxChkEndDate")
    //Dim tbxParentChkNo As String = Request.Form("tbxParentChkNo")
    //Dim tbxStatus As String = Request.Form("tbxStatus")
    //Dim tbxInsUser As String = Request.Form("tbxInsUser")
    //Dim tbxInsDate As String = Request.Form("tbxInsDate")

//専嶕
//       Return BC.SelTCheckResult(tbxChkNo_key ,tbxNen_key ,tbxLineId_key ,tbxMakeNo_key)
//搊榐
//       Return BC.InsTCheckResult(tbxChkNo ,tbxNen ,tbxPlanNo ,tbxLineId ,tbxMakeNo ,tbxCode ,tbxSuu ,tbxTempId ,tbxChkResult ,tbxChkUser ,tbxChkStartDate ,tbxChkEndDate ,tbxParentChkNo ,tbxStatus ,tbxInsUser ,tbxInsDate)
//嶍彍
//       Return BC.DelTCheckResult(tbxChkNo_key ,tbxNen_key ,tbxLineId_key ,tbxMakeNo_key)
//峏怴
//       Return BC.UpdTCheckResult(tbxChkNo_key ,tbxNen_key ,tbxLineId_key ,tbxMakeNo_key ,tbxChkNo ,tbxNen ,tbxPlanNo ,tbxLineId ,tbxMakeNo ,tbxCode ,tbxSuu ,tbxTempId ,tbxChkResult ,tbxChkUser ,tbxChkStartDate ,tbxChkEndDate ,tbxParentChkNo ,tbxStatus ,tbxInsUser ,tbxInsDate)