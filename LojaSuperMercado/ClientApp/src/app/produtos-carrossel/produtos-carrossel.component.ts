import { Component, OnInit, AfterViewInit,Renderer2 } from "@angular/core"
import  'bootstrap'
import { ProdutoServico } from "../servicos/produto.servico";
import { Produto } from "../modelos/produto.modelo";

@Component({
  selector: 'carrossel-produtos',
  templateUrl: './produtos-carrossel.component.html',
  styleUrls: ['./produtos-carrossel.component.css']
})
export class ProdutosCarrosselComponent implements OnInit {
    
  public ITENSPORPAGINA: number = 3;
  public listaProdutos: any;
  public linhasProdutos: number;
  public arrayParaLogica: number[];
  constructor(public produtoServico: ProdutoServico, private rd : Renderer2) {
    
  }

  public obterListaProdutos() {
    this.arrayParaLogica = new Array<number>();
    this.produtoServico.obterListaProdutos().subscribe(
      response => {
        this.listaProdutos = response;
        this.linhasProdutos = Math.ceil(this.listaProdutos.length / this.ITENSPORPAGINA);
        this.arrayParaLogica.length = this.linhasProdutos;
      },
      err => {
        alert(err.error)
      }
    );
  }

  ngOnInit(): void {
    this.obterListaProdutos();
    console.log(this.listaProdutos);

  }


}
