﻿/*===============================================================*/
/*    関数  ：Enterキーフォーカス移動 , Trim Right               */
/*                                                               */
/*                                                               */
/*    引数  ：                                                   */
/*    履歴  ：                                                   */
/*===============================================================*/
function KeyEnter() {
    //Enter　Key時	
    if (event.keyCode == 13) {
        //Text　AREA　OK
        if (event.srcElement.type == 'textarea') {
            return true;
        }
        //ボタン　　　OK
        if (event.srcElement.type == 'submit' || event.srcElement.type == 'button') {
            event.keyCode = 0;
            return true;
        }
        //Link　　　　OK
        if (event.srcElement.tagName == 'A') {
            event.keyCode = 0;
            return true;
        }
        //上記以外　Tab　Key           
        event.keyCode = 9;
        var e = event ? event : window.event;
        var form = document.getElementById('form1');
        if (e.keyCode == 13) {
            var tabindex = document.activeElement.getAttribute('tabindex');
            tabindex++;
            var inputs = form.getElementsByTagName('input');
            for (var i = 0, j = inputs.length; i < j; i++) {
                if (inputs[i].getAttribute('tabindex') == tabindex) {
                    inputs[i].focus();
                    break;
                }
            }

            inputs = form.getElementsByTagName('select');
            for (var i = 0, j = inputs.length; i < j; i++) {
                if (inputs[i].getAttribute('tabindex') == tabindex) {
                    inputs[i].focus();
                    break;
                }
            }
        }
        return false;
    }

    return true;
}

String.prototype.Trim = function () {
    var value = this.replace(/^\s+|\s+$/g, "");
    return value.replace(/(^　*)|(　*$)/g, "");
}

function right(mainStr, lngLen) {
    if (mainStr.length - lngLen >= 0 && mainStr.length >= 0 && mainStr.length - lngLen <= mainStr.length) {
        return mainStr.substring(mainStr.length - lngLen, mainStr.length)
    } else {
        return null
    }
}

function m_chkFoundSymbol(strInput) {
    var char1;
    for (i = 0; i < strInput.length; i++) {
        char1 = strInput.charAt(i);
        if (char1 == "'" || char1 == '"' || char1 == "&" || char1 == '<' || char1 == '>' || char1 == ',') {
            return true;
            break;
        }
    }
    return false;
}

function fncGetLengthB(data, keta) {
    var ch1;
    var ch2;
    var intLen = 0;
    var wkstr = data;
    for (i = 0; i < wkstr.length; i++) {
        ch1 = wkstr.charCodeAt(i);
        if (ch1 >= 0 && ch1 <= 255) {
            intLen = intLen + 1;
        } else {
            intLen = intLen + 2;
        }
    }
    if (parseInt(intLen, 10) > parseInt(keta, 10)) {
        return false;
    } else {
        return true
    }
}


/* ****************************************************************************
	関数名 isHalfNumber ()

		作成日 : 1998/3/25 (S.Yano)
		引数   : 1番目   -> チェックする文字列
		戻り値 : true    -> 1番目の引数がすべて半角数値の時
				 false   -> true以外の時

**************************************************************************** */
function isHalfNumber() {
    var i;
    var sBuffer
    if (isHalfNumber.arguments.length != 1) {
        alert("isHalfNumberへの引数の数が間違っています");
        return false;
    }
    for (i = 0; i < isHalfNumber.arguments[0].length; i++) {
        sBuffer = isHalfNumber.arguments[0].substring(i, i + 1);
        if (!(sBuffer >= "0" && sBuffer <= "9")) {
            return false;
        }
    }
    return true;
}


