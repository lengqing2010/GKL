$(document).ready(function () {

    $('.jq_upd')[0].disabled = true;
    $('.jq_del')[0].disabled = true;
    $('#btnComlete')[0].disabled = true;

    $(".jq_ms tr").click(function () {
        //
        if ($(this)[0].innerText.indexOf("待检查") == -1) {
            $('.jq_upd').removeAttr("disabled");
            $('.jq_del').removeAttr("disabled");
            $('#btnComlete').removeAttr("disabled");

        } else {
            $('.jq_upd')[0].disabled = true;
            $('.jq_del')[0].disabled = true;
            $('#btnComlete')[0].disabled = true;

        }
  
    })

    function disabledIt(obj) {
        $(obj).attr("readonly", "readonly");
        $(obj).css({ "background": "#ccc" });
        $(obj).attr("tabindex", "-1");
    }

    //disabledIt($("#tbxLineId_key"));
    
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

