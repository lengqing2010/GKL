$(document).ready(function () {

    var okSuu=0;
    var ngSuu = 0;
    var allSuu = 0;
    var completeSuu = 0;

    $(".jq_ms tr").each(function () {
        chk_method = $(this).attr("chk_method");
        if ($(this).find("td")[6].innerText == "NG") {
            $($(this).find("td")[6]).css('background-color', 'red');
        } else if ($(this).find("td")[6].innerText == "OK") {
            $($(this).find("td")[6]).css('background-color', 'green');
        }
    });



    check_setume_txt();

    //统计检查明细结果
    function check_setume_txt() {
        var okSuu = 0;
        var ngSuu = 0;
        var allSuu = 0;
        var completeSuu = 0;

        $(".jq_ms tr").each(function () {
            if ($(this).find("td")[6].innerText == "NG") {
                ngSuu++;
            } else if ($(this).find("td")[6].innerText == "OK") {
                okSuu++;
            }
            allSuu++;
            if ($(this).find("td")[9].innerText == "完了") {
                completeSuu++;
            }
        });

        $("#lblSou").text("【NG】:" + ngSuu + "--【OK】:" + okSuu + "--【完了】:" + completeSuu + "--【全部】:" + allSuu);

        if (okSuu == allSuu) {
            $("#lblSou").css('color', 'green');
        } else {
            $("#lblSou").css('color', 'red');
        }
    }

    //$('.jq_upd')[0].disabled = true;
    //$('.jq_del')[0].disabled = true;
    //$('#btnComlete')[0].disabled = true;

    DisabledIt($('.jq_upd')[0]);
    DisabledIt($('.jq_del')[0]);
    DisabledIt($('#btnComlete')[0]);

    $(".jq_ms tr").click(function () {
        //
        if ($(this)[0].innerText.indexOf("待检查") == -1) {
            UndisabledIt($('.jq_upd')[0]);
            UndisabledIt($('.jq_del')[0]);
            UndisabledIt($('#btnComlete')[0]);


        } else {
            DisabledIt($('.jq_upd')[0]);
            DisabledIt($('.jq_del')[0]);
            DisabledIt($('#btnComlete')[0]);

        }
  
    })



    //disabledIt($("#tbxLineId_key"));
    
    //图片Disable
    DisabledIt($("#lblUserName"));
    $("#lblUserName").attr("tabindex", "-1");

    document.onsubmit = function () {
        UndisabledIt($("#lblUserName"));
    }


    $("#btnPreDay").click(function () {

        var myDate;
        var newDate;
        if ($("#tbxDate_key").val() == "") {
            var curDate = new Date();
            $("#tbxDate_key").val(curDate.getFullYear() + '/' + (curDate.getMonth()+1) + '/' + curDate.getDate());
            GetDateFormat($("#tbxDate_key")[0]);
            $("#btnSelect")[0].click();
            return true;
        }
        
        myDate = $("#tbxDate_key").val();
        

        if (myDate != "") {
            myDate.split("/");
            newDate = new Date(myDate.split("/")[0], myDate.split("/")[1], myDate.split("/")[2]);
            newDate = new Date(newDate.getTime() - 24 * 60 * 60 * 1000);
            $("#tbxDate_key").val(newDate.getFullYear() + '/' + (newDate.getMonth()) + '/' + newDate.getDate());

            GetDateFormat($("#tbxDate_key")[0]);
            $("#btnSelect")[0].click();
        }

    });


    $("#btnNextDay").click(function () {
        var myDate;
        var newDate;
        if ($("#tbxDate_key").val() == "") {
            var curDate = new Date();
            $("#tbxDate_key").val(curDate.getFullYear() + '/' + (curDate.getMonth() + 1) + '/' + curDate.getDate());
            GetDateFormat($("#tbxDate_key")[0]);
            $("#btnSelect")[0].click();
            return true;
        }
        myDate = $("#tbxDate_key").val();

        if (myDate != "") {
            myDate.split("/");
            newDate = new Date(myDate.split("/")[0], myDate.split("/")[1], myDate.split("/")[2]);
            newDate = new Date(newDate.getTime() + 24 * 60 * 60 * 1000);
            $("#tbxDate_key").val(newDate.getFullYear() + '/' + (newDate.getMonth()) + '/' + newDate.getDate());

            GetDateFormat($("#tbxDate_key")[0]);
            $("#btnSelect")[0].click();
        }
       

    });
    

    $("#btnUpdate,#btnInsert").click(function () {

        var obj;
        obj = $("#tbxCheckUser");

        if ($(obj).val() == "") {
            alert("用户不存在");
            setTimeout(function () { obj.focus(); }, 100);
            return false;
        }

        if ($("#tbxMakeNo_key").val() == "" || $("#tbxCode_key").val() == "") {
            alert("作番/CODE不存在");
            setTimeout(function () { $("#tbxMakeNo_key").focus(); }, 100);
            return false;
        }

        htmlobj = $.ajax({ url: "AJAX.aspx?a=" + new Date() + "&kbn=user&user_cd=" + $(obj).val() + "&line_id=" + $("#tbxLineId").val(), async: false });
        if (htmlobj.responseText == "") {
            alert("用户不存在");
            setTimeout(function () { obj.focus(); }, 100);
            return false;
        } else {
            $("#lblUserName").val(htmlobj.responseText.split(",")[0]);
            $("#tbxLineId_key").val(htmlobj.responseText.split(",")[1]);
        }



        return true;

    });

    //检查者No
    $("#tbxCheckUser").blur(function () {
        var obj;
        obj = $(this);

        if ($(this).val() == "") {
            return false;
        }

        htmlobj = $.ajax({ url: "AJAX.aspx?a=" + new Date() + "&kbn=user&user_cd=" + $(this).val() + "&line_id=" + $("#tbxLineId_key").val(), async: false });
        if (htmlobj.responseText == "") {
            alert("用户不存在");
            setTimeout(function () { obj.focus(); }, 100);
        } else {
            $("#lblUserName").val(htmlobj.responseText.split(",")[0]);
            $("#tbxLineId_key").val(htmlobj.responseText.split(",")[1]);
        }
    });

    $("#zongl").click(function (e) {
        window.open("apexcharts/Default.aspx?line_id=" + $("#tbxLineId_key").val() + "&chk_date=" + $("#tbxDate_key").val())
    });

    $("#tbxCheckUser,#tbxMakeNo_key,#tbxCode_key,#tbxDate_key").focus(function (e) {
        $(this)[0].select();
    });



    $("#tbxCheckUser").keydown(function (e) {
        if (e.keyCode == 13) {
            $("#tbxMakeNo_key")[0].select();
            e.preventDefault();
            return false;
        }
    });

    $("#tbxLineId_key").keydown(function (e) {
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