/**
 * マイナス符号付小数点チェックを行います。
 * ・パターンマッチ 0～9、"-"、"."
 * ・パターンマッチ "-","."のみはＮＧ
 * ・マイナス符号の数 0 or 1
 * ・小数点の数 0 or 1
 * ・整数部の桁数チェック
 * ・小数部の桁数チェック
 *
 * 例）整数部 3, 小数部 2の場合
 * -123 --> OK
 * 123 --> OK
 * 123.45 --> OK
 * -123.45 --> OK
 * 1.2 --> OK
 * - --> NG
 * 123- --> NG
 * --123 --> NG
 * 1234.56 --> NG
 * 123.456 --> NG
 * . --> NG
 * .123 --> NG
 * 123. --> NG
 * -. --> NG
 *
 * @param argValue チェック対象文字列
 * @param argIntKetasu 整数部の入力可能桁数
 * @param argDecimalKetasu 小数部の入力可能桁数
 * @return チェックＯＫの場合はtrue、
 * チェックＮＧの場合はfalse
 */
function isMinusDecimal(argValue, argIntKetasu, argDecimalKetasu)
{
    var minusFlg = false;
    var decFlg = false;
    if (argValue.match(/[^0-9|^\-|^.]/g))
    {
        // パターンマッチ 0～9,"-","."以外はＮＧ
        return false;
    }
    if (argValue.match(/[^\-|^.]/g))
    {
    }
    else
    {
        // パターンマッチ "-","."のみはＮＧ
        return false;
    }

    // 小数点の数を取得する
    var count = 0;
    for (var i = 0; i < argValue.length; i++)
    {
        if (argValue.charAt(i) == ".")
        {
            decFlg = true; count++;
        }
    }
    if (2 <= count)
    {
        // "."が２つ以上入力されている場合はＮＧ
        return false;
    }

    // "-"の入力個数を取得する
    count = 0;
    for (i = 0; i < argValue.length; i++)
    {
        if (argValue.charAt(i) == "-")
        {
            minusFlg = true;
            count++;
        }
    }
    if (2 <= count || (count == 1 && argValue.charAt(0) != "-"))
    {
        // "-"が２つ以上入力されている場合はＮＧ
        // "-"が入力されていて、かつ先頭に"-"がない場合はＮＧ
        return false;
    }

    // 小数点以下のチェック
    if (decFlg)
    {
        // 小数点以下の桁数チェック
        var idx = argValue.lastIndexOf(".");
        var decimalPart = argValue.substring(idx);

        // 小数点以下の桁数を取得する
        var length = decimalPart.length - 1;
        if (length == 0)
        {
            // 小数点以下の入力がない場合はＮＧ
            return false;
        }
        if (argDecimalKetasu < length)
        {
            // 小数点以下の桁数がオーバーしている場合はＮＧ
            return false;
        }
    }

    // 整数部の桁数チェック
    var intPart = "";
    length = 0;
    if (decFlg)
    {
        // 小数点が入力された場合
        intPart = argValue.substring(0, argValue.indexOf("."));
    }
    else
    {
        intPart = argValue;
    }
    length = intPart.length;
    if (minusFlg)
    {
        // マイナスが入力された場合は-1
        length--;
    }
    if (argIntKetasu < length)
    {
        // 整数の桁数がオーバーしている場合はＮＧ
        return false;
    }
    return true;
}
 

/*===============================================================*/
/*    関数  ：JQUERY                                             */
/*                                                               */
/*                                                               */
/*    引数  ：                                                   */
/*    履歴  ：                                                   */
/*            2018/09/11 P-53354 李松濤 新規作成                 */
/*===============================================================*/
$("#divKM").hide();

var SelectRow;

