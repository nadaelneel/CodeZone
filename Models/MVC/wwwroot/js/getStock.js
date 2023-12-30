myfun();
    $(document).ready(function () {
        $('#selectedStore , #selectedItem').change(function () {
            myfun();
        });
    });
function myfun() {
    var firstValue = $('#selectedStore').val();
    var secondValue = $('#selectedItem').val();
    $.ajax({
        url: '/Store_Item/GetStock',
        type: 'GET',
        data: { store_id: firstValue, item_id: secondValue },
        success: function (result) {
            $('#stock').val(result);
        },
        error: function () {
            alert('Error occurred while retrieving data.');
        }
    });
}