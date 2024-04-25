﻿//Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
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

function showDeleteModal(id) {
    $('#deleteModal').modal('show')
    $('#deleteBtn').attr('item-id',id);
}

function deleteItem() {
    const deleteBtn = document.getElementById('deleteBtn');
    const itemIdAttr = deleteBtn.getAttribute('item-id');
    const itemId = Number(itemIdAttr);

    const pathElements = deleteBtn.ownerDocument.location.pathname
        .split('/')
        .filter(x => x);

    const controllerName = pathElements.length > 1 ? pathElements[1] : pathElements[0];

    $.ajax({
        url: `/${controllerName}/Delete`,
        data: { id: itemId },
        success: function () {
            location.reload();
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}