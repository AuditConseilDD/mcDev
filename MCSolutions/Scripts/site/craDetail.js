//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

function loadTableHeader() {
    $.ajax({
        url: "/CRA/LibColListByCRA",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        data: { idCRA: $('#crtCRA').val() },
        dataType: "json",
        success: function (result) {
            var html = '';
            html += '<tr>';
            html += '<th style="width: 30%" scope="col">Date</th>';
            html += result.length > 0 ? '<th style="width: 30%" scope="col">Date</th>' : '';
            $.each(result, function (key, item) {
                html += '<th scope="col">' + item.LibShort + '</th>';
            });
            if (result.length > 0)
                html += '</tr>';
            else
                html = '';
            $('.thead').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function loadLibColList() {
    $.ajax({
        url: "/CRA/LibColList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            html += '<option value="0" selected>---</option>';
            $.each(result, function (key, item) {
                html += '<option value="' + item.Id + '">' + item.LibShort + '</option>';
            });
            $('.libColList').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//Load Data function 
function loadData() {

    loadTableHeader();

    loadLibColList();

    $.ajax({
        url: "/CRA/SaisirCRAList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        data: { idCRA: $('#crtCRA').val() },
        dataType: "json",
        success: function (result) {
            var html = result;
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//Add Data Function   
function Add() {
    //$("div#myModal").hide("slow", function () {
    //    alert("Animation complete.");
    //});

    //$("div").click(function () {
    //    $(this).hide(2000, function () {
    //        $(this).remove();
    //    });
    //});
    //return false;

    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        CRAActiviteId: $('#crtCRA').val(),
        DateBegin: $('#dateBegin').val(),
        DateEnd: $('#dateBegin').val(),
        CRAlibeleColId: $('.libColList').val(),
        Quantity: $('.temps').val()
    };
    $.ajax({
        url: "/CRA/AddActivite",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();

            //$('#myModal').modal('hide');
            //setTimeout(function () { $('#myModal').modal('hide'); }, 1000);

            clearTextBox('', '', '');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function validate() {
    var isValid = true;
    if ($.trim($('#dateBegin').val()) == "") {
        $('#dateBegin').css('border-color', 'Red');
        isValid = false;
    }
    else {
        //var Val_date = $.trim($('#dateBegin').val());
        var date = new Date($.trim($('#dateBegin').val()));

        Val_date = "" + getFormattedDate(date);
        var rawmonth = Val_date.substr(0, 2);
        var rawday = Val_date.substr(3, 2);
        var rawyear = Val_date.substr(6, 4);
        var checkdate = new Date(Val_date);

        var eau = (rawmonth == checkdate.getMonth() + 1) && (rawday == checkdate.getDate()) && (rawyear == checkdate.getFullYear());

        //var dateformat = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
        var dateformat = /^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$/;

        if (Val_date.match(dateformat)) {
            var seperator1 = Val_date.split('/');
            var seperator2 = Val_date.split('-');

            if (seperator1.length > 1) {
                var splitdate = Val_date.split('/');
            }
            else if (seperator2.length > 1) {
                var splitdate = Val_date.split('-');
            }
            var dd = parseInt(splitdate[0]);
            var mm = parseInt(splitdate[1]);
            var yy = parseInt(splitdate[2]);
            var ListofDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            if (mm == 1 || mm > 2) {
                if (dd > ListofDays[mm - 1]) {
                    //alert('Invalid date format!');
                    $('#dateBegin').css('border-color', 'Red');
                    isValid = false;
                }
            }
            if (mm == 2) {
                var lyear = false;
                if ((!(yy % 4) && yy % 100) || !(yy % 400)) {
                    lyear = true;
                }
                if ((lyear == false) && (dd >= 29)) {
                    //alert('Invalid date format!');
                    $('#dateBegin').css('border-color', 'Red');
                    isValid = false;
                }
                if ((lyear == true) && (dd > 29)) {
                    //alert('Invalid date format!');
                    $('#dateBegin').css('border-color', 'Red');
                    isValid = false;
                }
            }
        }
        else {
            //alert("Invalid date format!");
            $('#dateBegin').css('border-color', 'Red');
            isValid = false;
        }

        if (isValid == false)
            $('#dateBegin').css('border-color', 'Red');
        else
            $('#dateBegin').css('border-color', 'lightgrey');
    }



    if ($.trim($(".libColList").val()) == "0") {
        $('.libColList').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('.libColList').css('border-color', 'lightgrey');
    }

    if ($.trim($('.temps').val()) == "") {
        $('.temps').css('border-color', 'Red');
        isValid = false;
    }
    else {

        if (!$.isNumeric($.trim($('.temps').val()))) {
            $('.temps').css('border-color', 'Red');
        } else {
            $('.temps').css('border-color', 'lightgrey');
        }
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


function clearTextBox(_cralibelecolid, _datebegin, _quantity) {
    var isNew = true;

    if (_datebegin != "") {
        var newDate = new Date(_datebegin);//.format('YYYY-MM-DD');
        $('#dateBegin').val(_datebegin);
        isNew = false;
    }
    else
        $('#dateBegin').val("");

    if (_cralibelecolid != "") {
        $(".libColList").val(_cralibelecolid);
        isNew = false;
    }
    else
        $(".libColList").val(0);

    if (_quantity != "") {
        $('#temps').val(parseFloat(_quantity.replace(",", ".")).toFixed(2));
        isNew = false;
    }
    else
        $('#temps').val("");

    if (isNew == false) {
        $("#btnAdd").css("display", "none");
        $("#btnUpdate").css("display", "");
        //$(this).find('h5#modal-title').text("Modifier une activité")
        $('#exampleModalLabel').text("Modifier une activité");
    }
    else {
        $("#btnAdd").css("display", "");
        $("#btnUpdate").css("display", "none");
        //$(this).find('h5#modal-title').text("Ajouter une activité");
        $('#exampleModalLabel').text("Ajouter une activité");
    }

    $("#btnAdd").attr("data-dismiss", "modal");
    $("#btnUpdate").attr("data-dismiss", "modal");
}


//function for updating employee's record  
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        CRAActiviteId: $('#crtCRA').val(),
        DateBegin: $('#dateBegin').val(),
        DateEnd: $('#dateBegin').val(),
        CRAlibeleColId: $('.libColList').val(),
        Quantity: $('.temps').val().replace(".", ",")
    };
    $.ajax({
        url: "/CRA/UpdateActivite",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            //setTimeout(function () { $('#myModal').modal('hide'); }, 1000);

            clearTextBox('', '', '');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function test() {

    $("#myModal").show();

    //$("div#myModal").hide("slow", function () {
    //    alert("Animation complete.");
    //});
}

function onImgSuccess(data) {
    $.map(data.d, function (listitem) {
        $('<tr> <td>' + listitem.Text + '</td> <td>' + listitem.Value + ' </td> </tr>').appendTo(".tbody");
    });
}


function loadData_OLD() {
    var grid = $('#grid').grid({
        dataSource: '/CRA/SaisirCRAList',
        columns: [
            { field: 'DateBegin', title: 'Date Begin...', type: 'date', width: 150, sortable: true },
            { field: 'DateEnd', title: 'Date End.....', type: 'date', width: 150, sortable: true },
            { field: 'CRAlibeleColId', title: 'Libellé ColID', sortable: true },
            { field: 'Quantity', title: 'Quantity.....', sortable: true },
            { field: 'CreationDate', title: 'Creation Date', type: 'date', width: 150 },
            { field: 'CreationBY', title: 'Creation BY..', width: 150 },
            { field: 'modificationDate', title: 'ModificationD', type: 'date', width: 150 },
            { field: 'ModificationBY', title: 'Modified By..', width: 150 }
        ],
        pager: { limit: 5 }
    });
}

function getFormattedDate(date) {
    var year = date.getFullYear();

    var month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;

    var day = date.getDate().toString();
    day = day.length > 1 ? day : '0' + day;

    return day + '/' + month + '/' + year;
}

//(function ($) {
//    $.fn.extend({
//        makeSortable: function () {
//            var MyTable = this;

//            var getCellValue = function (row, index) {
//                return $(row).children('td').eq(index).text();
//            };

//            MyTable.find('th').click(function () {
//                var table = $(this).parents('table').eq(0);

//                // Sort by the given filter
//                var rows = table.find('tr:gt(0)').toArray().sort(function (a, b) {
//                    var index = $(this).index();
//                    var valA = getCellValue(a, index), valB = getCellValue(b, index);

//                    return $.isNumeric(valA) && $.isNumeric(valB) ? valA - valB : valA.localeCompare(valB);
//                });

//                this.asc = !this.asc;

//                if (!this.asc) {
//                    rows = rows.reverse();
//                }

//                for (var i = 0; i < rows.length; i++) {
//                    table.append(rows[i]);
//                }
//            });
//        }
//    });
//})(jQuery);

//$(function () {
//    $("#yeah").makeSortable();
//});

//$('th').each(function (col) {
//    $(this).hover(
//        function () {
//            $(this).addClass('focus');
//        },
//        function () {
//            $(this).removeClass('focus');
//        }
//    );
//    $(this).click(function () {
//        if ($(this).is('.asc')) {
//            $(this).removeClass('asc');
//            $(this).addClass('desc selected');
//            sortOrder = -1;
//        } else {
//            $(this).addClass('asc selected');
//            $(this).removeClass('desc');
//            sortOrder = 1;
//        }
//        $(this).siblings().removeClass('asc selected');
//        $(this).siblings().removeClass('desc selected');
//        var arrData = $('table').find('tbody >tr:has(td)').get();
//        arrData.sort(function (a, b) {
//            var val1 = $(a).children('td').eq(col).text().toUpperCase();
//            var val2 = $(b).children('td').eq(col).text().toUpperCase();
//            if ($.isNumeric(val1) && $.isNumeric(val2))
//                return sortOrder == 1 ? val1 - val2 : val2 - val1;
//            else
//                return (val1 < val2) ? -sortOrder : (val1 > val2) ? sortOrder : 0;
//        });
//        $.each(arrData, function (index, row) {
//            $('tbody').append(row);
//        });
//    });
//});


////Add Data Function   
//function Add() {
//    var res = validate();
//    if (res == false) {
//        return false;
//    }
//    var empObj = {
//        MOIS: $('#MOIS').val(),
//        LIB_CLIENT: $('#LIB_CLIENT').val(),
//        LIB_RESPONSABLE: $('#LIB_RESPONSABLE').val()
//    };
//    $.ajax({
//        url: "/CRA/Add",
//        data: JSON.stringify(empObj),
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadData();
//            $('#myModal').modal('hide');
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}

////Function for getting the Data Based upon Employee ID  
//function GetCRAByID(CRAId) {
//    $('#MOIS').css('border-color', 'lightgrey');
//    $('#LIB_CLIENT').css('border-color', 'lightgrey');
//    $('#LIB_RESPONSABLE').css('border-color', 'lightgrey');
//    //$('#Country').css('border-color', 'lightgrey');
//    $.ajax({
//        url: "/CRA/GetCRAByID/" + CRAId,
//        typr: "GET",
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        success: function (result) {
//            $('#CRAId').val(result.CRAId);
//            $('#MOIS').val(result.MOIS);
//            $('#LIB_CLIENT').val(result.LIB_CLIENT);
//            $('#LIB_RESPONSABLE').val(result.LIB_RESPONSABLE);
//            //$('#Country').val(result.Country);

//            $('#myModal').modal('show');
//            $('#btnUpdate').show();
//            $('#btnAdd').hide();
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//    return false;
//}

////function for updating employee's record  
//function Update() {
//    var res = validate();
//    if (res == false) {
//        return false;
//    }
//    var empObj = {
//        EmployeeID: $('#EmployeeID').val(),
//        Name: $('#Name').val(),
//        Age: $('#Age').val(),
//        State: $('#State').val(),
//        Country: $('#Country').val(),
//    };
//    $.ajax({
//        url: "/CRA/Update",
//        data: JSON.stringify(empObj),
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadData();
//            $('#myModal').modal('hide');
//            $('#EmployeeID').val("");
//            $('#Name').val("");
//            $('#Age').val("");
//            $('#State').val("");
//            $('#Country').val("");
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}

////function for deleting employee's record  
//function Delele(ID) {
//    var ans = confirm("Are you sure you want to delete this Record?");
//    if (ans) {
//        $.ajax({
//            url: "/CRA/Delete/" + ID,
//            type: "POST",
//            contentType: "application/json;charset=UTF-8",
//            dataType: "json",
//            success: function (result) {
//                loadData();
//            },
//            error: function (errormessage) {
//                alert(errormessage.responseText);
//            }
//        });
//    }
//}

////Function for clearing the textboxes  
//function clearTextBox() {
//    $('#MOIS').val("");
//    $('#LIB_CLIENT').val("");
//    $('#LIB_RESPONSABLE').val("");
//    //$('#State').val("");
//    //$('#Country').val("");
//    $('#btnUpdate').hide();
//    $('#btnAdd').show();
//    $('#MOIS').css('border-color', 'lightgrey');
//    $('#LIB_CLIENT').css('border-color', 'lightgrey');
//    $('#LIB_RESPONSABLE').css('border-color', 'lightgrey');
//    //$('#Country').css('border-color', 'lightgrey');
//}
////Valdidation using jquery  
//function validate() {
//    var isValid = true;
//    if ($.trim($('#MOIS').val()) == "") {
//        $('#MOIS').css('border-color', 'Red');
//        isValid = false;
//    }
//    else {
//        $('#MOIS').css('border-color', 'lightgrey');
//    }

//    if ($.trim($('#LIB_CLIENT').val()) == "") {
//        $('#LIB_CLIENT').css('border-color', 'Red');
//        isValid = false;
//    }
//    else {
//        $('#LIB_CLIENT').css('border-color', 'lightgrey');
//    }

//    if ($.trim($('#LIB_RESPONSABLE').val()) == "") {
//        $('#LIB_RESPONSABLE').css('border-color', 'Red');
//        isValid = false;
//    }
//    else {
//        $('#LIB_RESPONSABLE').css('border-color', 'lightgrey');
//    }

//    return isValid;
//}  