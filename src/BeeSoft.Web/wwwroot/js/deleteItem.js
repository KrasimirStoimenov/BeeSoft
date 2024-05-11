function showDeleteModal(id) {
    $('#deleteModal').modal('show')
    $('#deleteBtn').attr('item-id', id);
}

async function deleteItem() {
    const deleteBtn = document.getElementById('deleteBtn');
    const itemIdAttr = deleteBtn.getAttribute('item-id');
    const itemId = Number(itemIdAttr);

    const pathElements = deleteBtn.ownerDocument.location.pathname
        .split('/')
        .filter(x => x);

    const controllerName = pathElements.length > 1 ? pathElements[1] : pathElements[0];

    try {
        const res = await fetch(`/${controllerName}/Delete/`+ itemId);

        if (res.status != 200) {
            throw new Error(`${res.status}:${res.statusText}`);
        }

        location.reload();

    } catch (error) {
        alert(error.responseText);
    }

    //$.ajax({
    //    url: `/${controllerName}/Delete`,
    //    data: { id: itemId },
    //    success: function () {
    //        location.reload();
    //    },
    //    error: function (error) {
    //        alert(error.responseText);
    //    }
    //});
}