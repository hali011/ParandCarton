function Comma(Num) { //function to add commas to textboxes
    Num += '';
    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
    x = Num.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1))
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    return x1 + x2;
} // #region Comma

function isLettersKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return true;

    return false;
} // #region isLettersKey

function isNumbersKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
} // #region isNumbersKey

function isNumbersKeyPlusPeriod(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if ((charCode > 31) && (charCode < 46 || charCode > 57)) {
        return false;
    }
    else {
        if (charCode == 47)
        { return false; }
        else { return true; }
    }
}

function waitMessage() {
    window.parent.eval("window.waitDialog = SP.UI.ModalDialog.showWaitScreenWithNoClose('در حال بارگذاری ... ', '', 90, 350);");
} // #region waitMessage

function Print(elements) {
    for (var i = 0; i < elements.length; i++) {
        elements[i].style.display = "none";
    }
    window.print();
    //return false;
    for (var i = 0; i < elements.length; i++) {
        elements[i].style.display = "block";
    }
} // #region Print

function onItemChecked(sender, e) {
    var item = e.get_item();
    var items = sender.get_items();
    var checked = item.get_checked();
    var firstItem = sender.getItem(0);
    if (item.get_text() == "انتخاب همه") {
        items.forEach(function (itm) { itm.set_checked(checked); });
    }
    else {
        if (sender.get_checkedItems().length == items.get_count() - 1) {
            firstItem.set_checked(!firstItem.get_checked());
        }
    }
} // #region onItemChecked

// <!-- #region بررسی درست بودن دقیقه های شروع و پایان -->
function MinutesCheck()
{
    if ((HourAz == HourTa && MinuteAz == MinuteTa) || (HourAz == HourTa && MinuteAz >= MinuteTa)) {
        alert('کاربر گرامی در صورت یکسان بودن ساعت شروع و پایان، دقیقه شروع باید کمتر از دقیقه پایان باشد.');
        return false;
    }
  
    else { return; }
}
// <!-- #endregion -->

