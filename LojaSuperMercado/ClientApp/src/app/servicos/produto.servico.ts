import { Injectable, Inject } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs'
import { Produto } from '../modelos/produto.modelo';

@Injectable({
  providedIn: "root"
})
export class ProdutoServico {

  public baseURL: string;

  constructor(public http: HttpClient, @Inject('BASE_URL')  baseURL: string) {
    this.baseURL = baseURL;
  }

  obterListaProdutos(token: string): Observable<Array<Produto>> {

    const headers = new HttpHeaders().set("Authorization", `Bearer ${token}`);
    return this.http.get<Array<Produto>>(`${this.baseURL}/api/Produto`, {headers})

  }

}
