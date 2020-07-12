var datatable;

$(document).ready(() => {
    datatable = $('#book-table').DataTable({
        'ajax': {
            'url': '/api/book',
            'type': 'GET',
            'datatype': 'json'
        },
        'columns': [
            { 'data': 'name', 'width': '30%' },
            { 'data': 'author', 'width': '30%' },
            {
                'data': 'id',
                'render': function (data) {
                    return `
                        <div clas='text-center'>
                            <a href='/BookList/Edit?id=${data}' class='btn btn-success text-white' style='cursor:pointer;width:100px'> 
                                Edit
                            </a>

                            <a class='btn btn-danger text-white' style='cursor:pointer;width:100px'
                                onclick=ConfirmDelete('/api/book?id=${data}')> 
                                Delete
                            </a>
                        </div>
                    `
                }, 'width': '30%'
            }
        ],
        'language': {
            'emptyTable': 'no data found'
        },
        'width': '100%'
    })
});

function ConfirmDelete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "Delete",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}