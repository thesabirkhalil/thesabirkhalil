

var AlertStatus = {
    success: 'success',
    info: 'info',
    warning: 'warning',
    error: 'error'
}

function notify(AlertStatus, message, title) {

    if (!title)
        title = "";

    toastr.remove();

    toastr[AlertStatus](message, title, {
        positionClass: "toast-top-right"
    });



    //swal(title, message, AlertStatus);
   // Command: toastr[AlertStatus](message, title)
    //toastr.options = {
    //    "closeButton": true,
    //    "debug": false,
    //    "newestOnTop": true,
    //    "progressBar": false,
    //    "positionClass": "top-full-width",
    //    "preventDuplicates": true,
    //    "onclick": null,
    //    "showDuration": "300",
    //    "hideDuration": "1000",
    //    "timeOut": "1000",
    //    "extendedTimeOut": "1000",
    //    "showEasing": "swing",
    //    "hideEasing": "linear",
    //    "showMethod": "fadeIn",
    //    "hideMethod": "fadeOut"
    //}

}