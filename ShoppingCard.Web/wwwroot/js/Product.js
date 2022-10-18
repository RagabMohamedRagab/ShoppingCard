$(document).ready(function () {
    $('#myTable').DataTable({
        ajax: "/Admin/Product/AllProducts",
        columns: [
            { data: 'name' },
            { data: 'description' },
            { data: 'price' },
            { data: 'category.name' },
            {
                data: "id",
                "render": function (data) {
                    return
                    `<a href="/Admin/Product/CreateUpdate?id=${data}" class="btn btn-primary">Update<a>
                      <a href="/Admin/Product/Delete?id=${data}" class="btn btn-danger>Delete</a>`
                }
            }
        ]
    });
});