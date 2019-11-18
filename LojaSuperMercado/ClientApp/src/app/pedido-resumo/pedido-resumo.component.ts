import 'bootstrap';
import  { Component, OnInit, ElementRef } from '@angular/core';
import { PedidoServico } from '../servicos/pedido.servico';
import { ItemPedido } from '../modelos/ItemPedido';

@Component({
    selector: 'pedido-resumo',
    templateUrl: './pedido-resumo.component.html',
    styleUrls: ['./pedido-resumo.component.css']
})

export class PedidoResumoComponent implements OnInit {
    

    public itensPedidos: Array<ItemPedido>
    public quantidadeItens: number;
    public valorTotal: number = 0;
    public token: string;
    
    constructor(private pedidoServico: PedidoServico) { }

    ngOnInit() {
        
        this.token = sessionStorage.getItem("token"); 
        this.pedidoServico.getPedidoCompleto(this.token).subscribe(
            data=> {
            this.itensPedidos = data.itemPedidos;
            this.quantidadeItens = this.itensPedidos.length;
            
            this.itensPedidos.forEach(item => {
                    this.valorTotal += item.preco;

            });

            },
            err=>{
                debugger;
                alert(err.error)
            }
        )


     }

     atualizarQuant(itemPedidoId: number, quant: number):void{

        this.pedidoServico.atualizarQuantidade(itemPedidoId, quant, this.token).subscribe(
            data=>{
            this.itensPedidos = data.itemPedidos;

            if(this.itensPedidos.length <= 0){
                this.valorTotal = 0;
            }

            this.itensPedidos.forEach(function(item){
                this.valorTotal += item.preco;
        });
            this.quantidadeItens = this.itensPedidos.length;           
            },
            err=>{
                alert(err.error)
            }
        )
     }
}
