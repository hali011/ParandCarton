//OrderInformation
function selectcustomer(x) {
    var c = String(x);
    var code = $("#code" + c).val();
    $("#txtCustomerCode").val("");
    $("#txtCustomerCode").val(code);
    var name = $("#name" + c).val();
    $("#txtCustomerName").val("");
    $("#txtCustomerName").val(name);
}
function CheckNumber(father, data) {
    if (isNaN(data)) {
        father.val("");
        alert("لطفا فیلد را با عدد پر کنید");
    }
}

//CartonTechnicalInfo
function sardkhaneChange(x) {
    if (x == 0) {
        $("#Syes").prop('checked', false)
        $("#Sno").prop('checked', true)
    }
    else if (x == 1) {
        $("#Syes").prop('checked', true)
        $("#Sno").prop('checked', false)
    }

}
function nemonechange(x) {
    if (x == 0) {
        $("#Nyes").prop('checked', false)
        $("#Nno").prop('checked', true)
    }
    else if (x == 1) {
        $("#Nyes").prop('checked', true)
        $("#Nno").prop('checked', false)
    }
}
function conection(x) {
    switch (x) {
        case 1:
            $("#chasb").prop('checked', true)
            $("#mangene").prop('checked', false)
            $("#ghofli").prop('checked', false)
            break
        case 2:
            $("#chasb").prop('checked', false)
            $("#mangene").prop('checked', true)
            $("#ghofli").prop('checked', false)
            break
        case 3:
            $("#chasb").prop('checked', false)
            $("#mangene").prop('checked', false)
            $("#ghofli").prop('checked', true)
            break
    }
}
function space(x) {
    if (x == 0) {
        $("#donthavespace").prop('checked', true)
        $("#havespace").prop('checked', false)
    }
    else if (x == 1) {
        $("#havespace").prop('checked', true)
        $("#donthavespace").prop('checked', false)
    }
}
function sheettype(x) {
    if (x == 1) {
        $("#samplesheet").prop('checked', true);
        $("#notsamplesheet").prop('checked', false);
        $("#divshtoolcarton").hide();
        $("#divsharzcarton").hide();
        $("#divshertefacarton").hide();
    } else {
        $("#samplesheet").prop('checked', false)
        $("#notsamplesheet").prop('checked', true)
        $("#divshtoolcarton").show();
        $("#divsharzcarton").show();
        $("#divshertefacarton").show();
    }
}
function Getsheettype(x) {
    if (x.is(':checked')) {
        return $("#samplesheet").val();
    }
    else {
        return $("#notsamplesheet").val();
    }
}
function yesnovalue(x) {
    if (x.is(':checked')) {
        return true
    }
    else {
        return false
    }
}
function getconnectionvalue() {
    if ($("#chasb").is(':checked')) {
        return 1
    }
    else if ($("#mangene").is(':checked')) {
        return 2
    }
    else if ($("#ghofli").is(':checked')) {
        return 3
    }
}
function fillcombobox(i, x) {
    if (x == true) {
        switch (i) {
            case 1:
                $("#Syes").prop('checked', true);
                $("#Sno").prop('checked', false);
                break;
            case 2:
                $("#Nyes").prop('checked', true);
                $("#Nno").prop('checked', false);
                break;
            case 3:
                $("#havespace").prop('checked', true);
                $("#donthavespace").prop('checked', false);
                break;
        }
    } else {
        switch (i) {
            case 1:
                $("#Sno").prop('checked', true);
                $("#Syes").prop('checked', false);
                break;
            case 2:
                $("#Nyes").prop('checked', false);
                $("#Nno").prop('checked', true);
                break;
            case 3:
                $("#havespace").prop('checked', false);
                $("#donthavespace").prop('checked', true);
                break;
        }
    }
}
function fillconnection(x) {
    switch (x) {
        case 1:
            $("#chasb").prop('checked', true);
            $("#mangene").prop('checked', false);
            $("#ghofli").prop('checked', false);
            break;
        case 2:
            $("#chasb").prop('checked', false);
            $("#mangene").prop('checked', true);
            $("#ghofli").prop('checked', false);
            break;
        case 3:
            $("#chasb").prop('checked', false);
            $("#mangene").prop('checked', false);
            $("#ghofli").prop('checked', true);
            break;
    }
}
function typeofsuggest(x) {
    if (x == 1) {
        $("#carton").prop('checked', true);
        $("#varagh").prop('checked', false);
        $("#karaton").show();
        $("#varaq").hide();
    }
    else {
        $("#carton").prop('checked', false);
        $("#varagh").prop('checked', true);
        $("#karaton").hide()
        $("#varaq").show();
    }
}
function Gettechnicalltype(x) {
    if (x.is(':checked')) {
        return false
    }
    else {
        return true
    }
}
function calchidemanroyeham(x) {
    x = x / 10;
    var cal = 255 / x;
    var result = Math.floor(cal);
    $("#txtColumnNumber").val(result);
}

