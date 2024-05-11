//Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
//for details on configuring this project to bundle and minify static web assets.

//Write your JavaScript code.

function changeCulture() {
    let isChecked = document.getElementById('flexCultureSwitch').checked;
    let culture;
    if (isChecked) {
        culture = "bg-BG"
    }
    else {
        culture = "en-US"
    }

    $.ajax({
        method: 'GET',
        url: '/Home/SetLanguage',
        data: { culture: culture },
        success: function () {
            location.reload();
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}