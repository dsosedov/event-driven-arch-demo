// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var populate = function () {
    $.get("api/siths", function (data) {
        var html = "";

        $.each(data, function (i, d) {
            html += "<li>" + d.name + "</li>";
        });

        $("#siths").html(html);

        console.log("success");
    })
    //.done(function () {
    //    console.log("second success");
    //})
    .fail(function (err) {
        console.error(err.status + " " + err.statusText);
    //})
    //.always(function () {
    //    console.log("finished");
    });

    setTimeout(populate, 5000);
}

populate();
