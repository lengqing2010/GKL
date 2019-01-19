$(document).ready(function () {

    var pub_chk_no = $("#hidChkNo").val();
    var pub_user = $("#hidInsUser").val();
    var pub_line_id = $("#hidLineId").val();


    var chk_id;
    var kj_0;
    var kj_1;
    var kj_2;
    var chk_method_id;
    var chk_method;
    var chk_formula;
    var pic_old_id;
        pic_old_id = "";

    var pic_id;
    var acText;
    
    var resultTxt;
    var resultCell;
    var thisRow;

    var SC;
    SC = document.getElementById("SC");

    var pub_picture_jq;
    pub_picture_jq = $(".JQ_IMG");

    var pub_select_row;
    var acIn1;
    var acResult;
    var acMark;

    //Init select row's value
    function InitRowValue(inputObj) {        
        thisRow = $(inputObj).parent().parent();
        acText = $(inputObj);
        chk_id = thisRow.attr("chk_id");
        kj_0 = thisRow.attr("kj_0");
        kj_1 = thisRow.attr("kj_1");
        kj_2 = thisRow.attr("kj_2");
        chk_method_id = thisRow.attr("chk_method_id");
        chk_method = thisRow.attr("chk_method");
        chk_formula = thisRow.attr("chk_formula");
        pic_id = thisRow.attr("pic_id");

        acIn1 = thisRow.find(".jq_in1");
        acResult = thisRow.find(".jq_result");
        acMark = thisRow.find(".jq_mark");

        if (pic_old_id != pic_id) {
            pub_picture_jq.show(300);
            pub_picture_jq.attr("src", "Img.aspx?pic_id=" + pic_id + "&line_id=" + $("#hidLineIdKey").text());
            pic_old_id = pic_id;
        }

    }

    //统计检查明细结果
    check_setume_txt();

    //行设置
    $(".jq_result").attr("readonly", "readonly");
    $(".jq_ms tr").each(function () {

        chk_method = $(this).attr("chk_method");

        if (chk_method == "1") {        //SCAN
            $(this).find(".jq_in1").css('background-color', '#ffff66');
            $(this).find(".jq_in1").attr("readonly", "readonly");
        } else if (chk_method == "2") { //固定
            $(this).find(".jq_in1").css('background-color', '#CCC');            
            $(this).find(".jq_in1").attr("readonly", "readonly");
            $(this)[0].readOnly = true;
        }

        resultCell = $(this).find(".jq_result");
        resultTxt = resultCell.val();

        if (resultTxt == "OK") {
            resultCell.css('background-color', 'green');
        } else if (resultTxt == "NG") {
            resultCell.css('background-color', 'red');
        }

    });

    //图片操作
    $(".JQ_IMG").mousedown(function () {
        $(this).css('width', '100%');
    });

    $(".JQ_IMG").mouseup(function () {
        $(this).css('width', '');
    });





    //入力値１
    $(".jq_in1").focus(function () {
        InitRowValue(this);
        TextFocusStyle($(this));
    });
    $(".jq_in1").blur(function () {
        TextBlurStyle($(this));
    });
    $(".jq_in1").keydown(function () {
        if (chk_method == "0") { //INPUT
            if (event.keyCode == 13) {
                if (GetChkMethodStr(chk_formula, $(this))) {
                    SetResult(true, $(this));
                } else {
                    SetResult(false, $(this));
                }
            }

        } else if (chk_method == "1") { //SCAN
            if (event.keyCode == 119) {
                SC.value = "";
                SC.focus();
                acText = $(this);
            }

        }

    });

    //备考
    $(".jq_mark").focus(function () {
        InitRowValue(this);
        TextFocusStyle($(this));
    });
    $(".jq_mark").blur(function () {
        TextBlurStyle($(this));

        AjaxPostMsUpd(thisRow.find(".jq_in1").val()
            , thisRow.find(".jq_result").val()
            , thisRow.find(".jq_mark").val());
    });

    $(".keyboard").find("td").click(function () {
        var obj;
        obj = $(this);
        obj.css('background-color', '#ccc');
        setTimeout(function () {
            obj.css('background-color', '#5CACEE');
        }, 200);
    });
    
    //小键盘
    $(".keyboard").find("td").mouseup(function () {

        var ky = $(this).text();

        if (ky == "OK" || ky == "NG") {
            if (ky == "OK") {
                acResult.css('background-color', 'green');
            } else {
                acResult.css('background-color', 'red');
            }
            acResult.val(ky);
            AjaxPostMsUpd(acIn1.val(), ky, acMark.val());
            SetNextFocus(acIn1);

        } else if (ky == "回车") {
            if (chk_method != "2") {
                if (GetChkMethodStr(chk_formula, acIn1)) {
                    SetResult(true, acIn1);
                } else {
                    SetResult(false, acIn1);
                }
            }

        } else if (ky == "删除") {
            $(acText).val("");

        } else {
            $(acText).val($(acText).val() + ky + '');
            $(acText).focus();

        }
    });

    $(SC).keydown(function () {
        if (event.keyCode == 13) {
            try {
                acText.val(SC.value);
                if (GetChkMethodStr(chk_formula, $(this))) {
                    SetResult(true, acIn1);
                } else {
                    SetResult(false, acIn1);
                }
                SC.value = "";
            } catch (e) {
            }
            event.keyCode = 0;
            return false;
        }
    });


    function SetResult(rlt, jq_e) {

        acIn1 = thisRow.find(".jq_in1");
        acResult = thisRow.find(".jq_result");
        acMark = thisRow.find(".jq_mark");

        if (rlt) {
            acResult.css('background-color', 'green');
            acResult.val("OK");
            AjaxPostMsUpd(jq_e.val(), "OK", acMark.val());

        } else {
            acResult.css('background-color', 'red');
            acResult.val("NG");
            AjaxPostMsUpd(jq_e.val(), "NG", acMark.val());

        }

        SetNextFocus(jq_e);
        //alert();
    }

    //选择下一行
    function SetNextFocus(jq_e) {
        if (thisRow.next().length > 0) {
            thisRow = thisRow.next();
            InitRowValue(thisRow.find(".jq_in1")[0]);
        }
        
        try {
            acIn1.focus();
        } catch (e) {
        }
    }


    function GetChkMethodStr(chk_formula, jq_e) {
        var str;
        var value;
        value = jq_e.val()
        str = chk_formula;
        str = str.replace("{in1}", value).replace("{in1}", value).replace("{in1}", value).replace("{in1}", value).replace("{in1}", value);
        str = str.replace("{kj0}", kj_0).replace("{kj0}", kj_0).replace("{kj0}", kj_0).replace("{kj0}", kj_0).replace("{kj0}", kj_0);
        str = str.replace("{kj1}", kj_1).replace("{kj1}", kj_1).replace("{kj1}", kj_1).replace("{kj1}", kj_1).replace("{kj1}", kj_1);
        str = str.replace("{kj2}", kj_2).replace("{kj2}", kj_2).replace("{kj2}", kj_2).replace("{kj2}", kj_2).replace("{kj2}", kj_2);

        try {
            if (eval(str)) {
                return true;
            } else {
                return false;
            }
        } catch (e) {
            alert(e.message);
            return false;
        }
    }





    function ChkInput(jq_e) {
        var value;
        value = jq_e.val();


    }

    function TextFocusStyle(jq_e) {
        jq_e.css('border-color', 'red');
        jq_e.css('border-width', '2px');
    }

    function TextBlurStyle(jq_e) {
        jq_e.css('border-color', '#000');
        jq_e.css('border-width', '1px');
    }

    //统计检查明细结果
    function check_setume_txt() {
        var okSuu = $(".jq_result:[value='NG']").length;
        var ngSuu = $(".jq_result:[value='OK']").length;
        $("#lblSou").text("NG:" + ngSuu + "  OK:" + okSuu + "  全部:" + (okSuu + ngSuu));
    }

    //更新检查明细
    function AjaxPostMsUpd(in1, chkResult, mark) {
        $("#btnComplete").attr("disabled", true);
        $("#btnModoru").attr("disabled", true);
        $.ajax({
            type: 'POST',
            url: 'AJAX.aspx?kbn=chk_ms_upd',
            async: true, //true:yibu
            data: {
                chkNo_key: pub_chk_no,
                in1: in1,
                chkResult: chkResult,
                mark: mark,
                kj0: kj_0,
                kj1: kj_1,
                kj2: kj_2,
                insUser: pub_user,
                line_id: pub_line_id,
                chk_method_id: chk_method_id
            },
            datatype: 'html', //'xml', 'html', 'script', 'json', 'jsonp', 'text'.
            beforeSend: function () { },
            //when success
            success: function (data) {
                check_setume_txt();
                $("#btnComplete").removeAttr("disabled");
                $("#btnModoru").removeAttr("disabled");
            },
            //when complete
            complete: function (XMLHttpRequest, textStatus) {
            },
            //when error
            error: function () { alert('明显更新错误'); }
        });
    }
    $(document).keydown(function () {
        if (event.keyCode == 13) {
            event.keyCode = 10;
            return false;
        }
    });

});