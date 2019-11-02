import { Injectable, Inject } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Router } from '@angular/router'
import { Usuario } from '../modelos/usuario.modelo';


@Injectable({
  providedIn:'root'
})
export class UsuarioServico {

  private _baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }


  public salvar(usuario: Usuario): Observable<string> {

    const headers = new HttpHeaders().set('content-type', 'application/json');

    var body = {
      usuario: usuario
    }

   return  this.http.post<string>(`${this._baseUrl}/api/usuario`, body, { headers });
  }


}
