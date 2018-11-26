//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();

    loadCRATYPEList();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/CRA/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            //var urel = '@Url.Action("SaisirCRA", "CRA", ' + new { idCRA = 1 } + ')';
            var link = '@Url.Action("SaisirCRA", "CRA", new { idCRA = "replace" })';
            var url = '/CRA/SaisirCRA/?idCRA=';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.MOIS + '</td>';
                html += '<td>' + item.NBTOTALJOURS + '</td>';
                html += '<td>' + item.LIB_CLIENT + '</td>';
                html += '<td>' + item.LIB_RESPONSABLE + '</td>';
                html += '<td>' + item.FK_IDSTATUT + '</td>';
                //html += '<td><a href="#" onclick="return GetCRAByID(' + item.CRAId + ')">Edit</a> | <a href="#" onclick="Delele()">Delete</a></td>';

                html += '<td>';
                html += '<div class="dropdown">';
                html += '	<button class="btn btn-primary" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">';
                html += '		<span class="oi oi-menu"></span>';
                html += '	</button>';
                html += '	<div class="dropdown-menu" aria-labelledby="dropdownMenuButton">';
                //link = link.replace("replace", item.CRAId);
                url = url + item.CRAId;
                //html += '		<a class="dropdown-item" href="' + url + '" >Afficher ce CRAZZk</a>';
                //html += '		<a class="dropdown-item" href="CRA/SaisirCRA/' + item.CRAId + '">Afficher ce CRA</a>';
                html += '		<a class="dropdown-item" href="' + url + '" >Afficher ce CRA</a>';
                html += '		<a class="dropdown-item" href="#" onclick="return GetCRAByID(' + item.CRAId + ')">Modifier ce CRA</a>';
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
    if (res == false) {
        return false;
    }
    var empObj = {
        MOIS: $('#MOIS').val(),
        LIB_CLIENT: $('#LIB_CLIENT').val(),
        LIB_RESPONSABLE: $('#LIB_RESPONSABLE').val()
    };
    $.ajax({
        url: "/CRA/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            //$('#myModal').modal('hide');

            clearTextBox();
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
    if (res == false) {
        return false;
    }
    var empObj = {
        EmployeeID: $('#EmployeeID').val(),
        Name: $('#Name').val(),
        Age: $('#Age').val(),
        State: $('#State').val(),
        Country: $('#Country').val(),
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
function clearTextBox() {
    $('#MOIS').val("");
    $('#LIB_CLIENT').val("");
    $('#LIB_RESPONSABLE').val("");
    //$('#State').val("");
    //$('#Country').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#MOIS').css('border-color', 'lightgrey');
    $('#LIB_CLIENT').css('border-color', 'lightgrey');
    $('#LIB_RESPONSABLE').css('border-color', 'lightgrey');
    //$('#Country').css('border-color', 'lightgrey');

    $("#btnAdd").attr("data-dismiss", "modal");
    $("#btnUpdate").attr("data-dismiss", "modal");
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($.trim($('#MOIS').val()) == "") {
        $('#MOIS').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MOIS').css('border-color', 'lightgrey');
    }

    if ($.trim($('#LIB_CLIENT').val()) == "") {
        $('#LIB_CLIENT').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LIB_CLIENT').css('border-color', 'lightgrey');
    }

    if ($.trim($('#LIB_RESPONSABLE').val()) == "") {
        $('#LIB_RESPONSABLE').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LIB_RESPONSABLE').css('border-color', 'lightgrey');
    }

    return isValid;
}




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
            $('.libColList').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}