// <!-- #region بررسی اینکه فقط مرخصی را تا سه روز قبل بتواند ثبت کند -->
function MaximumTimeAllowed() {
    inpDateAz = inpDateAz.split('/').join(',');
    var DateAz = inpDateAz.split(',');
    var JDate = require('jdate');
    var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
    var firstDate = new JDate(DateAz);
    firstDate = new Date(firstDate._d);
    var secondDate = new Date();
    secondDate = secondDate.setHours(00, [00], [00], [00]);
    secondDate = new Date(secondDate);
    var checkNegative = ((secondDate.getTime() - firstDate.getTime()) / (oneDay));
    if (checkNegative > 0) {
        var diffDays = Math.round(Math.abs((firstDate.getTime() - secondDate.getTime()) / (oneDay)));
        if (diffDays >= MaximumDayAllow) {
            return false;
        }
        else { return true; }
    }
    else { return true; }
}
// <!-- #endregion -->
// <!-- #region بررسی اینکه از تاریخ امروز به بعد بتونه جلسه ثبت کنه -->
function MinimumTimeAllowed() {
    //week = new Array("يكشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "جمعه", "شنبه")
    //months = new Array("فروردين", "ارديبهشت", "خرداد", "تير", "مرداد", "شهريور", "مهر", "آبان", "آذر", "دي", "بهمن", "اسفند");


    //a = new Date();
    //d = a.getDay();
    //day = a.getDate();
    //month = a.getMonth() + 1;
    //year = a.getYear();


    //year = (year == 0) ? 2000 : year;
    //(year < 1000) ? (year += 1900) : true;
    //year -= ((month < 3) || ((month == 3) && (day < 21))) ? 622 : 621;
    //switch (month) {
    //    case 1: (day < 21) ? (month = 10, day += 10) : (month = 11, day -= 20); break;
    //    case 2: (day < 20) ? (month = 11, day += 11) : (month = 12, day -= 19); break;
    //    case 3: (day < 21) ? (month = 12, day += 9) : (month = 1, day -= 20); break;
    //    case 4: (day < 21) ? (month = 1, day += 11) : (month = 2, day -= 20); break;
    //    case 5:
    //    case 6: (day < 22) ? (month -= 3, day += 10) : (month -= 2, day -= 21); break;
    //    case 7:
    //    case 8:
    //    case 9: (day < 23) ? (month -= 3, day += 9) : (month -= 2, day -= 22); break;
    //    case 10: (day < 23) ? (month = 7, day += 8) : (month = 8, day -= 22); break;
    //    case 11:
    //    case 12: (day < 22) ? (month -= 3, day += 9) : (month -= 2, day -= 21); break;
    //    default: break;
    //}
   
    //alert(day+"/"+month+"/"+year);
    //document.write(" " + week[d] + " " + day + " " + months[month - 1] + " " + year);
}
// <!-- #endregion -->
// <!-- #region پر کردن باکس شهر -->
function drpProvince() {
    ctx = new SP.ClientContext(_spPageContextInfo.webAbsoluteUrl);
    web = ctx.get_web();
    ctx.load(web);
    ctx.executeQueryAsync(drpProvinceSucceeded, onQueryFailed);
}
function drpProvinceSucceeded() {
    var webUrl = web.get_url();
    $.ajax({
        type: "POST",
        url: "/_layouts/15/CartableWebMethod/AppPages/CartableCounter.aspx/GetCityFromProvinceList",
        data: '{webUrl : "' + webUrl + '",selectedItemtext: "' + selectedItemtext + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var response = $.parseJSON(data.d);
            ctx.executeQueryAsync(drpCitySucceeded(response), onQueryFailed);
        },
        failure: function (response) {
            alert("لطفا با مدیر سایت تماس بگیرید");
        }
    });
}
function drpCitySucceeded(response) {
    ctx.executeQueryAsync(
    function () {
        drpCity.options.length = 0;
        //AddOption("انتخاب کنید", "");
        for (i = 0; i < response.Table1.length; i++) {
            var KeysValues = String(response.Table1[i]).split(",");
            if (KeysValues[0] != null & KeysValues[1] != null) {
                AddOption(KeysValues[0], KeysValues[1]);
            }
        }
    },
    function (sender, args) {
        alert("لطفا با مدیر سایت تماس بگیرید");
    });
}
function AddOption(value, text) {
    var option = document.createElement('option');
    option.textContent = text;
    option.value = value;
    drpCity.appendChild(option);
    //option.value = value;
    //option.innerHTML = text;
    //drpCity.options.add(option);
}
function onQueryFailed(sender, args) {
    alert('لطفا با مدیر سایت تماس بگیرید.');
}
// <!-- #endregion -->

// <!-- #region بدست آوردن اطلاعات شخصی که کد پرسنلی آن وارد شده -->
function GetInfo() {
   
        ctx = new SP.ClientContext(_spPageContextInfo.webAbsoluteUrl);
        web = ctx.get_web();
        ctx.load(web);
        currentUser = web.get_currentUser();
        ctx.load(currentUser);
        ctx.executeQueryAsync(GetInfoSucceeded, onQueryFailed);
}
function GetInfoSucceeded() {
    var webUrl = web.get_url();
    var currentUserName = currentUser.get_title();
    $.ajax({
        type: "POST",
        url: "/_layouts/15/CartableWebMethod/AppPages/CartableCounter.aspx/GetUserInfoFromBaseInfoList",
        data: '{webUrl : "' + webUrl + '",PersonnelCode: "' + PersonnelCode.value + '",CurrentUserName: "' + currentUserName + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var response = $.parseJSON(data.d);
            ctx.executeQueryAsync(GetInfoSucceeded1(response), onQueryFailed);
        },
        failure: function (response) {
            alert("لطفا با مدیر سایت تماس بگیرید");
        }
    });
}
function GetInfoSucceeded1(response) {
    ctx.executeQueryAsync(
    function () {
        for (i = 0; i < response.Table1.length; i++) {
            KeysValues = String(response.Table1[i]).split(",");
        }
        if (KeysValues[4] == "") {
            if (Name != undefined) { Name.value = KeysValues[1]; }
            if (OrgUnit != undefined) { OrgUnit.value = KeysValues[2]; }
            if (Manager != undefined) { Manager.value = KeysValues[3]; }
            if (HamkaranCode != undefined) { HamkaranCode.value = KeysValues[5]; }
            if (MaximumAdvance != undefined) { MaximumAdvance.value = Comma(KeysValues[6]); }
            if (FatherName != undefined) { FatherName.value = KeysValues[7]; }
            if (TafsiliCode != undefined) { TafsiliCode.value = KeysValues[8]; }
        }
        else {
            alert(KeysValues[4]);
            if (PersonnelCode != undefined) { PersonnelCode.value = null; }
            if (Name != undefined) { Name.value = null; }
            if (OrgUnit != undefined) { OrgUnit.value = null; }
            if (Manager != undefined) { Manager.value = null; }
            if (HamkaranCode != undefined) { HamkaranCode.value = null; }
            if (MaximumAdvance != undefined) { MaximumAdvance.value = null; }
            if (FatherName != undefined) { FatherName.value = null; }
            if (TafsiliCode != undefined) { TafsiliCode.value = null; }

        }
    },
    function (sender, args) {
        alert("لطفا با مدیر سایت تماس بگیرید");
    });
}
// <!-- #endregion -->

