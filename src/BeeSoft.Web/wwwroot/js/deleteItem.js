function showDeleteModal(id) {
    $('#deleteModal').modal('show')
    $('#deleteBtn').attr('item-id', id);
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