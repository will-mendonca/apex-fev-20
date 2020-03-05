import { Usuario } from './usuario';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({providedIn: 'root'})
export class UsuarioService {

  constructor(private http: HttpClient) { }

  public listar() {
    return this.http.get<Usuario[]>("/api/usuarios");
  }

  public inserir(usuario: Usuario) {
    return this.http.post<Usuario>("/api/usuarios", usuario);
  }

  public atualizar(usuario: Usuario) {
    return this.http.put("/api/usuarios/" + usuario.id, usuario);
  }

  public excluir(id: number) {
    return this.http.delete("/api/usuarios/" + id);
  }

}
