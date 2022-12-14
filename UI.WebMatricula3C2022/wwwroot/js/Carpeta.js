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
                        identificacion: document.getElementById("IDAgregarCarpetaIdentificacion").value,
                        nombreCompleto: document.getElementById("IDAgregarCarpetaNombre").value,
                        correoElectronico: document.getElementById("IDAgregarCarpetaCorreo").value,
                        estado: document.getElementById("IDAgregarCarpetaEstado").value

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
                var e = document.getElementById("IDAgregarCarpetaEstado");
                var estadoSelect = e.value;
                $.ajax({
                    url: '/Carpeta/EditarCarpeta',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarCarpetaCodigo").value,
                        identificacion: document.getElementById("IDAgregarCarpetaIdentificacion").value,
                        nombreCompleto: document.getElementById("IDAgregarCarpetaNombre").value,
                        correoElectronico: document.getElementById("IDAgregarCarpetaCorreo").value,
                        estado: estadoSelect
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
    document.getElementById("IDAgregarCarpetaIdentificacion").value = "";
    document.getElementById("IDAgregarCarpetaNombre").value = "";
    document.getElementById("IDAgregarCarpetaCorreo").value = "";
    document.getElementById("IDAgregarCarpetaEstado").value = "";

    $("IDAgregarCarpetaIdentificacion").css('border', '1px solid #ced4da');
    $("IDAgregarCarpetaNombre").css('border', '1px solid #ced4da');
    $("IDAgregarCarpetaCorreo").css('border', '1px solid #ced4da');
    $("IDAgregarCarpetaEstado").css('border', '1px solid #ced4da');
}



function validarCamposCarpeta() {
    var bandera = true;
    var agregarCarpetaIdentificacion = document.getElementById("IDAgregarCarpetaIdentificacion").value;
    var agregarCarpetaNombre = document.getElementById("IDAgregarCarpetaNombre").value;
    var agregarCarpetaCorreo = document.getElementById("IDAgregarCarpetaCorreo").value;
    var agregarCarpetaEstado = document.getElementById("IDAgregarCarpetaEstado").value;

    if (agregarCarpetaIdentificacion == "") {
        $("#IDAgregarCarpetaIdentificacion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCarpetaIdentificacion').css('border', '1px solid #ced4da');
    }

    if (agregarCarpetaNombre == "") {
        $("#IDAgregarCarpetaNombre").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCarpetaNombre').css('border', '1px solid #ced4da');
    }

    if (agregarCarpetaCorreo == "") {
        $("#IDAgregarCarpetaCorreo").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCarpetaCorreo').css('border', '1px solid #ced4da');
    }

    if (agregarCarpetaIdentificacion == "") {
        $("#IDAgregarCarpetaIdentificacion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCarpetaIdentificacion').css('border', '1px solid #ced4da');
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
            document.getElementById("IDAgregarCarpetaEstado").value = response.estado;
            document.getElementById("IDAgregarCarpetaNombre").value = response.nombreCompleto;
            document.getElementById("IDAgregarCarpetaCorreo").value = response.correoElectronico;
            document.getElementById("IDAgregarCarpetaIdentificacion").value = response.identificacion;
            document.getElementById("IDAgregarCarpetaCodigo").value = response.codigo;
            $('#modalAgregarCarpeta').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
