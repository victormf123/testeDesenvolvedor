$("#Enviar").click(function () {
    var id = $(this).attr("data-id");
    $("#myModal").load("Enviar", function () {
        $("#myModal").modal();
    });
});