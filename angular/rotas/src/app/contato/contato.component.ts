import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-contato',
  templateUrl: './contato.component.html',
  styleUrls: ['./contato.component.css']
})
export class ContatoComponent implements OnInit {

  logradouro:string;
  bairro:string;
  cidade:string;
  cep:string;
  cepValido:boolean;

  constructor(private http:HttpClient) { }

  ngOnInit() {
  }

  consultaCep() {

    this.http.get<Endereco>("http://viacep.com.br/ws/"+this.cep+"/json").
      subscribe(resultado => {
        this.cepValido = !resultado.erro; 
        this.logradouro = resultado.logradouro;
        this.bairro = resultado.bairro;
        this.cidade = resultado.localidade;
      });

  }

}



class Endereco {
  cep:string;
  logradouro:string;
  complemento:string;
  bairro:string;
  localidade:string;
  uf:string;
  erro:boolean;
}