//PrintInformation
function printtype(x) {
    switch (x) {
        case 1:
            $("#felsko").prop('checked', true);
            $("#laminet").prop('checked', false);
            $("#ranglaminet").show();
            break;
        case 2:
            $("#felsko").prop('checked', false);
            $("#laminet").prop('checked', true);
            $("#ranglaminet").hide();
            break;
    }
}
function mizanechap(x) {
    switch (x) {
        case 0:
            $("#10darsad").prop('checked', true);
            $("#25darsad").prop('checked', false);
            $("#50darsad").prop('checked', false);
            $("#75darsad").prop('checked', false);
            $("#100darsad").prop('checked', false);
            break;
        case 1:
            $("#10darsad").prop('checked', false);
            $("#25darsad").prop('checked', true);
            $("#50darsad").prop('checked', false);
            $("#75darsad").prop('checked', false);
            $("#100darsad").prop('checked', false);
            break;
        case 2:
            $("#10darsad").prop('checked', false);
            $("#25darsad").prop('checked', false);
            $("#50darsad").prop('checked', true);
            $("#75darsad").prop('checked', false);
            $("#100darsad").prop('checked', false);
            break;
        case 3:
            $("#10darsad").prop('checked', false);
            $("#25darsad").prop('checked', false);
            $("#50darsad").prop('checked', false);
            $("#75darsad").prop('checked', true);
            $("#100darsad").prop('checked', false);
            break;
        case 4:
            $("#10darsad").prop('checked', false);
            $("#25darsad").prop('checked', false);
            $("#50darsad").prop('checked', false);
            $("#75darsad").prop('checked', false);
            $("#100darsad").prop('checked', true);
            break;
    }
}
function klishe(self, x) {
    switch (x) {
        case 0:
            $("#donthaveklishe").prop('checked', true)
            $("#haveklishe").prop('checked', false)
            $("#txtKelisheNum").attr('disabled', 'disabled');
            self.val("");
            break;
        case 1:
            $("#donthaveklishe").prop('checked', false)
            $("#haveklishe").prop('checked', true)
            $("#txtKelisheNum").removeAttr('disabled');
            break;
    }
}
function frame(self, x) {
    switch (x) {
        case 0:
            $("#donthaveframe").prop('checked', true)
            $("#haveframe").prop('checked', false)
            $("#txtTemplateNum").attr('disabled', 'disabled');
            self.val("");
            break;
        case 1:
            $("#donthaveframe").prop('checked', false)
            $("#haveframe").prop('checked', true)
            $("#txtTemplateNum").removeAttr('disabled');
            break;
    }
}
function getprinttype() {
    if ($("#felsko").is(':checked', true)) {
        return $("#felsko").val();
    } else {
        return $("#laminet").val();
    }
}
function getpintcount() {
    if ($("#nonepaint").is(':checked', true)) {
        return $("#nonepaint").val();
    }
    if ($("#onepaint").is(':checked')) {
        return $("#onepaint").val();
    }
    if ($("#twopaint").is(':checked')) {
        return $("#twopaint").val();
    }
    if ($("#threepaint").is(':checked')) {
        return $("#threepaint").val();
    }
    if ($("#fourpaint").is(':checked')) {
        return $("#fourpaint").val();
    }
    if ($("#fivepaint").is(':checked')) {
        return $("#fivepaint").val();
    }
}
function getprintamount() {
    if ($("#10darsad").is(':checked', true)) {
        return $("#10darsad").val();
    } else if ($("#25darsad").is(':checked', true)) {
        return $("#25darsad").val();
    } else if ($("#50darsad").is(':checked', true)) {
        return $("#50darsad").val();
    } else if ($("#75darsad").is(':checked', true)) {
        return $("#75darsad").val();
    } else if ($("#100darsad").is(':checked', true)) {
        return $("#100darsad").val();
    }
}
function getprinttypeselection() {
    var str = [];
    if ($("#uv").is(':checked', true)) {
        str.push($("#uv").val());
    }
    if ($("#daycat").is(':checked') == true) {
        str.push($("#daycat").val());
    }
    if ($("#daste").is(':checked') == true) {
        str.push($("#daste").val());
    }
    if ($("#havakesh").is(':checked') == true) {
        str.push($("#havakesh").val());
    }
    return str
}
function fillprinttype(x) {
    if (x) {
        $("#felsko").prop('checked', true);
        $("#laminet").prop('checked', false);
    }
    else {
        $("#felsko").prop('checked', false);
        $("#laminet").prop('checked', true);
    }
}
function fillpintcount(x) {
    switch (x) {
        case "بدون چاپ":
            $("#nonepaint").prop('checked', true);
            $("#onepaint").prop('checked', false);
            $("#twopaint").prop('checked', false);
            $("#threepaint").prop('checked', false);
            $("#fourpaint").prop('checked', false);
            $("#fivepaint").prop('checked', false);
            break;
        case "1":
            $("#nonepaint").prop('checked', false);
            $("#onepaint").prop('checked', true);
            $("#twopaint").prop('checked', false);
            $("#threepaint").prop('checked', false);
            $("#fourpaint").prop('checked', false);
            $("#fivepaint").prop('checked', false);
            break;
        case "2":
            $("#nonepaint").prop('checked', false);
            $("#onepaint").prop('checked', false);
            $("#twopaint").prop('checked', true);
            $("#threepaint").prop('checked', false);
            $("#fourpaint").prop('checked', false);
            $("#fivepaint").prop('checked', false);
            break;
        case "3":
            $("#nonepaint").prop('checked', false);
            $("#onepaint").prop('checked', false);
            $("#twopaint").prop('checked', false);
            $("#threepaint").prop('checked', true);
            $("#fourpaint").prop('checked', false);
            $("#fivepaint").prop('checked', false);
            break;
        case "4":
            $("#nonepaint").prop('checked', false);
            $("#onepaint").prop('checked', false);
            $("#twopaint").prop('checked', false);
            $("#threepaint").prop('checked', false);
            $("#fourpaint").prop('checked', true);
            $("#fivepaint").prop('checked', false);
            break;
        case "5":
            $("#nonepaint").prop('checked', false);
            $("#onepaint").prop('checked', false);
            $("#twopaint").prop('checked', false);
            $("#threepaint").prop('checked', false);
            $("#fourpaint").prop('checked', false);
            $("#fivepaint").prop('checked', true);
            break;
        default:
    }
}
function fillprintamount(x) {
    switch (x) {
        case "1", "10%":
            $("#10darsad").prop('checked', true);
            $("#25darsad").prop('checked', false);
            $("#50darsad").prop('checked', false);
            $("#75darsad").prop('checked', false);
            $("#100darsad").prop('checked', false);
            break;
        case "25%":
            $("#10darsad").prop('checked', false);
            $("#25darsad").prop('checked', true);
            $("#50darsad").prop('checked', false);
            $("#75darsad").prop('checked', false);
            $("#100darsad").prop('checked', false);
            break;
        case "50%":
            $("#10darsad").prop('checked', false);
            $("#25darsad").prop('checked', false);
            $("#50darsad").prop('checked', true);
            $("#75darsad").prop('checked', false);
            $("#100darsad").prop('checked', false);
            break;
        case "75%":
            $("#10darsad").prop('checked', false);
            $("#25darsad").prop('checked', false);
            $("#50darsad").prop('checked', false);
            $("#75darsad").prop('checked', true);
            $("#100darsad").prop('checked', false);
            break;
        case "100%":
            $("#10darsad").prop('checked', false);
            $("#25darsad").prop('checked', false);
            $("#50darsad").prop('checked', false);
            $("#75darsad").prop('checked', false);
            $("#100darsad").prop('checked', true);
            break;
        default:
    }
}
function fillprinttypeselection(x, y) {
    if (y) {
        if (x == null) {
            $("#uv").prop('checked', false);
            $("#daycat").prop('checked', false);
            $("#daste").prop('checked', false);
            $("#havakesh").prop('checked', false);
        }
        else {
            for (var i = 0; i < x.length; i++) {
                if (x[i] == $("#uv").val()) {
                    $("#uv").prop('checked', true);
                }
                if (x[i] == $("#daycat").val()) {
                    $("#daycat").prop('checked', true);
                }
                if (x[i] == $("#daste").val()) {
                    $("#daste").prop('checked', true);
                }
                if (x[i] == $("#havakesh").val()) {
                    $("#havakesh").prop('checked', true);
                }
            }
        }
    }
    else {
        $("#uv").prop('checked', false);
        $("#daycat").prop('checked', false);
        $("#daste").prop('checked', false);
        $("#havakesh").prop('checked', false);
    }
}

                //LogesticInformation

