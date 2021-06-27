"use strict";
var DepartamentosGrid;
(function (DepartamentosGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea Eliminar Este Registro?", "Eliminar", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Departamentos/GridDepartamentos?handler=Eliminar&id=" + id;
            }
        });
    }
    DepartamentosGrid.OnClickEliminar = OnClickEliminar;
    $("GridView").dataTable();
})(DepartamentosGrid || (DepartamentosGrid = {}));
//# sourceMappingURL=Grid.js.map