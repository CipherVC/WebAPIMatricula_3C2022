$(document).ready(function () {
    var codigoDepartamento;

    $('#DepartamentosTabla').DataTable({
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

    $("#btnAgregarDepartamento").click(function () {
        if (validarCamposDepartamento()) {

            var codigoDepartamento = document.getElementById("IDAgregarDepartamentoCodigo").value;

            if (codigoDepartamento == "") {

                $.ajax({
                    url: '/Departamento/AgregarDepartamento',
                    type: 'POST',
                    data: {
                        nombreDepartamento: document.getElementById("IDAgregarDepartamentoNombre").value,
                        descripcionDepartamento: document.getElementById("IDAgregarDepartamentoDescripcion").value,
                        directorDepartamento: document.getElementById("IDAgregarDepartamentoDirector").value,
                        telefono: document.getElementById("IDAgregarDepartamentoTelefono").value,


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
                var e = document.getElementById("IDAgregarDepartamentoNombre");
                var nombreDepartamentoSelect = e.value;
                $.ajax({
                    url: '/Departamento/EditarDepartamento',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarDepartamentoCodigo").value,
                        nombreDepartamento: nombreDepartamentoSelect,
                        descripcionDepartamento: document.getElementById("IDAgregarDepartamentoDescripcion").value,
                        directorDepartamento: document.getElementById("IDAgregarDepartamentoDirector").value,
                        telefono: document.getElementById("IDAgregarDepartamentoTelefono").value,

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

    $("#btnCancelarDepartamento").click(function () {
        limpiarCampos();
    });


    $("a[name='btnEditarDepartamento']").click(function () {

        codigoDepartamento = $(this).data("id");
        var verDetalle = VerDetalleDepartamento(codigoDepartamento);

    });

    $("a[name='btnEliminarDepartamento']").click(function () {

        codigoDepartamento = $(this).data("id");
        $('#modalVentanaEliminarDepartamento').modal('show');
    });

    $("#btnAbrirDialogAgregarDepartamento").click(function () {
        $('#modalAgregarDepartamento').modal('show');
    });

    $("#btnAceptarEliminarDepartamentoConfirmacion").click(function () {

        $.ajax({
            url: '/Departamento/EliminarDepartamento',
            type: 'POST',
            data: {
                Codigo: codigoDepartamento
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarDepartamento').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarDepartamentoConfirmacion").click(function () {
        $('#modalVentanaEliminarDepartamento').modal('hide');
        location.reload();
    });

    $("#textoBuscarDepartamento").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#DepartamentosTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCampos() {
    $('#modalAgregarDepartamento').modal('hide');

    document.getElementById("IDAgregarDepartamentoCodigo").value = "";
    document.getElementById("IDAgregarDepartamentoNombre").value = "";
    document.getElementById("IDAgregarDepartamentoDescripcion").value = "";
    document.getElementById("IDAgregarDepartamentoDirector").value = "";
    document.getElementById("IDAgregarDepartamentoTelefono").value = "";

    $("IDAgregarDepartamentoNombre").css('border', '1px solid #ced4da');
    $("IDAgregarDepartamentoDescripcion").css('border', '1px solid #ced4da');
    $("IDAgregarDepartamentoDirector").css('border', '1px solid #ced4da');
    $("IDAgregarDepartamentoTelefono").css('border', '1px solid #ced4da');
}



function validarCamposDepartamento() {
    var bandera = true;
    var agregarDepartamentoNombre = document.getElementById("IDAgregarDepartamentoNombre").value;
    var agregarDepartamentoDescripcion = document.getElementById("IDAgregarDepartamentoDescripcion").value;
    var agregarDepartamentoDirector = document.getElementById("IDAgregarDepartamentoDirector").value;
    var agregarDepartamentoTelefono = document.getElementById("IDAgregarDepartamentoTelefono").value;


    if (agregarDepartamentoNombre == "") {
        $("#IDAgregarDepartamentoNombre").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarDepartamentoNombre').css('border', '1px solid #ced4da');
    }

    if (agregarDepartamentoDescripcion == "") {
        $("#IDAgregarDepartamentoDescripcion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarDepartamentoDescripcion').css('border', '1px solid #ced4da');
    }

    if (agregarDepartamentoDirector == "") {
        $("#IDAgregarDepartamentoDirector").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarDepartamentoDirector').css('border', '1px solid #ced4da');
    }

    if (agregarDepartamentoTelefono == "") {
        $("#IDAgregarDepartamentoTelefono").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarDepartamentoTelefono').css('border', '1px solid #ced4da');
    }

    if (agregarDepartamentoNombre == "") {
        $("#IDAgregarDepartamentoNombre").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarDepartamentoNombre').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleDepartamento(codigo) {
    $.ajax({
        url: '/Departamento/VerDetalleDepartamento',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarDepartamentoNombre").value = response.nombreDepartamento;
            document.getElementById("IDAgregarDepartamentoDescripcion").value = response.descripcionDepartamento;
            document.getElementById("IDAgregarDepartamentoDirector").value = response.directorDepartamento;
            document.getElementById("IDAgregarDepartamentoTelefono").value = response.telefono;
            document.getElementById("IDAgregarDepartamentoCodigo").value = response.codigo;
            $('#modalAgregarDepartamento').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