$(document).ready(function () {

    $("input").blur(function () {
        var itType = ($(this).attr("itType"));
        var itLength = ($(this).attr("itLength"));
        var itName = ($(this).attr("itName"));
        var v = $(this).val();

        if (v == '') { return true;}

        if (itType == "int" || itType == "smallint" || itType == "tinyint" || itType == "bigint" || itType == "bigint") {

            if (itLength != '') {
                if (v.length > parseInt(itLength, 10)) {
                    alert(itName + 'は' + itLength + '桁以内で入力してください。');
                    $(this)[0].select()
                    return false;
                }
            }
            if (!(isHalfNumber(v))) {
                alert(itName + 'は' + itLength + '桁半角数字で入力してください。');
                $(this)[0].select()
                return false;
            }
        }


         
        if (itType == "decimal" || itType == "numeric" || itType == "float" || itType == "money") {
            var argIntKetasu ;
            var argDecimalKetasu;
            argIntKetasu = 0;
            argDecimalKetasu = 0;

            if (itLength.split(",").length == 2) {

                argIntKetasu = parseInt(itLength.split(",")[0], 10);
                argDecimalKetasu = parseInt(itLength.split(",")[1], 10);

                if (itLength != '') {
                    if (v.length - 1 > argIntKetasu + argDecimalKetasu) {
                        alert(itName + 'は' + itLength + '桁以内で入力してください。');
                        $(this)[0].select()
                        return false;
                    }
                }

                if(!isMinusDecimal(v,argIntKetasu,argDecimalKetasu)){
                    alert(itName + 'は整数' + argIntKetasu + '桁小数' + argDecimalKetasu + '桁で入力してください。');
                    $(this)[0].select()
                    return false;
                }
            } else {
                if (itLength != '') {
                    if (v.length > parseInt(itLength, 10)) {
                        alert(itName + 'は' + itLength + '桁以内で入力してください。');
                        $(this)[0].select()
                        return false;
                    }
                }
                if (!(isHalfNumber(v))) {
                    alert(itName + 'は' + itLength + '桁半角数字で入力してください。');
                    $(this)[0].select()
                    return false;
                }
            }




        }


    });

    //$('input[type="text"]').click(
    //    function () {           
    //        $(this)[0].select();
    //    }
    //);

    /*===============================================================*/
    /*行選択                                 
    /*===============================================================*/
    $(".jq_ms tr").click(function () {
        $('.jq_upd').removeAttr("disabled");
        $('.jq_del').removeAttr("disabled");
        if (SelectRow == null) { } else {
            $(SelectRow).css("background", "#ffffff");
        }
        $(this).css("background", "#ffff66");
        SelectRow = $(this);

        $(this).find("td").each(function () {
            var className = $(this).attr("class");
            var ipt = className + '_ipt';
            $("." + ipt).val($(this).text())

        });
    })

    /*===============================================================*/
    /*明細部↑↓Key 押下                                 
    /*===============================================================*/
    //明細部↑↓
    $(".jq_ms_div").keydown(function (event) {
        if (SelectRow == null) {return true;}

        var keycode = event.which;
        if (keycode == 38) {
            if (SelectRow.prev()) {
                $(".jq_ms_div").scrollTop($(".jq_ms_div").scrollTop() - 21);
                SelectRow.prev().click();
                return false;
            }

        } else if (keycode == 40) {
            if (SelectRow.next()) {
                $(".jq_ms_div").scrollTop($(".jq_ms_div").scrollTop() + 21);
                SelectRow.next().click();
                return false;
            }

        }
    });

});



/*===============================================================*/
/*１１．チェック関数                                  
/*===============================================================*/
//数字
function chkHankakuSuuji(str) {
    var ch;
    var wkstr = str;
    var i;
    for (i = 0; i < wkstr.length; i++) {
        ch = wkstr.substring(i, i + 1);
        if ((ch >= '0' && ch <= '9')) { } else {
            return false;
        }
    }
    return true;
}

//桁数
function fncChkSiteinaiMoji(str, keta) {
    var iLength;
    iLength = str.length;
    if (parseInt(keta, 10) != parseInt(iLength, 10)) {
        return false;
    } else {
        return true;
    }
}


