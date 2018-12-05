//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();

    loadCRATYPEList();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/CRA/CRAActiviteList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            var link = '@Url.Action("SaisirCRA", "CRA", new { idCRA = "replace" })';
            var url = '/CRA/SaisirCRA/?idCRA=';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Period + '</td>';
                html += '<td>0</td>';
                html += '<td> CLIENT </td>';
                html += '<td> RESPONSABLE </td>';
                html += '<td> STATUT </td>';

                html += '<td>';
                html += '<div class="dropdown">';
                html += '	<button class="btn btn-primary" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">';
                html += '		<span class="oi oi-menu"></span>';
                html += '	</button>';
                html += '	<div class="dropdown-menu" aria-labelledby="dropdownMenuButton">';
                url = url + item.Id;
                html += '		<a class="dropdown-item" href="' + url + '" >Afficher ce CRA</a>';
                html += '		<a class="dropdown-item" href="#">Modifier ce CRA</a>';
                //html += '		<a class="dropdown-item" href="#" onclick="return GetCRAByID(' + item.Id + ')">Modifier ce CRA</a>';
                html += '		<a class="dropdown-item" href="#">Transmettre pour signature</a>';
                html += '		<a class="dropdown-item" href="#">Supprimer ce CRA</a>';
                html += '	</div>';
                html += '</div>';
                html += '</td>';

                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function onclick() {
    location.href = '@Url.Action("Index","Home")';
}