function adressf(x) {
    if (x == 0) {
        $("#divAddress1").hide()
        $("#divAddress2").hide()
    }
    else if (x == 1) {
        $("#divAddress1").show()
        $("#divAddress2").show()
    }
}
function radiowithtwoinput(x, i) {
    switch (i) {
        case 0:
            if (x == false) {
                $("#dakheli").prop('checked', true)
                $("#saderati").prop('checked', false)
            }
            else if (x == true) {
                $("#saderati").prop('checked', true)
                $("#dakheli").prop('checked', false)
            }
            break;
        case 1:
            if (x == false) {
                $("#factory").prop('checked', true)
                $("#customersuggest").prop('checked', false)
                adressf(0)
            }
            else if (x == true) {
                $("#customersuggest").prop('checked', true)
                $("#factory").prop('checked', false)
                adressf(1);
            }
            break;
        case 2:
            if (x == true) {
                $("#monazam").prop('checked', true)
                $("#namonazam").prop('checked', false)

            }
            else if (x == false) {
                $("#namonazam").prop('checked', true)
                $("#monazam").prop('checked', false)
            }
            break;
    }
}
function radiowiththreeinput(x, i) {
    switch (i) {
        case 0:
            switch (x) {
                case 0:
                    $("#kamyonet").prop('checked', true)
                    $("#tereyli").prop('checked', false)
                    $("#kamyon").prop('checked', false)
                    break;
                case 1:
                    $("#kamyon").prop('checked', true)
                    $("#tereyli").prop('checked', false)
                    $("#kamyonet").prop('checked', false)
                    break;
                case 2:
                    $("#tereyli").prop('checked', true)
                    $("#kamyon").prop('checked', false)
                    $("#kamyonet").prop('checked', false)
                    break;
            }
            break;
    }

}
function strtocheckbox(x) {
    if (x == null | x == []) {
        $("#sherink").prop('checked', false);
        $("#tasme").prop('checked', false);
        $("#palet").prop('checked', false);
    }
    else {
        for (var i = 0; i < x.length; i++) {
            if (x[i].trim() == $("#sherink").val()) {
                $("#sherink").prop('checked', true);
            }
            if (x[i].trim() == $("#tasme").val()) {
                $("#tasme").prop('checked', true);
            }
            if (x[i].trim() == $("#palet").val()) {
                $("#palet").prop('checked', true);
            }

        }
    }
}
function gettworadiobuttenLI(x) {
    switch (x) {
        case 0:
            if ($("#monazam").is(':checked', true)) {
                return true;
            }
            else {
                return false;
            }
            break;
        case 1:
            if ($("#dakheli").is(':checked', true)) {
                return false;
            }
            else {
                return true;
            }
            break;
        case 2:
            if ($("#factory").is(':checked', true)) {
                return false;
            }
            else {
                return true;
            }
            break;
    }
}
function getthreeradiobuttenLI() {
    if ($("#kamyonet").is(':checked', true)) {
        return $("#kamyonet").val();
    }
    else if ($("#kamyon").is(':checked', true)) {
        return $("#kamyon").val();
    }
    else if ($("#tereyli").is(':checked', true)) {
        return $("#tereyli").val();
    }
}
function getpalet() {
    var str = [];
    if ($("#sherink").is(':checked', true)) {
        str.push($("#sherink").val());
    }
    if ($("#tasme").is(':checked', true)) {
        str.push($("#tasme").val());
    }
    if ($("#palet").is(':checked', true)) {
        str.push($("#palet").val());
    }
    return str
}
function gethumidity() {
    return $('#ddlHumidity :selected').val();
}
function getTrueadress() {
    if ($("#trueadress").is(':checked', true)) {
        return true;
    }
    else {
        return false;
    }
}

