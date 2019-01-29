$(document).ready(function () {



    function disabledIt(obj) {
        $(obj).attr("readonly", "readonly");
        $(obj).css({ "background": "#ccc" });
        $(obj).attr("tabindex", "-1");
    }

    //图片Disable
    disabledIt($("#tbxPicName"));
    disabledIt($("#tbxChkName"));

    $("#tbxPicId").dblclick(function () {
        window.open("m_picture_popup.aspx?line_id=" + $("#tbxLineId").val() + "&pic_id=" + $("#tbxPicId").attr("id") + "&pic_name_id=" + $("#tbxPicName").attr("id"),
            'newwindow', "height=700,width=1000,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no");


    });

    $("#tbxChkId").dblclick(function () {
        window.open("m_check_method_popup.aspx?line_id=" + $("#tbxLineId").val() + "&method_id=" + $("#tbxChkId").attr("id") + "&method_name_id=" + $("#tbxChkName").attr("id"),
            'newwindow', "height=700,width=1000,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no");


    });


    $("#tbxToolId").dblclick(function () {
        window.open("m_tools_popup.aspx?line_id=" + $("#tbxLineId").val() + "&tool_id=" + $("#tbxToolId").attr("id") + "&tool_name_id=" + $("#tbxKjExplain").attr("id"),
            'newwindow', "height=700,width=1000,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no");


    });

    //图片ID 变更时
    $("#tbxPicId").change(function () {
        var obj;
        obj = $(this);
        htmlobj = $.ajax({ url: "AJAX.aspx?a=" + new Date() + "&kbn=pic&pic_id=" + $(this).val() + "&line_id=" + $("#tbxLineId").val(), async: false });
        if (htmlobj.responseText == "") {
            alert("图片不存在");
            setTimeout(function () { obj.focus(); }, 100);
        } else {
            $("#tbxPicName").val(htmlobj.responseText);
        }
    });

    $("#tbxChkId").change(function () {
        var obj;
        obj = $(this);
        htmlobj = $.ajax({ url: "AJAX.aspx?a=" + new Date() + "&kbn=chk_method&chk_id=" + $(this).val(), async: false });
        if (htmlobj.responseText == "") {
            alert("检查ID不存在");
            setTimeout(function () { obj.focus(); }, 100);
        } else {
            $("#tbxChkName").val(htmlobj.responseText);
        }
    });

    $("#tbxToolId").change(function () {
        var obj;
        obj = $(this);
        htmlobj = $.ajax({ url: "AJAX.aspx?a=" + new Date() + "&kbn=tool&tool_id=" + $(this).val() + "&line_id=" + $("#tbxLineId").val(), async: false });
        if (htmlobj.responseText == "") {
            alert("治具不存在");
            setTimeout(function () { obj.focus(); }, 100);
        } else {
            $("#tbxKjExplain").val(htmlobj.responseText);
        }
    });

    $("#btnCopy").click(function () {

        if ($("#tbxTempId_new").val() == "") {
            alert("请输入新模板ID");
            $("#tbxTempId_new").focus();
            return false;
        }

        if ($("#tbxTempId_key").val() == "") {
            alert("检查模板编号");
            $("#tbxTempId_key").focus();
            return false;
        }


        var obj;
        obj = $(this);
        htmlobj = $.ajax({ url: "AJAX.aspx?a=" + new Date() + "&kbn=chk_tmp&temp_id=" + $("#tbxTempId_key").val() + "&line_id=" + $("#tbxLineId").val() + "&temp_id_new=" + $("#tbxTempId_new").val(), async: false });
        if (htmlobj.responseText == "") {
            return true;
        } else if (htmlobj.responseText == "1") {
            alert("复制源不存在");
            return false;
        } else if (htmlobj.responseText == "2") {
            if (confirm("新模板已经存在，要覆盖吗?")) {
                return true;
            } else {
                return false;
            }
        } else if (htmlobj.responseText == "3") {
            alert("新模板名称未登录");
            return false;

        }

    });

    $("#btnChkTemp").click(function () {

        if ($("#tbxLineId_key").val() == "") {
            alert("请输入生产线");
            $("#tbxLineId_key").focus();
            return false;
        }

        if ($("#tbxTempId_key").val() == "") {
            alert("检查模板编号");
            $("#tbxTempId_key").focus();
            return false;
        }

        window.open("ChkTemp.aspx?a=" + new Date() + "&temp_id=" + $("#tbxTempId_key").val() + "&line_id=" + $("#tbxLineId_key").val());
    });


    $("#btnSelect").click(function () {

        if ($("#tbxLineId_key").val() == "") {
            alert("请输入生产线");
            $("#tbxLineId_key").focus();
            return false;
        }

        if ($("#tbxTempId_key").val() == "") {
            alert("检查模板编号");
            $("#tbxTempId_key").focus();
            return false;
        }
    });

});
