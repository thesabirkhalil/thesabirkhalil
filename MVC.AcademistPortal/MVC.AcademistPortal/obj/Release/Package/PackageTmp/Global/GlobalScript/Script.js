/// <reference path="notification.js" />
var icons = {
    txt: '',
    loading: '<i class="fa fa-refresh fa-spin fa-fw"></i>',
}

$(function () {
    AppKey.id = $('input[id$=hdn_mst_clg_id]').val()
    AppKey.SchoolName = $('input[id$=hdn_mst_clg_name]').val()
    AppKey.Imglogo = $('input[id$=hdn_mst_clg_logo]').val()
    AppKey.BillingMode = $('input[id$=hdn_Billing_mode]').val()

   
})
$(document).ready(function () {
    $('input[type=text]').attr('autocomplete', 'off');
});
$('input[type=text]').attr('autocomplete', 'off');

var AppKey = {
    id: '', // Value Append on Runtime
    code: GetParameter(3),
    SchoolName: '',
    Imglogo: '',
    BillingMode: ''
}


var text = {
    error: '<span class="text-danger">{MSG}</span>',
    success: '<span class="text-success">{MSG}</span>',
    info: '<span class="text-warning">{MSG}</span>',
    replace: '{MSG}'
}


function Timef(date) {
    if (date) {
        date = new Date(date);
    }

    var d = date
    var hr = d.getHours();
    var min = d.getMinutes();
    if (min < 10) {
        min = "0" + min;
    }
    if (hr < 10) {
        hr = "0" + hr;
    }
    //var ampm = "AM";
    //if (hr > 12) {
    //    hr -= 12;
    //    ampm = "PM";
    //}
    console.log(hr + ":" + min)

    return hr + ":" + min + ":00";
}

function fn_isHide(val) {
    if (val == null || val == '') {
        //console.log(val, 'IF')
        return 'hide';
    }

    else {
        //console.log(val, 'else')
        return ''
    }
}

function btnDisabled(button, btntext, isDisabled) {
    button.html(btntext);
    button.attr('disabled', isDisabled);
}

function Validation(obj, ErrorMsg) {
    if (obj.val() == '' || obj.val() == null) {
        if (ErrorMsg != '') {
            notify(AlertStatus.error, ErrorMsg)
        }
        obj.focus();
        return true;
    }
    else {
        return false;
    }
}
function Validation_Number(obj, ErrorMsg) {

    if (obj.val() <= 0) {
        if (ErrorMsg != '') {
            notify(AlertStatus.error, ErrorMsg)
        }
        obj.focus();
        return true;
    }
    else {
        return false;
    }
}
function fnmedia(obj) {
    if (obj == 'V')
        return '<span class="text-warning" style="    FONT-SIZE: 20PX;"><i class="fa fa-video-camera" aria-hidden="true"></i></span>'
    if (obj == 'D')
        return '<span class="text-primary" style="    FONT-SIZE: 20PX;"><i class="fa fa-file-pdf-o" aria-hidden="true"></i></span>'



}

function fun_truefalse(obj) {

    if (obj == true)
        return '<span class="badge badge-success">Yes</span>'

    else if (obj == false)
        return '<span class="badge badge-danger">NO</span>'

    else
        return obj
}
function fun_trueletfalse(obj) {

    if (obj == true)
        return '<span class="badge badge-success">Lateral</span>'

    else if (obj == false)
        return ''

    else
        return obj
}
function err(xhr, reason, ex) {

    console.log(xhr, reason, ex)
    if (xhr.status == '401')
        notify(AlertStatus.error, "Please Login First", "Session Expiry");
    else
        notify(AlertStatus.error, "Opsss! We Had some technical problems during your last operation.", "Technical Problems");
}

function fnststxt(obj) {
    if (obj == 'A')
        return '<span class="text-success"><i class="fa fa-check-circle" aria-hidden="true"></i></span>'
    if (obj == 'B')
        return '<span class="text-danger"><i class="fa fa-times-circle" aria-hidden="true"></i></span>'
    if (obj == 'P')
        return '<span class="text-warning"><i class="fa fa-question-circle" aria-hidden="true"></i></span>'



}
function fnmedia(obj) {
    if (obj == 'V')
        return '<span class="text-warning" style="    FONT-SIZE: 20PX;"><i class="fa fa-video-camera" aria-hidden="true"></i></span>'
    if (obj == 'D')
        return '<span class="text-primary" style="    FONT-SIZE: 20PX;"><i class="fa fa-file-pdf-o" aria-hidden="true"></i></span>'



}

