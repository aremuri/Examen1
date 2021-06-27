"use strict";
var PuestosGrid;
(function (PuestosGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea Eliminar Este Registro?", "Eliminar", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Puestos/GridPuestos?handler=Eliminar&id=" + id;
            }
        });
    }
    PuestosGrid.OnClickEliminar = OnClickEliminar;
    $("GridView").dataTable();
})(PuestosGrid || (PuestosGrid = {}));
//# sourceMappingURL=Grid.js.map