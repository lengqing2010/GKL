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



$(document).ready(function () {

    var chk_id;
    var kj_0;
    var kj_1;
    var kj_2;
    var chk_method_id;
    var chk_method;
    var chk_formula;


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

    });

    //入力値１
    $(".jq_in1").focus(function () {
        var thisRow;
        thisRow = $(this).parent().parent();
        var obj;
        obj = $(this);

        chk_id = thisRow.attr("chk_id");
        kj_0 = thisRow.attr("kj_0");
        kj_1 = thisRow.attr("kj_1");
        kj_2 = thisRow.attr("kj_2");
        chk_method_id = thisRow.attr("chk_method_id");
        chk_method = thisRow.attr("chk_method");
        chk_formula = thisRow.attr("chk_formula");

        TextFocusStyle($(this));

        if (chk_method == "0") {        //INPUT

        } else if (chk_method == "1") { //SCAN
       
            SetReadOnly($(this)[0]);
            return false;

        } else if (chk_method == "2") { //固定

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
                RemoveReadOnly($(this)[0]);
                $(this)[0].select();

                
            } else if (event.keyCode == 13) {

                SetReadOnly($(this)[0]);
                $(this)[0].select();
                if (GetChkMethodStr(chk_formula,$(this))) {
                    SetResult(true,$(this));
                } else {                    
                    SetResult(false,$(this));
                }
            }

        } else if (chk_method == "2") { //固定

        }

        if (event.keyCode == 13) {
            return false;
        }
    });

    function SetResult(rlt, jq_e) {
        if (rlt) {
            jq_e.parent().parent().find(".jq_result").css('background-color', 'green');
            jq_e.parent().parent().find(".jq_result").val("OK");
        } else {
            jq_e.parent().parent().find(".jq_result").css('background-color', 'red');
            jq_e.parent().parent().find(".jq_result").val("NG");
        }

        SetNextFocus(jq_e);
        //alert();
    }

    function SetNextFocus(jq_e) {
        jq_e.parent().parent().next().find(".jq_in1").focus();
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
