// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var populate = function () {
    $.get("api/toons", function (data) {
        var html = "";

        $.each(data, function (d) {
            html += "<li>" + d + "</li>";
        });

        $("#toons").append(html);

        console.log("success");
    })
    //.done(function () {
    //    console.log("second success");
    //})
    .fail(function () {
        console.error("error");
    })
    .always(function () {
        console.log("finished");
    });

    setTimeout(populate, 1000);
}

populate();