//ProductInformatiom

function error() {
    var vazn = $("#CartonWeight").val()
    var tol = $("#CartonLength").val()
    var arz = $("#CartonWidth").val()
    var ertefa = $("#CartonHeight").val()
    var fasale = $("#txtDistance").val()
    var zamananbaresh = $("#txtAnbareshTime").val()
    if (vazn == "" && tol == "" && arz == "" && ertefa == "" && fasale == "" && zamananbaresh == "" && $('#ddlHumidity :selected').val() == 0) {
        var msg = "لطفا فسمت های موردنیاز را وارد کنید ";
        $("#CartonWeight").css('border-color', 'red')
        $("#CartonLength").css('border-color', 'red')
        $("#CartonWidth").css('border-color', 'red')
        $("#CartonHeight").css('border-color', 'red')
        $("#txtDistance").css('border-color', 'red')
        $("#txtAnbareshTime").css('border-color', 'red')
        $('#ddlHumidity :selected').css('border-color', 'red')
        alert(msg);
        return true;
    }
    else {
        return false;
    }
}
function Daste() {
    if ($("#daste").is(':checked') == true) {
        return true;
    } else {
        return false;
    }
}
function Havakesh() {
    if ($("#havakesh").is(':checked') == true) {
        return true;
    } else {
        return false;
    }
}
function layers(id) {
    if (id == 3) {
        $("#3layers").prop('checked', true);
        $("#5layers").prop('checked', false);
        $("#layer4").hide();
        $("#layer4").prop("selectedIndex", 0);
        $("#layer5").hide();
        $("#layer5").prop("selectedIndex", 0);
        $("#floottype2").prop("selectedIndex", 0);
        checklayertype(1);
        $("#floottype2").hide();
    }
    else if (id == 5) {
        $("#3layers").prop('checked', false);
        $("#5layers").prop('checked', true);
        $("#layer4").show();
        $("#layer5").show();
        $("#floottype2").show();
    }
}
function howmanylayer() {
    if ($("#3layers").is(':checked')) {
        return false
    } else {
        return true
    }
}
function checklayertype(x) {
    if (x == 0) {
        let floattype1 = $('#floottype1 :selected').val();
        let variable = ["E", "B", "C"];
        for (var i = 0; i < variable.length; i++) {
            if (floattype1 == variable[i]) {
                switch (variable[i]) {
                    case "E":
                        $("#E2").attr('disabled', 'disabled');
                        $("#B2").removeAttr('disabled');
                        $("#C2").removeAttr('disabled');
                        break;
                    case "C":
                        $("#C2").attr('disabled', 'disabled');
                        $("#B2").removeAttr('disabled');
                        $("#E2").removeAttr('disabled');
                        break;
                    case "B":
                        $("#B2").attr('disabled', 'disabled');
                        $("#E2").removeAttr('disabled');
                        $("#C2").removeAttr('disabled');
                        break;
                }
            }
        }
    } else {
        let floattype2 = $('#floottype2 :selected').val();
        let variable = ["E", "B", "C"];
        for (var i = 0; i < variable.length; i++) {
            if (floattype2 == variable[i]) {
                switch (variable[i]) {
                    case "E":
                        $("#E1").attr('disabled', 'disabled');
                        $("#B1").removeAttr('disabled');
                        $("#C1").removeAttr('disabled');
                        break;
                    case "C":
                        $("#C1").attr('disabled', 'disabled');
                        $("#B1").removeAttr('disabled');
                        $("#E1").removeAttr('disabled');
                        break;
                    case "B":
                        $("#B1").attr('disabled', 'disabled');
                        $("#E1").removeAttr('disabled');
                        $("#C1").removeAttr('disabled');
                        break;
                }
            }
        }
    }
}

                        //form
