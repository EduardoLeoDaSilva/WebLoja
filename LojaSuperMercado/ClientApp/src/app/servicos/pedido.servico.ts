import {Inject, Injectable} from '@angular/core'
import {HttpClient, HttpHeaders} from '@angular/common/http'
import {Observable} from 'rxjs'
import { Produto } from '../modelos/produto.modelo';
import { Pedido } from '../modelos/pedido';

@Injectable({
    providedIn: 'root'
})
export class PedidoServico {

    private _baseURL: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseURL: string){
          this._baseURL = baseURL;
    }


    addItem(produto : Produto, token: string): Observable<Pedido>{


        const headers = new HttpHeaders().set("Authorization", `Bearer ${token}`);
        //headers.append();

        let userId = sessionStorage.getItem('usuario')
        headers.set('usuario', userId);
        var body = {
            produtoId: produto.produtoId,
            nome: produto.nome,
            marca: produto.marca,
            preco: produto.preco,
            codigoProduto: produto.codigoProduto
        }


        return  this.http.post<Pedido>(`${this._baseURL}/api/pedido`, body, {headers});

        

    }


    getPedidoCompleto(token: string): Observable<Pedido>{

        const headers = new HttpHeaders().set("Authorization", `Bearer ${token}`);
       // headers.append("Authorization", `Bearer ${token}`);

        return  this.http.get<Pedido>(`${this._baseURL}/api/pedido`, {headers});

    }

    atualizarQuantidade(itemPedidoId:number, quantidade: number, token: string):Observable<Pedido>{
        const headers = new HttpHeaders().set("Authorization", `Bearer ${token}`);
       // headers.append("Authorization", `Bearer ${token}`);


        let body = {
            itemPedidoId,
            quantidade
        }
       return this.http.post<Pedido>(`${this._baseURL}/api/pedido/AtualizarQuantidade`, body, {headers});
    }


}