function fn__isHide(val) {
    if (val) {
        return 'hide';
    }

    else {
        return ''
    }
}
function fn_Hide(val) {
    if (val == null || val == '') {
        //console.log(val, 'IF')
        return 'hide';
    }

    else {
        //console.log(val, 'else')
        return ''
    }
}
function fn__Date(date) {

    if (!date)
        return '';


    if (date) {
        date = new Date(date);
    }
    var m_names = new Array("Jan", "Feb", "Mar",
        "Apr", "May", "Jun", "Jul", "Aug", "Sep",
        "Oct", "Nov", "Dec");

    var d = date
    var curr_date = d.getDate();
    var curr_month = d.getMonth();
    var curr_year = d.getFullYear();

    return (curr_date + "-" + m_names[curr_month]
        + "-" + curr_year)
}
function convertTime24to12(time24) {
    var tmpArr = time24.split(':'), time12;
    if (+tmpArr[0] == 12) {
        time12 = tmpArr[0] + ':' + tmpArr[1] + ' pm';
    } else {
        if (+tmpArr[0] == 00) {
            time12 = '12:' + tmpArr[1] + ' am';
        } else {
            if (+tmpArr[0] > 12) {
                time12 = (+tmpArr[0] - 12) + ':' + tmpArr[1] + ' pm';
            } else {
                time12 = (+tmpArr[0]) + ':' + tmpArr[1] + ' am';
            }
        }
    }
    return time12;
}
function TimeFormat(date) {
    if (date) {
        date = new Date(date);
    }

    var d = date
    var hr = d.getHours();
    var min = d.getMinutes();
    if (min < 10) {
        min = "0" + min;
    }
    var ampm = "AM";
    if (hr > 12) {
        hr -= 12;
        ampm = "PM";
    }
    return hr + ":" + min + " " + ampm;
}

function Time(time) {
    if (time) {
        time = new Time(time);
    }

    var d = time
    console.log(time,1)
    var hr = d.getHours();
    var min = d.getMinutes();
    if (min < 10) {
        min = "0" + min;
    }
    var ampm = "AM";
    if (hr > 12) {
        hr -= 12;
        ampm = "PM";
    }
    return hr + ":" + min + " " + ampm;
}
function fn__DateTimeFormat(date) {
    if (!date)
        return '';
    if (date) {
        date = new Date(date);
    }
    var m_names = new Array("Jan", "Feb", "Mar",
        "Apr", "May", "Jun", "Jul", "Aug", "Sep",
        "Oct", "Nov", "Dec");

    var d = date
    var curr_date = d.getDate();
    var curr_month = d.getMonth();
    var curr_year = d.getFullYear();

    var hr = d.getHours();
    var min = d.getMinutes();
    if (min < 10) {
        min = "0" + min;
    }
    var ampm = "AM";
    if (hr > 12) {
        hr -= 12;
        ampm = "PM";
    }
    else if (hr == 12) {
        ampm = "PM";
    }

    return curr_date + "-" + m_names[curr_month]
        + "-" + curr_year + " " + hr + ":" + min + " " + ampm;
}
function fn_DateTime(date) {
    if (date) {
        date = new Date(date);
    }
    var m_names = new Array("Jan", "Feb", "Mar",
        "Apr", "May", "Jun", "Jul", "Aug", "Sep",
        "Oct", "Nov", "Dec");

    var d = date
    var curr_date = d.getDate();
    var curr_month = d.getMonth();
    var curr_year = d.getFullYear();

    var hr = d.getHours();
    var min = d.getMinutes();
    if (min < 10) {
        min = "0" + min;
    }
    var ampm = "AM";
    if (hr > 12) {
        hr -= 12;
        ampm = "PM";
    }
    else if (hr == 12) {
        ampm = "PM";
    }

    return  hr + ":" + min + " " + ampm;
}
function fn_DateTimeFormat(date) {
    if (date) {
        date = new Date(date);
    }
    var m_names = new Array("Jan", "Feb", "Mar",
        "Apr", "May", "Jun", "Jul", "Aug", "Sep",
        "Oct", "Nov", "Dec");

    var d = date
    var curr_date = d.getDate();
    var curr_month = d.getMonth();
    var curr_year = d.getFullYear();

    var hr = d.getHours();
    var min = d.getMinutes();
    if (min < 10) {
        min = "0" + min;
    }
    var ampm = "AM";
    if (hr > 12) {
        hr -= 12;
        ampm = "PM";
    }
    else if (hr == 12) {
        ampm = "PM";
    }

    return curr_date + "-" + m_names[curr_month]
        + "-" + curr_year + " " + hr + ":" + min + " " + ampm;
}