//日付チェック
function GetDateFormat(e) {
    var v;
    var Y;
    var M;
    var D;
    Y = "";
    M = "";
    D = "";
    v = SetDateNoSign(e.value, " ");

    if (v.split("/").length == 3) {
        Y = v.split("/")[0];
        M = v.split("/")[1];
        D = v.split("/")[2];

    } else if (v.split("-").length == 3) {
        Y = v.split("-")[0];
        M = v.split("-")[1];
        D = v.split("-")[2];
    } else {

        v = SetDateNoSign(v, "/");
        v = SetDateNoSign(v, "-");

        if (v.length == 6) { //6桁の場合
            if (v.substring(0, 2) > 70) {
                v = "19" + v;
            } else {
                v = "20" + v;
            }

        } else if (v.length == 4) { //4桁の場合
            dd = new Date();
            v = dd.getFullYear() + v;

        }

        if (v.length == 8) {
            Y = v.substring(0, 4);
            M = v.substring(4, 6);
            D = v.substring(6, 8);
        }
    }

    if (Y.length == 2 && Y.substring(0, 2) > 70) {
        Y = "19" + Y;
    }

    if (Y.length == 2 && Y.substring(0, 2) <= 70) {
        Y = "20" + Y;
    }

    if (Y == 'undefined' || Y == undefined || M == 'undefined' || M == undefined || D == 'undefined' || D == undefined || M.length > 2 || D.length > 2 || Y.length == 3) {
        return false;
    }


    if (M.length == 1) {
        M = "0" + M;
    }
    if (D.length == 1) {
        D = "0" + D;
    }

    if (!checkDateVali(Y, M, D) || Y < "1753") {
        return false;

    } else {
        e.value = Y + "/" + M + "/" + D;
        return Y + "/" + M + "/" + D;

    }
}

function SetDateNoSign(value, sign) {

    var arr;
    var strResult = "";
    arr = value.split(sign);

    var i;

    for (i = 0; i <= arr.length - 1; i++) {
        if (arr[i].length == 1) {
            arr[i] = "0" + arr[i];
        }
    }

    strResult = arr.join("");
    strResult = strResult == "" ? value : strResult;

    return strResult;
}

function checkDateVali(y, m, d) {
    var di = new Date(y, m - 1, d);
    if (di.getFullYear() == y && di.getMonth() == m - 1 && di.getDate() == d) {
        return true;
    }
    return false;
}



/*===============================================================*/
/*１２．ボタン使用不可関数                                  
/*===============================================================*/

var processing = false;
var isCsv = false;

function disableButton() {
    if (isCsv) {
        isCsv = false;

    } else {
        setTimeout('disableAfterTimeout()', 0);
        processing = true;
        return true;

    }

}

function disableAfterTimeout() {
    for (var i = 0; i < document.forms.length; i++) {
        c_form = document.forms[i];
        for (var j = 0; j < c_form.elements.length; j++) {
            if (c_form.elements[j].type == 'submit' || c_form.elements[j].type == 'button' || c_form.elements[j].type == 'radio') {
                c_form.elements[j].disabled = true;
            }
        }
    }
}
window.onactivate = function () {
    return disableButton();
}

﻿/*===============================================================*/
/*    関数  ：Enterキーフォーカス移動 , Trim Right               */
/*                                                               */
/*                                                               */
/*    引数  ：                                                   */
/*    履歴  ：                                                   */
/*===============================================================*/
function KeyEnter() {
    //Enter　Key時	
    if (event.keyCode == 13) {
        //Text　AREA　OK
        if (event.srcElement.type == 'textarea') {
            return true;
        }
        //ボタン　　　OK
        if (event.srcElement.type == 'submit' || event.srcElement.type == 'button') {
            event.keyCode = 0;
            return true;
        }
        //Link　　　　OK
        if (event.srcElement.tagName == 'A') {
            event.keyCode = 0;
            return true;
        }
        //上記以外　Tab　Key           
        event.keyCode = 9;
        var e = event ? event : window.event;
        var form = document.getElementById('form1');
        if (e.keyCode == 13) {
            var tabindex = document.activeElement.getAttribute('tabindex');
            tabindex++;
            var inputs = form.getElementsByTagName('input');
            for (var i = 0, j = inputs.length; i < j; i++) {
                if (inputs[i].getAttribute('tabindex') == tabindex) {
                    inputs[i].focus();
                    break;
                }
            }

            inputs = form.getElementsByTagName('select');
            for (var i = 0, j = inputs.length; i < j; i++) {
                if (inputs[i].getAttribute('tabindex') == tabindex) {
                    inputs[i].focus();
                    break;
                }
            }
        }
        return false;
    }

    return true;
}

