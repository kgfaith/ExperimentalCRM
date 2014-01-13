$(function () {
    var $div = $("#placetypeid-ddl");

    $("#placetypeid-ddl").on('change', function () {
        $("#place-list-filter").trigger('submit');
    });

    $("#pagesize-ddl").on('change', function () {
        $("#page-size-form").trigger('submit');
    });
});