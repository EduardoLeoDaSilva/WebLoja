import { Component, OnInit, AfterViewInit,Renderer2 } from "@angular/core"
import {Router} from '@angular/router'
import  'bootstrap'
import { ProdutoServico } from "../servicos/produto.servico";
import { Produto } from "../modelos/produto.modelo";
import { PedidoServico } from "../servicos/pedido.servico";

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
  public token: string;
  constructor(public produtoServico: ProdutoServico, private rd : Renderer2 , private pedidoServico: PedidoServico, private router: Router) {
    
  }

  public obterListaProdutos() {
    
    this.arrayParaLogica = new Array<number>();
    this.produtoServico.obterListaProdutos(this.token).subscribe(
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
    this.token = sessionStorage.getItem("token")
    this.obterListaProdutos();
    console.log(this.listaProdutos);

  }

  addItemPedido(produto: Produto):void{
     this.pedidoServico.addItem(produto, this.token).subscribe(
       response => {
            this.router.navigate(['/resumo']);
       },
       err => {
         debugger;

         alert(err.error)
       }
     )
  }

}
