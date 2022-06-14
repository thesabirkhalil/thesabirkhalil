var studentLst = [];
var $CartList = [];
var intake = [];
var program = [];
var sts = [];
var count = 0;
$(document).ready(function () {
   
    GetCollege();
    $('#ddlcollege').change(function () {
    
        GetProgramList($(this).val());
       
    })
    $('#btnSearch').click(function () {
        var ddlcollege = $('#ddlcollege');
        var ddlprog = $('#ddlprog');
        var ddlsem = $('#ddlsem');
        var ddlsession = $('#ddlsession');
        var ddlsts = $('#ddlsts');
        if (Validation(ddlcollege, 'Please choose College')) return false;
        if (Validation(ddlprog, 'Please choose program')) return false;
        if (Validation(ddlsem, 'Please choose sem/year')) return false;
        if (Validation(ddlsession, 'Please Choose Session')) return false;
        if (Validation(ddlsts, 'Please Choose Status')) return false;
        $('#studentlist tbody').empty();
        GetStudentList();
    });
   
    $('#btnClearALl').click(function () {
        ClearAll();
        $('#studentlist tbody').empty();
        GetStudentList();
    })
    
    $('#popdemnd').click(function () {
        
        if (count == 0) {
            notify(AlertStatus.error, 'Please Select Student', 'Select Student');
            return false;
        }
        $('#txtnoof').html(count)
        $('#txtprog').html($('#ddlprog option:selected').html())
        $('#txtamt').html($('#ddlcollege option:selected').attr('data-amt'))
    });

   

    $('#btngeneratdemand').click(function () {
        var btn = $(this);
        icons.txt = btn.html();
        
        var ddlsemupload = $('#ddlsemupload');
        var ddlcollege = $('#ddlcollege');
        var ddlprog = $('#ddlprog');
        var ddlsession = $('#ddlsession');
        var ddlsts = $('#ddlsts');
        var ddlsem = $('#ddlsem');
        if (Validation(ddlcollege, 'Please choose College')) return false;
        if (Validation(ddlprog, 'Please choose program')) return false;
        if (Validation(ddlsem, 'Please choose sem/year')) return false;
        if (Validation(ddlsession, 'Please Choose Session')) return false;
        if (Validation(ddlsts, 'Please Choose Status')) return false;
        if (Validation(ddlsemupload, 'Please Choose Post  sem/year')) return false;
        $.ajax({
            url: '/Ajax/PostErpFee',
            method: 'Post',
            dataType: 'json',
            data: {
                URLCode: $('#ddlcollege').val(),
                intake: $('#ddlsession').val(),
                sts: $('#ddlsts').val(),
                Collegeno: $('#txtcollgeno').val(),
                program: $('#ddlprog').val(),
                sem: $('#ddlsem').val(),
                ERPSem: $('#ddlsemupload').val(),
            },
            beforeSend: function () {
                btnDisabled(btn, icons.loading, true)
            },
            success: function (res) {
                res = JSON.parse(res);
                console.log(res,"h")
                if (res.isSuccess) {
                    notify(AlertStatus.success, ' Demand Createed', 'Success!!!')
                   
                    $('#pup_demand').modal('hide')

                    
                  
                    window.location.reload();
                }
                
                else {
                    console.log(res)
                    notify(AlertStatus.error, 'Not Student Found', res.Message)
                }
            },
            error: err,
            complete: function () {
                btnDisabled(btn, icons.txt, false)
            }
        })

    })


    $('#ddlprog').change(function () {
       
       
        Getsem();
        Getseme();
        GetddlAcademic();
    })


})
function Getsem() {
    var ddl = $('#ddlsem')
    ddl.empty();
    $.ajax({
        url: '/Ajax/GetSemester',
        method: 'Get',
        dataType: 'json',
        async: false,
        data: {
            Progid: $("#ddlprog").val(),
            URLCode: $("#ddlcollege").val(),
        },
        beforeSend: function () {
            ddl.append('<option value="">Select Sem/Year</option>')
        },
        success: function (res) {
            res = JSON.parse(res);
            $(res).each(function (i, d) {
                ddl.append('<option value="' + d.id + '">' + d.SemName + '</option>')
            })
        },
        error: err,
        complete: function () {

        }
    })
}
function Getseme() {
    var ddl = $('#ddlsemupload')
    ddl.empty();
    $.ajax({
        url: '/Ajax/GetSemester',
        method: 'Get',
        dataType: 'json',
        async: false,
        data: {
            Progid: $("#ddlprog").val(),
            URLCode: $("#ddlcollege").val(),
        },
        beforeSend: function () {
            ddl.append('<option value="">Select Sem/Year</option>')
        },
        success: function (res) {
            res = JSON.parse(res);
            $(res).each(function (i, d) {
                ddl.append('<option value="' + d.id + '">' + d.SemName + '</option>')
            })
        },
        error: err,
        complete: function () {

        }
    })
}
function GetStudentList() {

    var tbl = $('#tblStudentLst tbody');
    tbl.empty();

    $.ajax({
        url: '/Ajax/StudentListForERPFee',
        method: 'Get',
        async: false,
        data: {
            URLCode: $('#ddlcollege').val(),
            intake: $('#ddlsession').val(),
            sts: $('#ddlsts').val(),
            Collegeno: $('#txtcollgeno').val(),
            program: $('#ddlprog').val(),
            sem: $('#ddlsem').val(),
            
        },
        dataType: 'json',
        success: function (res) {
            res = JSON.parse(res);
            count = res.length;
            if (res.length > 0) {
                $('.btnd').removeClass('hide')
            }
            $(res).each(function (i, d) {
               
                tbl.append(`<tr>
                                <td>`+ (i + 1) + `</td>
                                <td>` + func__sts(d.sts) + `&nbsp;<span>` + d.CollegeNo + `</span></td>
                                <td>` + d.Name + `</td>
                                <td>`+ d.ProgramName + `</td>
                                <td>`+ d.SemName + `</td>
                                <td>`+ d.YearName + `</td>
                            </tr>`)
            })
        },
        error: err,
        complete: function () {

        }
    })
}



