function confirm(title, body, cancelButtonTxt, okButtonTxt, callback) {

    var confirmModal = $('#modalConfirm');
    confirmModal.find('.modal-title').html(title);
    confirmModal.find('.modal-body').html(body);
    confirmModal.find('.btn-primary').html(okButtonTxt);

    confirmModal.find('.btn-primary').off();
    confirmModal.find('.btn-primary').click(function (event) {
        callback();
        confirmModal.modal('hide');
    });

    confirmModal.modal('show');
};



function CompareDate(from, to) {
    //var dateParts = from.split(" ");
    //var dateParts = from;
    var dayParts = from.split("/");
    // month is 0-based, that's why we need dataParts[1] - 1
    var date1 = Date.parse((dayParts[1] - 1) + '/' + dayParts[0] + '/' + dayParts[2] + ' 00:01');

    //dateParts = to.split(" ");
    dayParts = to.split("/");
    // month is 0-based, that's why we need dataParts[1] - 1
    var date2 = Date.parse((dayParts[1] - 1) + '/' + dayParts[0] + '/' + dayParts[2] + ' 23:59');
    return date2 > date1;
}