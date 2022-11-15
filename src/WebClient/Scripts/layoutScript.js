$(document).ready(function () {
    $("#Staff").click(function () {
        openForm("Staff/StaffList", "Staff List")
    })
})

$(document).ajaxStart(function () {
    $("#loadingContainer").show();
}).ajaxComplete(function () {
    $("#loadingContainer").hide();
})

function openForm(Action, Title) {
    $.ajax({
        url: Action,
        async: false,
        dataType: 'html',
        traditional: true,
        type: 'POST',
        success: function (content) {
            $("#dynamicContainer").html(content);
            $("#pageheading").html(Title);
            $("#pagename").html(Title);
        }
    })
}