String.prototype.Trim = function () {
    var value = this.replace(/^\s+|\s+$/g, "");
    return value.replace(/(^　*)|(　*$)/g, "");
}

function right(mainStr, lngLen) {
    if (mainStr.length - lngLen >= 0 && mainStr.length >= 0 && mainStr.length - lngLen <= mainStr.length) {
        return mainStr.substring(mainStr.length - lngLen, mainStr.length)
    } else {
        return null
    }
}

function m_chkFoundSymbol(strInput) {
    var char1;
    for (i = 0; i < strInput.length; i++) {
        char1 = strInput.charAt(i);
        if (char1 == "'" || char1 == '"' || char1 == "&" || char1 == '<' || char1 == '>' || char1 == ',') {
            return true;
            break;
        }
    }
    return false;
}

function fncGetLengthB(data, keta) {
    var ch1;
    var ch2;
    var intLen = 0;
    var wkstr = data;
    for (i = 0; i < wkstr.length; i++) {
        ch1 = wkstr.charCodeAt(i);
        if (ch1 >= 0 && ch1 <= 255) {
            intLen = intLen + 1;
        } else {
            intLen = intLen + 2;
        }
    }
    if (parseInt(intLen, 10) > parseInt(keta, 10)) {
        return false;
    } else {
        return true
    }
}

/*===============================================================*/
/*    関数  ：JQUERY                                             */
/*                                                               */
/*                                                               */
/*    引数  ：                                                   */
/*    履歴  ：                                                   */
/*            2018/09/11 P-53354 李松濤 新規作成                 */
/*===============================================================*/
$("#divKM").hide();

var SelectRow;

$(document).ready(function () {

    //Page post 後、行選択
    if ($(".jq_hidOldRowIdx").val() != '') {
        var oldIdx = parseInt($(".jq_hidOldRowIdx").val(), 10);
        SelectRow = $($(".jq_ms").find("tr")[oldIdx]);
        SelectRow.css("background", "#ffff66");
    }
    
    /*===============================================================*/
    /*行選択                                 
    /*===============================================================*/
    $(".jq_ms tr").click(function () {
        $('.jq_upd').removeAttr("disabled");
        $('.jq_del').removeAttr("disabled");
        if (SelectRow == null) { } else {
            $(SelectRow).css("background", "#ffffff");
        }
        $(this).css("background", "#ffff66");
        SelectRow = $(this);

        $(".jq_hidOldRowIdx").val($(this).parent().find("tr").index($(this)[0]));
        //alert($(".jq_hidOldRowIdx").text());

        $(this).find("td").each(function () {
            var className = $(this).attr("class");
            var ipt = className + '_ipt';
            $("." + ipt).val($(this).text())

        });
    })

    /*===============================================================*/
    /*明細部↑↓Key 押下                                 
    /*===============================================================*/
    //明細部↑↓
    $(".jq_ms_div").keydown(function (event) {
        if (SelectRow == null) {return true;}

        var keycode = event.which;
        if (keycode == 38) {
            if (SelectRow.prev()) {
                $(".jq_ms_div").scrollTop($(".jq_ms_div").scrollTop() - 21);
                SelectRow.prev().click();
                return false;
            }

        } else if (keycode == 40) {
            if (SelectRow.next()) {
                $(".jq_ms_div").scrollTop($(".jq_ms_div").scrollTop() + 21);
                SelectRow.next().click();
                return false;
            }

        }
    });

    $(".jq_ms_div").scroll(function () {
        $(".jq_title_div").scrollLeft($(".jq_ms_div").scrollLeft());
    });

});



/*===============================================================*/
/*１１．チェック関数                                  
/*===============================================================*/
//数字
function chkHankakuSuuji(str) {
    var ch;
    var wkstr = str;
    var i;
    for (i = 0; i < wkstr.length; i++) {
        ch = wkstr.substring(i, i + 1);
        if ((ch >= '0' && ch <= '9')) { } else {
            return false;
        }
    }
    return true;
}

