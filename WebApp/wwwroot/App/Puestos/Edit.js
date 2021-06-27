"use strict";
var Puestos;
(function (Puestos) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("AppEdit");
})(Puestos || (Puestos = {}));
//# sourceMappingURL=Edit.js.map