function GetDataFromOC(ordercode) {
    $.ajax({
        type: "POST",
        url: '/Home/onloaddata)',
        data: { id: ordercode },
        datatype: "json",
        success: function (data) {
            $("#CreateDate").val(data.CreateDate);
            $("#txtCustomerCode").val(data.CustomerCode);
            $("#txtCustomerName").val(data.CustomerName);
            $("#txtSalePersonCode").val(data.SaleExpertCode);
            $("#txtProductCode").val(data.ProductCode);
            $("#txtProductName").val(data.ProductName);
            $("#txtSalePersonName").val(data.SaleExpertName);
            $("#txtAddress").val(data.Address);
            $("#txtnationalcode").val(data.NationalCode);
            $("#txtPostalCode").val(data.PostalCode);
            $("#txtrabetsazmani").val(data.EnterPriceInterfaceName);
            $("#txtEconomicCode").val(data.EnconomicCode);
            $("#txtTell").val(data.Tell);
            $("#txtTellrabetsazmani").val(data.EnterPriceInterfaceTell);
            $("#txtCustomerEmail").val(data.Email);
            if (data.type == true) {
                typeofsuggest(1);
                $("#cartontype").data('kendoComboBox').value(data.CartonType);
                $("#cartoncount").val(data.CartonCount)
                $("#CartonLength").val(data.CartonLength)
                $("#CartonWeight").val(data.CartonWeight)
                $("#contenttype").data('kendoComboBox').value(data.CartonInsideType);
                $("#CartonWidth").val(data.CartonWidth)
                $("#CartonHeight").val(data.CartonHeight)
                if (data.IsCold == true) {
                    sardkhaneChange(1)
                } else {
                    sardkhaneChange(0)
                }
                if (data.IsTemplate == true) {
                    nemonechange(1)
                } else {
                    nemonechange(0)
                }
                if (data.ConnectorType == 1) {
                    conection(1)
                }
                else if (data.ConnectorType == 2) {
                    conection(2)
                }
                else {
                    conection(3)
                }
                if (CartonEmpty == true) {
                    space(1)
                }
                else {
                    space(0)
                }
            }
            else {
                typeofsuggest(0);
                $("#sheetcount").val(data.SheatCount);
                $("#sheettoal").val(data.SheatLength);
                $("#sheetarz").val(data.SheatWidth);
                if (SheatType == "شیت ساده") {
                    sheettype(1)
                }
                else {
                    sheettype(0)
                }
                $("#sharzcarton").val(data.CartonWidth);
                $("#shertefacarton").val(data.CartonHeight);
                $("#shtoolcarton").val(data.CartonLength)
            }
            let printtype = getprinttype();
            let paintcount = getpintcount();
            let printtypeselection = getprinttypeselection();
            $("#txtKelisheNum").val();
            let printamount = getprintamount();
            $("#txtTemplateNum").val();
            let layouttype = gettworadiobuttenLI(0);
            $("#txtColumnNumber").val();
            let consumtype = gettworadiobuttenLI(1);
            $("#txtDistance").val();
            let deliverytype = gettworadiobuttenLI(2);
            $("#txtAnbareshTime").val();
            let submittype = getthreeradiobuttenLI();
            let ispalet = getpalet();
            let humidity = gethumidity();
            let useaddress = getTrueadress();
            $("#txtOtherAddress").val();
            $("#mizanvaraghmasrafi").val();
            $("#txtBctNum").val();
            $("#txtWasteRate").val();
            $("#txtDeliverDate").val();
            let layercount = howmanylayer();
            if (layercount == false) {
                layer.push($('#layer1 :selected').val());
                layer.push($('#layer2 :selected').val());
                layer.push($('#layer3 :selected').val());
                floattype.push($('#floottype1 :selected').val());
            }
            if (layercount == true) {
                layer.push($('#layer1 :selected').val());
                layer.push($('#layer2 :selected').val());
                layer.push($('#layer3 :selected').val());
                layer.push($('#layer4 :selected').val());
                layer.push($('#layer5 :selected').val());
                floattype.push($('#floottype1 :selected').val())
                floattype.push($('#floottype2 :selected').val())
            }
            var ECT = $("#ECTBCT").val();
            var BCT = $("#BCTECT").val()
            let Description = $("#Description").val();
            let percprice = $("#percprice").val();
            let allcprice = $("#allcprice").val();
            let malyat = $("#malyat").val();
            let takhfif = $("#takhfif").val();
            let bigprice = $("#bigprice").val();
        }
    })
}  // need work on this
function checkprice(id) {
    if (id == 1) {
        var type = howmanylayer();
        if (type == 1 && $("#CartonLength").val() == "" && $("#CartonWidth").val() == "" && $("#CartonHeight").val() == "" && $("#cartoncount").val() == "" && $('#layer1 :selected').val() == 0 && $('#layer2 :selected').val() == 0 && $('#layer3 :selected').val() == 0 && $('#layer4 :selected').val() == 0 && $('#layer5 :selected').val() == 0 && $('#float1 :selected').val() == 0 && $('#float2 :selected').val() == 0) {
            var msg = "لطفا فسمت های موردنیاز را وارد کنید ";
            $("#CartonLength").css('border-color', 'red');
            $("#CartonWidth").css('border-color', 'red');
            $("#CartonHeight").css('border-color', 'red');
            $("#cartoncount").css('border-color', 'red');
            $('#layer1 :selected').css('border-color', 'red');
            $('#layer2 :selected').css('border-color', 'red');
            $('#layer3 :selected').css('border-color', 'red');
            $('#layer4 :selected').css('border-color', 'red');
            $('#layer5 :selected').css('border-color', 'red');
            $('#float1 :selected').css('border-color', 'red');
            $('#float2 :selected').css('border-color', 'red');
            alert(msg);
            return false;
        }
        else if (type == 0 && $("#CartonLength").val() == "" && $("#CartonWidth").val() == "" && $("#CartonHeight").val() == "" && $("#cartoncount").val() == "" && $('#layer1 :selected').val() == 0 && $('#layer2 :selected').val() == 0 && $('#layer3 :selected').val() == 0 && $('#float1 :selected').val() == 0) {
            var msg = "لطفا فسمت های موردنیاز را وارد کنید ";
            $("#CartonLength").css('border-color', 'red');
            $("#CartonWidth").css('border-color', 'red');
            $("#CartonHeight").css('border-color', 'red');
            $("#cartoncount").css('border-color', 'red');
            $('#layer1 :selected').css('border-color', 'red');
            $('#layer2 :selected').css('border-color', 'red');
            $('#layer3 :selected').css('border-color', 'red');
            $('#layer4 :selected').css('border-color', 'red');
            $('#layer5 :selected').css('border-color', 'red');
            $('#float1 :selected').css('border-color', 'red');
            $('#float2 :selected').css('border-color', 'red');
            alert(msg);
            return false;
        }
        else {
            return true;
        }
    }
    else {
        var type = howmanylayer();
        if (type == 1 && $("#CartonLength").val() == "" && $("#CartonWidth").val() == "" && $('#layer1 :selected').val() == 0 && $('#layer2 :selected').val() == 0 && $('#layer3 :selected').val() == 0 && $('#layer4 :selected').val() == 0 && $('#layer5 :selected').val() == 0 && $('#float1 :selected').val() == 0 && $('#float2 :selected').val() == 0) {
            var msg = "لطفا فسمت های موردنیاز را وارد کنید ";
            $("#CartonLength").css('border-color', 'red');
            $("#CartonWidth").css('border-color', 'red');
            $('#layer1 :selected').css('border-color', 'red');
            $('#layer2 :selected').css('border-color', 'red');
            $('#layer3 :selected').css('border-color', 'red');
            $('#layer4 :selected').css('border-color', 'red');
            $('#layer5 :selected').css('border-color', 'red');
            $('#float1 :selected').css('border-color', 'red');
            $('#float2 :selected').css('border-color', 'red');
            alert(msg);
            return false;
        }
        else if (type == 0 && $("#CartonLength").val() == "" && $("#CartonWidth").val() == "" && $('#layer1 :selected').val() == 0 && $('#layer2 :selected').val() == 0 && $('#layer3 :selected').val() == 0 && $('#float1 :selected').val() == 0) {
            var msg = "لطفا فسمت های موردنیاز را وارد کنید ";
            $("#CartonLength").css('border-color', 'red');
            $("#CartonWidth").css('border-color', 'red');
            $('#layer1 :selected').css('border-color', 'red');
            $('#layer2 :selected').css('border-color', 'red');
            $('#layer3 :selected').css('border-color', 'red');
            $('#layer4 :selected').css('border-color', 'red');
            $('#layer5 :selected').css('border-color', 'red');
            $('#float1 :selected').css('border-color', 'red');
            $('#float2 :selected').css('border-color', 'red');
            alert(msg);
            return false;
        }
        else {
            return true;
        }
    }

}
function finalcalculate(allprice) {
    if ($("#takhfif").val() == "" || $("#takhfif").val() == 0) {
        allprice = parseFloat(allprice);
        var malyat = allprice * 0.09;
        malyat = Math.round(malyat, 0);
        $("#malyat").val(malyat);
        malyat = parseFloat(malyat);
        var bigprice = allprice + malyat;
        bigprice = Math.round(bigprice, 0);
        $("#bigprice").val(bigprice);
    }
    else {
        allprice = parseFloat(allprice);
        var darsadtakhfif = $("#takhfif").val();
        var takhfif = allprice * (parseFloat(darsadtakhfif) / 100);
        var malyat = allprice * 0.09;
        malyat = Math.round(malyat, 0);
        $("#malyat").val(malyat);
        malyat = parseFloat(malyat);
        var bigprice = (allprice + malyat) - takhfif;
        bigprice = Math.round(bigprice, 0);
        $("#bigprice").val(bigprice);
    }
}
function eraseall() {
    if (confirm("از پاکسازی کامل صفحه مطمئن هستید؟") == true) {
        location.reload(true);
    }
}

        //ResultPage
function ExportTopdf() {
    $("#btnexportpdf").hide();
    let name = $("#ordercode").val();
    let container = document.getElementById("mypdfexport");; // full page
    html2canvas(container, { allowTaint: true, letterRendering: true, windowWidth: 1920, windowHeight: 1080 }).then(function (canvas) {

        let link = document.createElement("a");
        document.body.appendChild(link);
        link.download = name + ".png";
        link.href = canvas.toDataURL("image/png");
        link.target = '_blank';
        link.click();
    });
    $("#btnexportpdf").show();
}