function addCategory() {
    alert('hello');
    return false;
}
//Add Data Function   
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        CRATypeId: $('.TypeActList').val(),
        Period: $('#MOIS').val(),
        PeriodBegin: $('#PeriodBegin').val(),
        PeriodEnd: $('#PeriodEnd').val()
    };
    $.ajax({
        url: "/CRA/AddCRAActivite",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            //$('#myModal').modal('hide');

            clearTextBox('', '', '', '');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//Function for getting the Data Based upon Employee ID  
function GetCRAByID(CRAId) {
    $('#MOIS').css('border-color', 'lightgrey');
    $('#LIB_CLIENT').css('border-color', 'lightgrey');
    $('#LIB_RESPONSABLE').css('border-color', 'lightgrey');
    //$('#Country').css('border-color', 'lightgrey');
    $.ajax({
        url: "/CRA/GetCRAByID/" + CRAId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CRAId').val(result.CRAId);
            $('#MOIS').val(result.MOIS);
            $('#LIB_CLIENT').val(result.LIB_CLIENT);
            $('#LIB_RESPONSABLE').val(result.LIB_RESPONSABLE);
            //$('#Country').val(result.Country);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function Update() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        EmployeeID: $('#EmployeeID').val(),
        Name: $('#Name').val(),
        Age: $('#Age').val(),
        State: $('#State').val(),
        Country: $('#Country').val()
    };
    $.ajax({
        url: "/CRA/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#EmployeeID').val("");
            $('#Name').val("");
            $('#Age').val("");
            $('#State').val("");
            $('#Country').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/CRA/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox(_PeriodBegin, _PeriodEnd, _CRATypeId, _Period) {
    if (_PeriodBegin !== "") {
        $('#PeriodBegin').val(_PeriodBegin);
        isNew = false;
    }
    else
        $('#PeriodBegin').val("");

    if (_PeriodEnd !== "") {
        $('#PeriodEnd').val(_PeriodEnd);
        isNew = false;
    }
    else
        $('#PeriodEnd').val("");

    if (_CRATypeId !== "") {
        $(".TypeActList").val(_CRATypeId);
        isNew = false;
    }
    else
        $(".TypeActList").val(0);

    $("#btnAdd").attr("data-dismiss", "modal");
    $("#btnUpdate").attr("data-dismiss", "modal");
}


////Valdidation using jquery  
//function validate() {
//    var isValid = true;
//    if ($.trim($('#MOIS').val()) === "") {
//        $('#MOIS').css('border-color', 'Red');
//        isValid = false;
//    }
//    else {
//        $('#MOIS').css('border-color', 'lightgrey');
//    }

//    if ($.trim($('#LIB_CLIENT').val()) === "") {
//        $('#LIB_CLIENT').css('border-color', 'Red');
//        isValid = false;
//    }
//    else {
//        $('#LIB_CLIENT').css('border-color', 'lightgrey');
//    }

//    if ($.trim($('#LIB_RESPONSABLE').val()) === "") {
//        $('#LIB_RESPONSABLE').css('border-color', 'Red');
//        isValid = false;
//    }
//    else {
//        $('#LIB_RESPONSABLE').css('border-color', 'lightgrey');
//    }

//    return isValid;
//}




function loadCRATYPEList() {
    $.ajax({
        url: "/CRA/CRAtypeList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            html += '<option value="0" selected>---</option>';
            $.each(result, function (key, item) {
                html += '<option value="' + item.Id + '">' + item.CRAName + ' (' + item.NbrColTotal + ')' + '</option>';
            });
            $('.TypeActList').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



function validate() {
    var isValid = true;

    var seperator1 = '';
    var seperator2 = '';

    var rawmonth = '';
    var rawday = '';
    var rawyear = '';
    var checkdate = '';

    var splitdate = '';

    var dd = 0;
    var mm = 0;
    var yy = 0;

    var lyear = false;

    if ($.trim($('#PeriodBegin').val()) === "") {
        $('#PeriodBegin').css('border-color', 'Red');
        isValid = false;
    }
    else {
        //var Val_date = $.trim($('#PeriodBegin').val());
        var date = new Date($.trim($('#PeriodBegin').val()));

        Val_date = "" + getFormattedDate(date);
        rawmonth = Val_date.substr(0, 2);
        rawday = Val_date.substr(3, 2);
        rawyear = Val_date.substr(6, 4);
        checkdate = new Date(Val_date);

        var eau = (rawmonth === checkdate.getMonth() + 1) && (rawday === checkdate.getDate()) && (rawyear === checkdate.getFullYear());

        //var dateformat = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
        var dateformat = /^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$/;

        if (Val_date.match(dateformat)) {
            seperator1 = Val_date.split('/');
            seperator2 = Val_date.split('-');

            if (seperator1.length > 1) {
                splitdate = Val_date.split('/');
            }
            else if (seperator2.length > 1) {
                splitdate = Val_date.split('-');
            }
            dd = parseInt(splitdate[0]);
            mm = parseInt(splitdate[1]);
            yy = parseInt(splitdate[2]);
            ListofDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            if (mm === 1 || mm > 2) {
                if (dd > ListofDays[mm - 1]) {
                    //alert('Invalid date format!');
                    $('#PeriodBegin').css('border-color', 'Red');
                    isValid = false;
                }
            }
            if (mm === 2) {
                lyear = false;
                if ((!(yy % 4) && yy % 100) || !(yy % 400)) {
                    lyear = true;
                }
                if ((lyear === false) && (dd >= 29)) {
                    //alert('Invalid date format!');
                    $('#PeriodBegin').css('border-color', 'Red');
                    isValid = false;
                }
                if ((lyear === true) && (dd > 29)) {
                    //alert('Invalid date format!');
                    $('#PeriodBegin').css('border-color', 'Red');
                    isValid = false;
                }
            }
        }
        else {
            //alert("Invalid date format!");
            $('#PeriodBegin').css('border-color', 'Red');
            isValid = false;
        }

        if (isValid === false)
            $('#PeriodBegin').css('border-color', 'Red');
        else
            $('#PeriodBegin').css('border-color', 'lightgrey');
    }

    if ($.trim($('#PeriodEnd').val()) === "") {
        $('#PeriodEnd').css('border-color', 'Red');
        isValid = false;
    }
    else {
        //var Val_date = $.trim($('#PeriodEnd').val());
        var date2 = new Date($.trim($('#PeriodEnd').val()));

        Val_date = "" + getFormattedDate(date2);
        rawmonth = Val_date.substr(0, 2);
        rawday = Val_date.substr(3, 2);
        rawyear = Val_date.substr(6, 4);
        checkdate = new Date(Val_date);

        var eau2 = (rawmonth === checkdate.getMonth() + 1) && (rawday === checkdate.getDate()) && (rawyear === checkdate.getFullYear());

        //var dateformat = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
        var dateformat2 = /^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$/;

        if (Val_date.match(dateformat2)) {
            seperator1 = Val_date.split('/');
            seperator2 = Val_date.split('-');

            if (seperator1.length > 1) {
                splitdate = Val_date.split('/');
            }
            else if (seperator2.length > 1) {
                splitdate = Val_date.split('-');
            }
            dd = parseInt(splitdate[0]);
            mm = parseInt(splitdate[1]);
            yy = parseInt(splitdate[2]);
            var ListofDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            if (mm === 1 || mm > 2) {
                if (dd > ListofDays[mm - 1]) {
                    //alert('Invalid date format!');
                    $('#PeriodEnd').css('border-color', 'Red');
                    isValid = false;
                }
            }
            if (mm === 2) {
                lyear = false;
                if ((!(yy % 4) && yy % 100) || !(yy % 400)) {
                    lyear = true;
                }
                if ((lyear === false) && (dd >= 29)) {
                    //alert('Invalid date format!');
                    $('#PeriodEnd').css('border-color', 'Red');
                    isValid = false;
                }
                if ((lyear === true) && (dd > 29)) {
                    //alert('Invalid date format!');
                    $('#PeriodEnd').css('border-color', 'Red');
                    isValid = false;
                }
            }
        }
        else {
            //alert("Invalid date format!");
            $('#PeriodEnd').css('border-color', 'Red');
            isValid = false;
        }

        if (isValid === false)
            $('#PeriodEnd').css('border-color', 'Red');
        else
            $('#PeriodEnd').css('border-color', 'lightgrey');
    }

    return isValid;
}

function getFormattedDate(date) {
    var year = date.getFullYear();

    var month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;

    var day = date.getDate().toString();
    day = day.length > 1 ? day : '0' + day;

    return day + '/' + month + '/' + year;
}