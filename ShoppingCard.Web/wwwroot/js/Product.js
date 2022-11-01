$(document).ready(function () {
    debugger;
    $('#myTable').DataTable({
        ajax: "/Admin/Product/AllProducts",
        columns: [
            { data: 'id' },
            { data: 'name' },
            { data: 'description' },
            { data: 'price' },
            { data: 'category.name' },
            {
                data: 'id',
                render: function (data, type) {
                    debugger;
                    return (type=="display")?
                    "<a class='btn btn-primary' style='margin-left:7rem' href='/Admin/Product/CreateUpdate/" + data + "'>" + "Update" +  "</a>" + "<a class='btn btn-danger' href='/Admin/Product/Delete/" + data + "'>" + "Delete" + "</a>":"_";
                    }

            }
        ]
    });
});
/*
 function Delete(id) {
    $.ajax({
        url: "/Admin/Product/Delete?Id=" + id,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            if (res == 1) {

            } else {

            }
        }
    });
}
 */