function doExport(selector, params) {
    var options = {
        //ignoreRow: [1,11,12,-2],
        //ignoreColumn: [0,-1],
        //pdfmake: {enabled: true},
        tableName: 'Countries',
        worksheetName: 'Countries by population',
    }
    $.extend(true, options, params);

    $(selector).tableExport(options);
}




function ClearAll() {
    $('input[type=text]').val('');
    $('input[type=number]').val('');
    $('input[type=file]').val('');
    $('input[type=checkbox]').val('');
    $('input[type=radio]').val('');
    $('input[type=time]').val('');
    $('input[type=email]').val('');
    $('textarea').val('');
    $('select').val('');
}

function fn__booksts(obj) {
    if (obj == 'A')
        return '<span class="badge badge-success"> Available </span>'
    else if (obj == 'B')
        return '<span class="badge badge-primary"> Issued </span>'
    else  if (obj == 'RV')
        return '<span class="badge badge-primary">Reserved </span>'
    else if (obj == 'BD')
        return '<span class="badge badge-primary"> Binding </span>'
    else if (obj == 'LO')
        return '<span class="badge badge-primary"> Lost </span>'
    else  if (obj == 'DS')
        return '<span class="badge badge-primary"> Discard </span>'
    else   if (obj == 'AR')
        return '<span class="badge badge-primary"> Archieved</span>'
    else  if (obj == 'LP')
        return '<span class="badge badge-primary"> Lost & Paid</span>'
    else
        return obj
   
}
function fn__reqsts(obj) {
    if (obj == 'A')
        return '<span class="badge badge-success"> Approved </span>'
   
    else if (obj == 'P')
        return '<span class="badge badge-warning"> Pending</span>'
    else if (obj == 'D')
        return '<span class="badge badge-danger"> Decline</span>'
    else
        return obj

}
function fn__status(obj) {
    if (obj == 'A')
        return '<span class="badge badge-success">Active</span>'
   else if (obj == 'AP')
        return '<span class="badge badge-success">Approve</span>'
    else   if (obj == 'PO')
        return '<span class="badge badge-warning">Passout</span>'
    else if (obj == 'B')
        return '<span class="badge badge-primary">Blocked</span>'
    else if (obj == 'P')
        return '<span class="badge badge-warning">Pending</span>'
    else if (obj == 'PN')
        return '<span class="badge badge-warning">Pending</span>'
    else  if (obj == 'C')
        return '<span class="badge badge-danger">Cancel</span>'
    else  if (obj == 'DE')
        return '<span class="badge badge-danger">Deactive</span>'
    else if (obj == 'N')
        return '<span class="badge badge-danger">Not Interested</span>'
    else if (obj == 'S')
        return '<span class="badge badge-danger">Suspend</span>'
    else if (obj == 'DC')
        return '<span class="badge badge-danger">Decline</span>'
    else if (obj == 'R')
        return '<span class="badge badge-danger">Removed</span>'
    else
        return obj
  
}
function fn_Sts(obj) {
    if (obj == 'A')
        return '  <i class="fa fa-circle" aria-hidden="true" style="color: #2aaf82;"> </i>'
    if (obj == 'B')
        return '<i class="fa fa-circle" aria-hidden="true" style="color: #dc3545;"> </i>'
    if (obj == 'P')
        return '<i class="fa fa-circle" aria-hidden="true" style="color: #FF9800;"> </i>'
}
function fn_liveSts(obj) {
    if (obj == 'A')
        return '  <i class="fa fa-circle" aria-hidden="true" style="color: #FF9800;"> A</i>'
    if (obj == 'B')
        return '<i class="fa fa-circle" aria-hidden="true" style="color: #dc3545;">B </i>'
    if (obj == 'P')
        return '<i class="fa fa-circle" aria-hidden="true" style="color: #2aaf82;"> P</i>'
}
function fn__getGender(obj) {
    if (obj == 'M')
        return 'Male'
    else if (obj == 'F')
        return 'Female'
    else if (obj == 'O')
        return 'other'
    else
        return "NA"
}
function getusertype(obj) {
    if (obj == 'A')
        return 'Admin'
    if (obj == 'E')
        return 'Enquiry'
    if (obj == 'O')
        return 'other'

}


