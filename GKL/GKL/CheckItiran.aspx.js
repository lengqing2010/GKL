// Do Ajax function
function AjaxPost(ajaxActionType) {
    $.ajax({
        type: 'POST',
        url: 'SaveDataAjax.aspx',
        data: {
            ajaxActionType: ajaxActionType
            , tbxPicId_key: $('#tbxPicId_key').val()
            , tbxLineId_key: $('#tbxLineId_key').val()
            , tbxPicId: $('#tbxPicId').val()
            , tbxLineId: $('#tbxLineId').val()
            , tbxPicName: $('#tbxPicName').val()
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
function ajax_update() {
    AjaxPost('update');
}
// 嶍彍
function ajax_delete() {
    AjaxPost('delete');
}
// 搊榐
function ajax_insert() {
    AjaxPost('insert');
}
// 専嶕
function ajax_select() {
    AjaxPost('select');
}
// Ajax page use
//Dim tbxPicId_key As String = Request.Form("tbxPicId_key")
//Dim tbxLineId_key As String = Request.Form("tbxLineId_key")
//Dim tbxPicId As String = Request.Form("tbxPicId")
//Dim tbxLineId As String = Request.Form("tbxLineId")
//Dim tbxPicName As String = Request.Form("tbxPicName")

//専嶕
//       Return BC.SelMPicture(tbxPicId_key ,tbxLineId_key)
//搊榐
//       Return BC.InsMPicture(tbxPicId ,tbxLineId ,tbxPicName)
//嶍彍
//       Return BC.DelMPicture(tbxPicId_key ,tbxLineId_key)
//峏怴
//       Return BC.UpdMPicture(tbxPicId_key ,tbxLineId_key ,tbxPicId ,tbxLineId ,tbxPicName)

$(document).ready(function () {



    function disabledIt(obj) {
        $(obj).attr("readonly", "readonly");
        $(obj).css({ "background": "#ccc" });
        $(obj).attr("tabindex", "-1");
    }

    //图片Disable
    disabledIt($("#lblUserName"));


    //检查者No
    $("#tbxCheckUser").blur(function () {
        var obj;
        obj = $(this);

        if ($(this).val() == "") {
            return false;
        }

        htmlobj = $.ajax({ url: "AJAX.aspx?a=" + new Date() + "&kbn=user&user_cd=" + $(this).val() + "&line_id=" + $("#tbxLineId").val(), async: false });
        if (htmlobj.responseText == "") {
            alert("用户不存在");
            setTimeout(function () { obj.focus(); }, 100);
        } else {
            $("#lblUserName").val(htmlobj.responseText.split(",")[0]);
            $("#tbxLineId_key").val(htmlobj.responseText.split(",")[1]);
        }
    });

    $("#tbxCheckUser,#tbxMakeNo_key,#tbxCode_key").focus(function (e) {
        $(this)[0].select();
    });

    $("#tbxCheckUser").keydown(function (e) {
        if (e.keyCode == 13) {
            $("#tbxMakeNo_key")[0].select();
            e.preventDefault();
            return false;
        }
    });

    //作番 : 
    $("#tbxMakeNo_key").keydown(function (e) {
        if (e.keyCode == 13) {
            $("#tbxCode_key")[0].select();
            e.preventDefault();
            return false;
        }
    });
    $("#tbxCode_key").keydown(function (e) {
        if (e.keyCode == 13) {
            $("#btnInsert")[0].focus();
            e.preventDefault();
            return false;
        }
    });



});

