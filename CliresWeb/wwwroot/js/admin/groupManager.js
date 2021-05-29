createCookie('page', 'group_detail', 1);

$(document).ready(function () {
    $('#tbodyGroupManager tr').dblclick(function () {
        var groupid = $(this).attr('groupid');
        createCookie('page', 'group_detail', 1);
        window.open('/admin/groupdetail/' + groupid, '_self');
    })
});


function AddGroup(action) {
    createCookie('page', 'group_detail', 1);
    window.location.href = '/admin/groupdetail';
}