function GetParameter(ndx) {
    var URL = window.location.href;
    console.log(URL.split('/'))
    return URL.split('/')[ndx];
}

$(function () {
    $('.datepicker').datepicker({ format: 'dd-M-yyyy' })
    $('.datetimepicker').datetimepicker({
        format: "dd-M-yyyy HH:ii P",
        showMeridian: true,
        autoclose: true,
        todayBtn: true
    });
    $('.table-datatable').dataTable()
})


function Fn__GenderIcon(val) {
    if (val == "M")
        return '<i class="fa fa-male" title="Male" aria-hidden="true" style="color:green;"></i>'
    else if (val == "F")
        return '<i class="fa fa-female" title="FeMale" aria-hidden="true" style="color:red;"></i>'
    else
        return '<i class="fa fa-transgender" title="Others" aria-hidden="true" style="color:blue;"></i>'

}
function Fn__paymode(val) {
    if (val == "Cash")
        return '<i class="fa fa-money mr-2" title="Cash" data-toggle="tooltip" aria-hidden="true" style="color:green;"></i>'
    else if (val == "Cheque")
        return '<i class="fa fa-newspaper-o mr-2" data-toggle="tooltip" title="Cheque" aria-hidden="true" style="color:#607d8b;"></i>'
    else if (val == "Credit/Debit Card")
        return '<i class="fa fa-credit-card-alt  mr-2" data-toggle="tooltip" title="Credit/Debit Card" aria-hidden="true" style="color:#795548;"></i>'
    else if (val == "NEFT/IMPS/Bank Transfer")
        return '<i class="fa fa-university mr-2" data-toggle="tooltip" title="NEFT/IMPS/Bank Transfer" aria-hidden="true" style="color:#ff9800;"></i>'
    else if (val == "Student Credit Card")
        return '<i class="fa fa-address-card mr-2" data-toggle="tooltip" title="Student Credit Card" aria-hidden="true" style="color:#8bc34a;"></i>'
    else if (val == "Bank Loan")
        return '<i class="fa fa-wpforms mr-2" data-toggle="tooltip" title="Bank Loan" aria-hidden="true" style="color:#009688;"></i>'
    else if (val == "Demand Draft")
        return '<i class="fa fa-list-alt mr-2" data-toggle="tooltip" title="Demand Draft" aria-hidden="true" style="color:#03a9f4;"></i>'
    else if (val == "Enquiry Wallet")
        return '<i class="fa fa-briefcase mr-2" data-toggle="tooltip" title="Enquiry Wallet" aria-hidden="true" style="color:#3f51b5;"></i>'
    else if (val == "Student Wallet")
        return '<i class="icon icon-wallet mr-2" data-toggle="tooltip" title="Student Wallet" aria-hidden="true" style="color:#9c27b0;"></i>'
    else
        return val

}
function Fn__GenderIconBox(val) {
    if (val == "M")
        return '<span class="badge badge-info m-l-10 hidden-sm-down"><i class="fa fa-male mr-2" title="Male" aria-hidden="true"></i>Male</span>'
    else if (val == "F")
        return '<span class="badge badge-danger m-l-10 hidden-sm-down"><i class="fa fa-female mr-2" title="Male" aria-hidden="true"></i>Female</span>'
    else
        return '<span class="badge badge-success m-l-10 hidden-sm-down"><i class="fa fa-transgender mr-2" title="Male" aria-hidden="true"></i>Other</span>'

}
function fn__isNullOrEmptyZero(strvalue) {
    if (strvalue == null || strvalue == '')
        return 0;
    return strvalue;
}
function fn__isNullOrEmpty(strvalue, opt_value) {
    if (strvalue == null || strvalue == '')
        return opt_value;
    else
    return strvalue;
}

function fn__PaymentType_CR_DR(obj) {
    if (obj == 'cr')
        return 'CR';
    else if (obj == 'dr')
        return 'DR';
    else
        return obj
}

