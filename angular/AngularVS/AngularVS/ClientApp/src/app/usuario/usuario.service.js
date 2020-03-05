"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var UsuarioService = /** @class */ (function () {
    function UsuarioService(http) {
        this.http = http;
    }
    UsuarioService.prototype.listar = function () {
        return this.http.get("/api/usuarios");
    };
    return UsuarioService;
}());
exports.UsuarioService = UsuarioService;
//# sourceMappingURL=usuario.service.js.map