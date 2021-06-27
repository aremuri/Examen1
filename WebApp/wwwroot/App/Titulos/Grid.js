"use strict";
var TitulosGrid;
(function (TitulosGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea Eliminar Este Registro?", "Eliminar", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Titulos/GridTitulos?handler=Eliminar&id=" + id;
            }
        });
    }
    TitulosGrid.OnClickEliminar = OnClickEliminar;
    $("GridView").dataTable();
})(TitulosGrid || (TitulosGrid = {}));
//# sourceMappingURL=Grid.js.map