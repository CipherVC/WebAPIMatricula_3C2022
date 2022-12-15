$(document).ready(function () {
    var codigoProfesor;

    $('#ProfesoresTabla').DataTable({
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

    $("#btnAgregarProfesor").click(function () {
        if (validarCamposProfesor()) {

            var codigoProfesor = document.getElementById("IDAgregarProfesorCodigo").value;

            if (codigoProfesor == "") {

                $.ajax({
                    url: '/Profesor/AgregarProfesor',
                    type: 'POST',
                    data: {
                        identificacion: document.getElementById("IDAgregarProfesorIdentificacion").value,
                        nombreCompleto: document.getElementById("IDAgregarProfesorNombre").value,
                        especialidad: document.getElementById("IDAgregarProfesorEspecialidad").value,
                        telefono: document.getElementById("IDAgregarProfesorTelefono").value,
                        direccion: document.getElementById("IDAgregarProfesorDireccion").value,
                        codigoCurso: document.getElementById("IDAgregarProfesorCodigoCurso").value,
                        codigoDepartamento: document.getElementById("IDAgregarProfesorCodigoDepartamento").value

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
                var e = document.getElementById("IDAgregarProfesorDireccion");
                var direccionSelect = e.value;
                $.ajax({
                    url: '/Profesor/EditarProfesor',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarProfesorCodigo").value,
                        identificacion: document.getElementById("IDAgregarProfesorIdentificacion").value,
                        nombreCompleto: document.getElementById("IDAgregarProfesorNombre").value,
                        especialidad: document.getElementById("IDAgregarProfesorEspecialidad").value,
                        telefono: document.getElementById("IDAgregarProfesorTelefono").value,
                        direccion: direccionSelect,
                        codigoCurso: document.getElementById("IDAgregarProfesorCodigoCurso").value,
                        codigoDepartamento: document.getElementById("IDAgregarProfesorCodigoDepartamento").value

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

    $("#btnCancelarProfesor").click(function () {
        limpiarCampos();
    });


    $("a[name='btnEditarProfesor']").click(function () {

        codigoProfesor = $(this).data("id");
        var verDetalle = VerDetalleProfesor(codigoProfesor);

    });

    $("a[name='btnEliminarProfesor']").click(function () {

        codigoProfesor = $(this).data("id");
        $('#modalVentanaEliminarProfesor').modal('show');
    });

    $("#btnAbrirDialogAgregarProfesor").click(function () {
        $('#modalAgregarProfesor').modal('show');
    });

    $("#btnAceptarEliminarProfesorConfirmacion").click(function () {

        $.ajax({
            url: '/Profesor/EliminarProfesor',
            type: 'POST',
            data: {
                Codigo: codigoProfesor
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarProfesor').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarProfesorConfirmacion").click(function () {
        $('#modalVentanaEliminarProfesor').modal('hide');
        location.reload();
    });

    $("#textoBuscarProfesor").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#ProfesoresTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCampos() {
    $('#modalAgregarProfesor').modal('hide');

    document.getElementById("IDAgregarProfesorCodigo").value = "";
    document.getElementById("IDAgregarProfesorIdentificacion").value = "";
    document.getElementById("IDAgregarProfesorNombre").value = "";
    document.getElementById("IDAgregarProfesorEspecialidad").value = "";
    document.getElementById("IDAgregarProfesorTelefono").value = "";
    document.getElementById("IDAgregarProfesorDireccion").value = "";
    document.getElementById("IDAgregarProfesorCodigoCurso").value = "";
    document.getElementById("IDAgregarProfesorCodigoDepartamento").value = "";

    $("IDAgregarProfesorIdentificacion").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorNombre").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorEspecialidad").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorTelefono").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorDireccion").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorCodigoCurso").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorCodigoDepartamento").css('border', '1px solid #ced4da');
}



function validarCamposProfesor() {
    var bandera = true;
    var agregarProfesorIdentificacion = document.getElementById("IDAgregarProfesorIdentificacion").value;
    var agregarProfesorNombre = document.getElementById("IDAgregarProfesorNombre").value;
    var agregarProfesorEspecialidad = document.getElementById("IDAgregarProfesorEspecialidad").value;
    var agregarProfesorTelefono = document.getElementById("IDAgregarProfesorTelefono").value;
    var agregarProfesorDireccion = document.getElementById("IDAgregarProfesorDireccion").value;
    var agregarProfesorCodigoCurso = document.getElementById("IDAgregarProfesorCodigoCurso").value;
    var agregarProfesorCodigoDepartamento = document.getElementById("IDAgregarProfesorCodigoDepartamento").value;

    if (agregarProfesorIdentificacion == "") {
        $("#IDAgregarProfesorIdentificacion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorIdentificacion').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorNombre == "") {
        $("#IDAgregarProfesorNombre").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorNombre').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorEspecialidad == "") {
        $("#IDAgregarProfesorEspecialidad").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorEspecialidad').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorTelefono == "") {
        $("#IDAgregarProfesorTelefono").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorTelefono').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorDireccion == "") {
        $("#IDAgregarProfesorDireccion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorDireccion').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorCodigoCurso == "") {
        $("#IDAgregarProfesorCodigoCurso").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorCodigoCurso').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorCodigoDepartamento == "") {
        $("#IDAgregarProfesorCodigoDepartamento").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorCodigoDepartamento').css('border', '1px solid #ced4da');
    }


    if (agregarProfesorIdentificacion == "") {
        $("#IDAgregarProfesorIdentificacion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorIdentificacion').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleProfesor(codigo) {
    $.ajax({
        url: '/Profesor/VerDetalleProfesor',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarProfesorCodigo").value = response.codigo;
            document.getElementById("IDAgregarProfesorIdentificacion").value = response.identificacion;
            document.getElementById("IDAgregarProfesorNombre").value = response.nombreCompleto;
            document.getElementById("IDAgregarProfesorEspecialidad").value = response.especialidad;
            document.getElementById("IDAgregarProfesorTelefono").value = response.telefono;
            document.getElementById("IDAgregarProfesorDireccion").value = response.direccion;
            document.getElementById("IDAgregarProfesorCodigoCurso").value = response.codigoCurso;
            document.getElementById("IDAgregarProfesorCodigoDepartamento").value = response.codigoDepartamento;


            $('#modalAgregarProfesor').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
