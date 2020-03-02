import { Component, OnInit } from '@angular/core';
import { runInThisContext } from 'vm';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  texto:string = "Aprendendo Angular";
  url:string = "http://apexensino.com.br";
  imagem:string = "http://placekitten.com/";
  campo:string;
  mostrargatinho:boolean = true;
  cor:string = "vermelho";
  cidades:string[] = ["Blumenau", "Gaspar", "Pomerode", "Joinville"];
  estilo:string = "btn btn-primary";

  mostrar() {
    alert(this.campo);  
  }

  alterar() {
    this.campo = "Novo Valor";
    this.estilo = "btn btn-warning";
  }

  gatinho() {
    this.mostrargatinho = !this.mostrargatinho;
  }

  mudarcor(c) {
    this.cor = c;
  }

  remove() {
    this.cidades.pop();
  }

  adiciona() {
    this.cidades.push("teste");
  }

}
