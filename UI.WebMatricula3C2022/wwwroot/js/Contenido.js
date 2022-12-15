$(document).ready(function () {
    var codigoContenido;

    $('#ContenidosTabla').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });

    $("#btnMensajeExitoso").click(function () {
        $('#modalVentanaExitosa').modal('hide');
        limpiarCampos();
        location.reload();
    });

    $("#btnAgregarContenido").click(function () {
        if (validarCamposContenido()) {

            var codigoContenido = document.getElementById("IDAgregarContenidoCodigo").value;

            if (codigoContenido == "") {

                $.ajax({
                    url: '/Contenido/AgregarContenido',
                    type: 'POST',
                    data: {
                        NombreArchivo: document.getElementById("IDAgregarContenidoNombreArchivo").value,
                        Contenido: document.getElementById("IDAgregarContenidoContenido").value,
                        CodigoCarpeta: document.getElementById("IDAgregarContenidoCodigoCarpeta").value,
                        FechaCreacion: document.getElementById("IDAgregarContenidoFechaCreacion").value
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCampos();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }
            else {
                $.ajax({
                    url: '/Contenido/EditarContenido',
                    type: 'POST',
                    data: {
                        Codigo: document.getElementById("IDAgregarContenidoCodigo").value,
                        NombreArchivo: document.getElementById("IDAgregarContenidoNombreArchivo").value,
                        Contenido: document.getElementById("IDAgregarContenidoContenido").value,
                        CodigoCarpeta: document.getElementById("IDAgregarContenidoCodigoCarpeta").value,
                        FechaCreacion: document.getElementById("IDAgregarContenidoFechaCreacion").value
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCampos();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }

        }
    });

    $("#btnCancelarContenido").click(function () {
        limpiarCampos();
    });


    $("a[name='btnEditarContenido']").click(function () {

        codigoContenido = $(this).data("id");
        var verDetalle = VerDetalleContenido(codigoContenido);

    });

    $("a[name='btnEliminarContenido']").click(function () {

        codigoContenido = $(this).data("id");
        $('#modalVentanaEliminarContenido').modal('show');
    });

    $("#btnAbrirDialogAgregarContenido").click(function () {
        $('#modalAgregarContenido').modal('show');
    });

    $("#btnAceptarEliminarContenidoConfirmacion").click(function () {

        $.ajax({
            url: '/Contenido/EliminarContenido',
            type: 'POST',
            data: {
                Codigo: codigoContenido
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarContenido').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarContenidoConfirmacion").click(function () {
        $('#modalVentanaEliminarContenido').modal('hide');
        location.reload();
    });

    $("#textoBuscarContenido").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#ContenidosTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCampos() {
    $('#modalAgregarContenido').modal('hide');

    document.getElementById("IDAgregarContenidoCodigo").value = "";
    document.getElementById("IDAgregarContenidoNombreArchivo").value = "";
    document.getElementById("IDAgregarContenidoContenido").value = "";
    document.getElementById("IDAgregarContenidoCodigoCarpeta").value = "";
    document.getElementById("IDAgregarContenidoFechaCreacion").value = "";

    $("IDAgregarContenidoCodigo").css('border', '1px solid #ced4da');
    $("IDAgregarContenidoNombreArchivo").css('border', '1px solid #ced4da');
    $("IDAgregarContenidoContenido").css('border', '1px solid #ced4da');
    $("IDAgregarContenidoCodigoCarpeta").css('border', '1px solid #ced4da');
    $("IDAgregarContenidoFechaCreacion").css('border', '1px solid #ced4da');
}



function validarCamposContenido() {
    var bandera = true;
    var agregarContenidoNombreArchivo = document.getElementById("IDAgregarContenidoNombreArchivo").value;
    var agregarContenidoFechaCreacion = document.getElementById("IDAgregarContenidoContenido").value;
    var agregarContenidoVisibleEstudiantes = document.getElementById("IDAgregarContenidoCodigoCarpeta").value;
    var agregarContenidoCodigoCurso = document.getElementById("IDAgregarContenidoFechaCreacion").value;

    if (agregarContenidoNombreArchivo == "") {
        $("#IDAgregarContenidoNombreArchivo").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarContenidoNombreArchivo').css('border', '1px solid #ced4da');
    }

    if (agregarContenidoFechaCreacion == "") {
        $("#IDAgregarContenidoContenido").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarContenidoContenido').css('border', '1px solid #ced4da');
    }

    if (agregarContenidoVisibleEstudiantes == "") {
        $("#IDAgregarContenidoCodigoCarpeta").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarContenidoCodigoCarpeta').css('border', '1px solid #ced4da');
    }

    if (agregarContenidoCodigoCurso == "") {
        $("#IDAgregarContenidoFechaCreacion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarContenidoFechaCreacion').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleContenido(codigo) {
    $.ajax({
        url: '/Contenido/VerDetalleContenido',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarContenidoCodigo").value = response.codigo;
            document.getElementById("IDAgregarContenidoNombreArchivo").value = response.nombreArchivo;
            document.getElementById("IDAgregarContenidoContenido").value = response.contenido;
            document.getElementById("IDAgregarContenidoCodigoCarpeta").value = response.codigoCarpeta;
            document.getElementById("IDAgregarContenidoFechaCreacion").value = response.fechaCreacion;
            $('#modalAgregarContenido').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