//桁数
function fncChkSiteinaiMoji(str, keta) {
    var iLength;
    iLength = str.length;
    if (parseInt(keta, 10) != parseInt(iLength, 10)) {
        return false;
    } else {
        return true;
    }
}


//日付チェック
function GetDateFormat(e) {
    var v;
    var Y;
    var M;
    var D;
    Y = "";
    M = "";
    D = "";
    v = SetDateNoSign(e.value, " ");

    if (v.split("/").length == 3) {
        Y = v.split("/")[0];
        M = v.split("/")[1];
        D = v.split("/")[2];

    } else if (v.split("-").length == 3) {
        Y = v.split("-")[0];
        M = v.split("-")[1];
        D = v.split("-")[2];
    } else {

        v = SetDateNoSign(v, "/");
        v = SetDateNoSign(v, "-");

        if (v.length == 6) { //6桁の場合
            if (v.substring(0, 2) > 70) {
                v = "19" + v;
            } else {
                v = "20" + v;
            }

        } else if (v.length == 4) { //4桁の場合
            dd = new Date();
            v = dd.getFullYear() + v;

        }

        if (v.length == 8) {
            Y = v.substring(0, 4);
            M = v.substring(4, 6);
            D = v.substring(6, 8);
        }
    }

    if (Y.length == 2 && Y.substring(0, 2) > 70) {
        Y = "19" + Y;
    }

    if (Y.length == 2 && Y.substring(0, 2) <= 70) {
        Y = "20" + Y;
    }

    if (Y == 'undefined' || Y == undefined || M == 'undefined' || M == undefined || D == 'undefined' || D == undefined || M.length > 2 || D.length > 2 || Y.length == 3) {
        return false;
    }


    if (M.length == 1) {
        M = "0" + M;
    }
    if (D.length == 1) {
        D = "0" + D;
    }

    if (!checkDateVali(Y, M, D) || Y < "1753") {
        return false;

    } else {
        e.value = Y + "/" + M + "/" + D;
        return Y + "/" + M + "/" + D;

    }
}

function SetDateNoSign(value, sign) {

    var arr;
    var strResult = "";
    arr = value.split(sign);

    var i;

    for (i = 0; i <= arr.length - 1; i++) {
        if (arr[i].length == 1) {
            arr[i] = "0" + arr[i];
        }
    }

    strResult = arr.join("");
    strResult = strResult == "" ? value : strResult;

    return strResult;
}

function checkDateVali(y, m, d) {
    var di = new Date(y, m - 1, d);
    if (di.getFullYear() == y && di.getMonth() == m - 1 && di.getDate() == d) {
        return true;
    }
    return false;
}



/*===============================================================*/
/*１２．ボタン使用不可関数                                  
/*===============================================================*/

var processing = false;
var isCsv = false;

function disableButton() {
    if (isCsv) {
        isCsv = false;

    } else {
        setTimeout('disableAfterTimeout()', 0);
        processing = true;
        return true;

    }

}

function disableAfterTimeout() {
    for (var i = 0; i < document.forms.length; i++) {
        c_form = document.forms[i];
        for (var j = 0; j < c_form.elements.length; j++) {
            if (c_form.elements[j].type == 'submit' || c_form.elements[j].type == 'button' || c_form.elements[j].type == 'radio') {
                c_form.elements[j].disabled = true;
            }
        }
    }
}

window.onactivate = function () {
    return disableButton();
}



function WaitPanelShow(msg) {
    var h = document.body.clientHeight;
    if (msg == '') {
        msg = '実行中です、しばらくお待ち下さい';
    }
    $("<div class=\"datagrid-mask\">"+msg+"</div>").css({ display: "block", width: "100%", height: h }).appendTo("body");
}

function WaitPanelRemove() {
    setTimeout(function () {
        $('.datagrid-mask').remove();
    }, 0);
}