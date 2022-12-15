$(document).ready(function () {
    var codigoCarpeta;

    $('#CarpetasTabla').DataTable({
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

    $("#btnAgregarCarpeta").click(function () {
        if (validarCamposCarpeta()) {

            var codigoCarpeta = document.getElementById("IDAgregarCarpetaCodigo").value;

            if (codigoCarpeta == "") {

                $.ajax({
                    url: '/Carpeta/AgregarCarpeta',
                    type: 'POST',
                    data: {
                        Nombre: document.getElementById("IDAgregarCarpetaNombre").value,
                        FechaCreacion: document.getElementById("IDAgregarCarpetaFechaCreacion").value,
                        VisibleEstudiantes: document.getElementById("IDAgregarCarpetaVisibleEstudiantes").value,
                        CodigoCurso: document.getElementById("IDAgregarCarpetaCodigoCurso").value

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
                var e = document.getElementById("IDAgregarCarpetaVisibleEstudiantes");
                var estadoSelect = e.value;
                $.ajax({
                    url: '/Carpeta/EditarCarpeta',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarCarpetaCodigo").value,
                        FechaCreacion: document.getElementById("IDAgregarCarpetaFechaCreacion").value,
                        Nombre: document.getElementById("IDAgregarCarpetaNombre").value,
                        CodigoCurso: document.getElementById("IDAgregarCarpetaCodigoCurso").value,
                        VisibleEstudiantes: estadoSelect
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

    $("#btnCancelarCarpeta").click(function () {
        limpiarCampos();
    });


    $("a[name='btnEditarCarpeta']").click(function () {

        codigoCarpeta = $(this).data("id");
        var verDetalle = VerDetalleCarpeta(codigoCarpeta);

    });

    $("a[name='btnEliminarCarpeta']").click(function () {

        codigoCarpeta = $(this).data("id");
        $('#modalVentanaEliminarCarpeta').modal('show');
    });

    $("#btnAbrirDialogAgregarCarpeta").click(function () {
        $('#modalAgregarCarpeta').modal('show');
    });

    $("#btnAceptarEliminarCarpetaConfirmacion").click(function () {

        $.ajax({
            url: '/Carpeta/EliminarCarpeta',
            type: 'POST',
            data: {
                Codigo: codigoCarpeta
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarCarpeta').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarCarpetaConfirmacion").click(function () {
        $('#modalVentanaEliminarCarpeta').modal('hide');
        location.reload();
    });

    $("#textoBuscarCarpeta").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#CarpetasTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCampos() {
    $('#modalAgregarCarpeta').modal('hide');

    document.getElementById("IDAgregarCarpetaCodigo").value = "";
    document.getElementById("IDAgregarCarpetaNombre").value = "";
    document.getElementById("IDAgregarCarpetaFechaCreacion").value = "";
    document.getElementById("IDAgregarCarpetaVisibleEstudiantes").value = "";
    document.getElementById("IDAgregarCarpetaCodigoCurso").value = "";

    $("IDAgregarCarpetaIdentificacion").css('border', '1px solid #ced4da');
    $("IDAgregarCarpetaNombre").css('border', '1px solid #ced4da');
    $("IDAgregarCarpetaCorreo").css('border', '1px solid #ced4da');
    $("IDAgregarCarpetaEstado").css('border', '1px solid #ced4da');
}



function validarCamposCarpeta() {
    var bandera = true;
    var agregarCarpetaNombre = document.getElementById("IDAgregarCarpetaNombre").value;
    var agregarCarpetaFechaCreacion = document.getElementById("IDAgregarCarpetaFechaCreacion").value;
    var agregarCarpetaVisibleEstudiantes = document.getElementById("IDAgregarCarpetaVisibleEstudiantes").value;
    var agregarCarpetaCodigoCurso = document.getElementById("IDAgregarCarpetaCodigoCurso").value;

    if (agregarCarpetaNombre == "") {
        $("#IDAgregarCarpetaNombre").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCarpetaNombre').css('border', '1px solid #ced4da');
    }

    if (agregarCarpetaFechaCreacion == "") {
        $("#IDAgregarCarpetaFechaCreacion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCarpetaFechaCreacion').css('border', '1px solid #ced4da');
    }

    if (agregarCarpetaVisibleEstudiantes == "") {
        $("#IDAgregarCarpetaVisibleEstudiantes").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCarpetaVisibleEstudiantes').css('border', '1px solid #ced4da');
    }

    if (agregarCarpetaCodigoCurso == "") {
        $("#IDAgregarCarpetaCodigoCurso").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCarpetaCodigoCurso').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleCarpeta(codigo) {
    $.ajax({
        url: '/Carpeta/VerDetalleCarpeta',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarCarpetaNombre").value = response.nombre;
            document.getElementById("IDAgregarCarpetaFechaCreacion").value = response.fechaCreacion;
            document.getElementById("IDAgregarCarpetaVisibleEstudiantes").value = response.visibleEstudiantes;
            document.getElementById("IDAgregarCarpetaCodigoCurso").value = response.codigoCurso;
            document.getElementById("IDAgregarCarpetaCodigo").value = response.codigo;
            $('#modalAgregarCarpeta').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