// <!-- #region بدست آوردن اطلاعات شخصی که کد پرسنلی آن در فرم ماموریت روزانه وارد شده -->
function GetInfoForMissionDay() {
    SP.SOD.executeFunc('SP.js', 'SP.ClientContext', function () {
        ctx = new SP.ClientContext(_spPageContextInfo.webAbsoluteUrl);
        web = ctx.get_web();
        ctx.load(web);
        currentUser = web.get_currentUser();
        ctx.load(currentUser);
        ctx.executeQueryAsync(GetInfoSucceededForMissionDay, onQueryFailed);
    });
}
function GetInfoSucceededForMissionDay() {
    var webUrl = web.get_url();
    var currentUserName = currentUser.get_title();
    $.ajax({
        type: "POST",
        url: "/_layouts/15/CartableWebMethod/AppPages/CartableCounter.aspx/GetUserInfoFromBaseInfoListForMissionDay",
        data: '{webUrl : "' + webUrl + '",PersonnelCode: "' + PersonnelCode.value + '",CurrentUserName: "' + currentUserName + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var response = $.parseJSON(data.d);
            ctx.executeQueryAsync(GetInfoSucceededForMissionDay1(response), onQueryFailed);
        },
        failure: function (response) {
            alert("لطفا با مدیر سایت تماس بگیرید");
        }
    });
}
function GetInfoSucceededForMissionDay1(response) {
    ctx.executeQueryAsync(
    function () {
        for (i = 0; i < response.Table1.length; i++) {
            KeysValues = String(response.Table1[i]).split(",");
        }
        if (KeysValues[4] == "") {
            Name.value = KeysValues[1];
            OrgUnit.value = KeysValues[2];
            Manager.value = KeysValues[3];
        }
        else {
            alert(KeysValues[4]);
            PersonnelCode.value = null;
            Name.value = null;
            OrgUnit.value = null;
            Manager.value = null;

        }
    },
    function (sender, args) {
        alert("لطفا با مدیر سایت تماس بگیرید");
    });
}
// <!-- #endregion -->

// <!-- #region بازکردن صفحه جدید -->
function OpenNewTabWindow(NewTabUrl) {
    var NewTabWin = window.open(NewTabUrl, '_blank');
    NewTabWin.focus();
}
// <!-- #endregion -->

// <!-- #region تاییدیه انجام عملیات -->
function ConfirmFunction() {
    if (confirm("آیا از رد درخواست اطمینان دارید؟") == true) {
        waitMessage();
    } else {
        return false;
    }
}
// <!-- #endregion -->

// <!-- #region تاییدیه انجام عملیات -->
function ConfirmDeleteFunction() {
    if (confirm("آیا از حذف درخواست اطمینان دارید؟") == true) {
        waitMessage();
    } else {
        return false;
    }
}
// <!-- #endregion -->

// <!-- #region تاییدیه انجام عملیات -->
function ConfirmFunctions() {
    if (confirm("آیا از بستن درخواست اطمینان دارید؟") == true) {
        waitMessage();
    } else {
        return false;
    }
}
// <!-- #endregion -->