function func__sts(obj) {

    if (obj == 'P')
        return '<span class="badge badge-warning">P</span>'
    if (obj == 'A')
        return '<span class="badge badge-success">A</span>'
    if (obj == 'C')
        return '<span class="badge badge-warning">Cancle</span>'
    if (obj == 'S')
        return '<span class="badge badge-warning">Suspended</span>'
    if (obj == 'PO')
        return '<span class="badge badge-warning">Passout</span>'
    if (obj == 'DE')
        return '<span class="badge badge-danger"> <i class="fa fa-close"></i></span>'
}

function GetddlAcademic() {
    var ddl = $("#ddlsession");
    ddl.empty();
    $.ajax({
        url: '/Ajax/GetStudentBasedSession',
        method: 'Get',
        dataType: 'json',
        async: false,
        data: {

            program: $("#ddlprog").val(),
            URLCode: $("#ddlcollege").val(),
        },
        beforeSend: function () {
            ddl.append('<option value="">Select Session/Intake Year</option>')
        },
        success: function (res) {
            res = JSON.parse(res);
            $(res).each(function (i, d) {
                ddl.append('<option value="' + d.id + '">' + d.Name + '</option>')
            })
        },
        error: err,
        complete: function () {



        }
    })
}

function GetProgramList(clgcode) {
    var ddlPrgName = $('#ddlprog');
    ddlPrgName.empty();
    $.ajax({
        url: '/Ajax/GetProgram',
        method: 'Get',
        dataType: 'json',
        async: false,
        data: {

            URLCode: clgcode,
        },
        beforeSend: function () {
            ddlPrgName.append('<option value="">Select Program</option>')
        },
        success: function (res) {
            res = JSON.parse(res);
            $(res).each(function (i, d) {

                ddlPrgName.append('<option value="' + d.id + '">' + d.ProgramName + '</option>')
            })
        },
        error: err,
    })
}


function GetCollege() {
    var ddlcollege = $('#ddlcollege');
    ddlcollege.empty();
    $.ajax({
        url: '/Ajax/GetCollge',
        method: 'Get',
        dataType: 'json',
        async: false,
        data: {
        },
        beforeSend: function () {
            ddlcollege.append('<option value="">Select College</option>')
        },
        success: function (res) {
            res = JSON.parse(res);
            $(res).each(function (i, d) {
                if (d.BillingMode == 'STD')
                    ddlcollege.append('<option value="' + d.URLCode + '" data-amt="' + parseFloat(d.SubscriptionFeePM + d.TaxAmount) + '">' + d.CollegeName + '</option>')
            })
        },
        error: err,
    })
}


