$("#MarcaId").change(function () {
    var marcaId = $('#MarcaId').val();
    
    $.get("/api/ModeloAPI?marcaId=" + marcaId, function (response) {
        $("#ModeloId").html(" ");

        $.each(response, function (key, value) {
            $('#ModeloId').html($("#ModeloId").html() + "<option value=" + value.ModeloId + " > " + value.Descripcion + "</option > ");
        });
    });
});