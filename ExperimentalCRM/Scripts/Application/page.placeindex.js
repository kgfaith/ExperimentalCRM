$(function () {
    var something = 123;
    var $div = $("#placetypeid-ddl");

    $("#placetypeid-ddl").on('change', function () {
        $("#place-list-filter").trigger('submit');
    });

    $("#pagesize-ddl").on('change', function () {
        $("#place-list-filter").trigger('submit');
    });
});