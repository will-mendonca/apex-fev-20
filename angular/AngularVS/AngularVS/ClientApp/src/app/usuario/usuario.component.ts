import { Component, OnInit } from '@angular/core';
import { UsuarioService } from './usuario.service';
import { Usuario } from './usuario';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  usuarios: Usuario[];
  adding: boolean = false; // controla quando adiciona um novo
  nome: string;
  idade: string;

  constructor(private service: UsuarioService) {
    service.listar().subscribe(result => {
      this.usuarios = result;
    });
  }

  ngOnInit() {
  }

  novo() {
    this.adding = true;
  }

  salvar() {
    let u: Usuario = new Usuario();
    u.nome = this.nome;
    u.idade = parseInt(this.idade);
    this.service.inserir(u).subscribe(resultado => {
      this.usuarios.push(resultado);
      this.adding = false;
    });
  }

  excluir(id: number) {
    this.service.excluir(id).subscribe(resultado => {
      let index = this.usuarios.findIndex(x => x.id == id);
      this.usuarios.splice(index, 1);
    });
  }

}
