$(document).ready(function () {

    var chk_id;
    var kj_0;
    var kj_1;
    var kj_2;
    var chk_method_id;
    var chk_method;
    var chk_formula;
    var pic_id;
    var acText;

    var ScanText;
    ScanText = document.getElementById("ScanText");
    check_setume_txt();
    $(".jq_ms tr").each(function () {

        chk_method = $(this).attr("chk_method");
        var obj;
        obj = $(this);

        if (chk_method == "0") {        //INPUT

        } else if (chk_method == "1") { //SCAN
            $(this).find(".jq_in1").css('background-color', '#ffff66');
            $(this).find(".jq_in1").attr("readonly", "readonly");
        } else if (chk_method == "2") { //固定
            $(this).find(".jq_in1").css('background-color', '#CCC');
            obj[0].readOnly = true;
            $(this).find(".jq_in1").attr("readonly", "readonly");
        }

        var resultCell;
        resultCell = $(this).find(".jq_result");
        if (resultCell.val() == "OK") {
            resultCell.css('background-color', 'green');
        } else if (resultCell.val() == "NG") {
            resultCell.css('background-color', 'red');
        }

    });

    function check_setume_txt() {
        var okSuu;
        var NGSuu;
        var allSuu;
        okSuu = 0;
        allSuu = 0;
        NGSuu = 0;
        $(".jq_result").each(function () {
            if ($(this).val() == "OK") {
                okSuu++;
            } else if ($(this).val() == "NG") {
                NGSuu++;
            } else {
               // kuhakuSuu++;
            }
            allSuu++;
        });
        $("#lblSou").text("NG：" + NGSuu + "， OK：" + okSuu + " ，全部：" + allSuu);

        if (allSuu == okSuu) {
            $("#lblSou").css('color', 'green');
        } else {
            $("#lblSou").css('color', 'red');
        }
    }




    function AjaxPostMsUpd(in1,chkResult,mark) {
        $.ajax({
            type: 'POST',
            url: 'AJAX.aspx?kbn=chk_ms_upd',
            async: true, //true:yibu
            data: {
                chkNo_key:$("#hidChkNo").val()
                ,in1:in1
                ,chkResult:chkResult
                ,mark:mark
                ,kj0:kj_0
                ,kj1:kj_1
                ,kj2:kj_2
                , insUser: $("#hidInsUser").val()
                , line_id: $("#hidLineId").val()
                , chk_method_id: chk_method_id
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
                //alert(textStatus);
            },
            //when error
            error: function () {
            }
        });
    }

    //入力値１
    $(".jq_in1").focus(function () {
        var thisRow;
        thisRow = $(this).parent().parent();
        var obj;
        obj = $(this);
        acText = $(this);

        chk_id = thisRow.attr("chk_id");
        kj_0 = thisRow.attr("kj_0");
        kj_1 = thisRow.attr("kj_1");
        kj_2 = thisRow.attr("kj_2");
        chk_method_id = thisRow.attr("chk_method_id");
        chk_method = thisRow.attr("chk_method");
        chk_formula = thisRow.attr("chk_formula");
        pic_id = thisRow.attr("pic_id");

        if (pic_id == "") {
            $(".JQ_IMG").hide();
        } else {
            $(".JQ_IMG").show(300);
            $(".JQ_IMG").attr("src", "Img.aspx?pic_id=" + pic_id + "&line_id=" + $("#lblLine_id").text());
        }
        
        $(".JQ_IMG").mousedown(function () {
            $(this).css('width', '100%');
        });
        $(".JQ_IMG").mouseup(function () {
            $(this).css('width', '');
        });
       

        TextFocusStyle($(this));

        if (chk_method == "0") {        //INPUT

        } else if (chk_method == "1") { //SCAN
       
            SetReadOnly($(this)[0]);
            return false;

        } else if (chk_method == "2") { //固定

        }

    });

    $(".keyboard").find("td").mouseup(function () {
        var thisRow;
        thisRow = $(acText).parent().parent();
        var obj;
        obj = $(acText);
        var jq_e;
        jq_e = $(acText);
        var ky;
        ky = $(this).text();

        chk_id = thisRow.attr("chk_id");
        kj_0 = thisRow.attr("kj_0");
        kj_1 = thisRow.attr("kj_1");
        kj_2 = thisRow.attr("kj_2");
        chk_method_id = thisRow.attr("chk_method_id");
        chk_method = thisRow.attr("chk_method");
        chk_formula = thisRow.attr("chk_formula");
        pic_id = thisRow.attr("pic_id");

        var tbxMark;
        tbxMark = $(acText).parent().parent().find(".jq_mark").val();
        var resultCell;
        resultCell = $(acText).parent().parent().find(".jq_result");

        if (ky == "OK" || ky == "NG") {
            if (ky == "OK") {
                resultCell.css('background-color', 'green');
            } else {
                resultCell.css('background-color', 'red');
            }
            resultCell.val(ky);
            AjaxPostMsUpd(jq_e.val(), ky, tbxMark);
            SetNextFocus(jq_e);
        } else if (ky == "回车") {
            if (chk_method != "2") {
                if (GetChkMethodStr(chk_formula, $(acText))) {
                    SetResult(true, $(acText));
                } else {
                    SetResult(false, $(acText));
                }
            }

        } else if (ky == "删除") {
            $(acText).val("");

        } else {
            $(acText).val($(acText).val() + ky + '');
            $(acText).focus();

        }


        check_setume_txt();


    });

    $(ScanText).keydown(function () {
        if (event.keyCode == 13) {
            try{
                acText.val(ScanText.value);
                ScanText.value = "";
                if (GetChkMethodStr(chk_formula, $(this))) {
                    SetResult(true, $(acText));
                } else {
                    SetResult(false, $(acText));
                }
            }catch(e){

            }
            event.keyCode = 0;
            return false;
        }        
    });

    $(".jq_in1").keydown(function () {
        var obj;
        obj = $(this);

        if (chk_method == "0") {        //INPUT
            if (event.keyCode == 13) {
                if (GetChkMethodStr(chk_formula, $(this))) {
                    SetResult(true, $(this));
                } else {
                    SetResult(false, $(this));
                }
            }

        } else if (chk_method == "1") { //SCAN
            if (event.keyCode == 119) {
                ScanText.value = "";
                ScanText.focus();
                acText = $(this);
                check_setume_txt();
            }

        } else if (chk_method == "2") { //固定

        }

        if (event.keyCode == 13) {
            return false;
        }
    });

    function SetResult(rlt, jq_e) {

        var tbxMark;
        tbxMark = jq_e.parent().parent().find(".jq_mark").val();

        var resultCell;
        resultCell = jq_e.parent().parent().find(".jq_result");

        if (rlt) {
            resultCell.css('background-color', 'green');
            resultCell.val("OK");
            AjaxPostMsUpd(jq_e.val(), "OK", tbxMark);
            
        } else {
            resultCell.css('background-color', 'red');
            resultCell.val("NG");
            AjaxPostMsUpd(jq_e.val(), "NG", tbxMark);

        }

        SetNextFocus(jq_e);
        //alert();
    }

    function SetNextFocus(jq_e) {

        var thisRow;
        thisRow = jq_e.parent().parent().next();

        var nextIn1;
        nextIn1 = thisRow.find(".jq_in1")[0];

        var obj;
        obj = $(this);

        chk_id = thisRow.attr("chk_id");
        kj_0 = thisRow.attr("kj_0");
        kj_1 = thisRow.attr("kj_1");
        kj_2 = thisRow.attr("kj_2");
        chk_method_id = thisRow.attr("chk_method_id");
        chk_method = thisRow.attr("chk_method");
        chk_formula = thisRow.attr("chk_formula");


        if (chk_method != "0") {        //INPUT
            RemoveReadOnly($(nextIn1));
            try{
                nextIn1.focus();
            } catch (e) {

            }
            
            SetReadOnly($(nextIn1));

        } else {
            $(nextIn1).focus();
        }
        
    }


    function DebugMsg (msg){

        $("#lblMsg").text(msg);
    }

    function SetReadOnly(e) {
        e.readOnly = true;
    }
    function RemoveReadOnly(e) {
        e.readOnly = false;
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

        try{
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


    $(".jq_in1").blur(function () {
        TextBlurStyle($(this));
    });


    function ChkInput(jq_e) {
        var value;
        value = jq_e.val();


    }

    function TextFocusStyle(jq_e) {
        jq_e.css('border-color', 'red');
    }

    function TextBlurStyle(jq_e) {
        jq_e.css('border-color', '#000');
    }
    //var SelectRow=null;
    ///*===============================================================*/
    ///*行選択                                 
    ///*===============================================================*/
    //$(".jq_ms tr").click(function () {
    //    if (SelectRow != null){$(SelectRow).css("background", "#ffffff");}
    //    $(this).css("background", "#ffff66");
    //    SelectRow = $(this);
    //})

    ///*===============================================================*/
    ///*明細部↑↓Key 押下                                 
    ///*===============================================================*/
    ////明細部↑↓
    //$(".jq_ms_div").keydown(function (event) {
    //    if (SelectRow == null) { return true; }

    //    var keycode = event.which;
    //    if (keycode == 38) {
    //        if (SelectRow.prev()) {
    //            $(".jq_ms_div").scrollTop($(".jq_ms_div").scrollTop() - 21);
    //            SelectRow.prev().click();
    //            return false;
    //        }

    //    } else if (keycode == 40) {
    //        if (SelectRow.next()) {
    //            $(".jq_ms_div").scrollTop($(".jq_ms_div").scrollTop() + 21);
    //            SelectRow.next().click();
    //            return false;
    //        }

    //    }
    //});

});
