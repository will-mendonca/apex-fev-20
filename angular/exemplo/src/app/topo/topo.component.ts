import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-topo',
  templateUrl: './topo.component.html',
  styleUrls: ['./topo.component.css']
})
export class TopoComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  titulo:string = "Angular";

  alerta() {
    this.titulo = "Alerta";
  }

  alerta2() {
    this.titulo = "Angular";
  }

}
