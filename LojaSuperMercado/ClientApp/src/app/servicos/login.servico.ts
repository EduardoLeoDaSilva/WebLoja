import { Inject, Injectable } from '@angular/core'
import {HttpClient, HttpHeaders} from '@angular/common/http'
import {Observable} from  'rxjs'
import { Usuario } from '../modelos/usuario.modelo';


@Injectable({
    providedIn: 'root'
})
export class LoginServico{
    
    private _baseUrl: string = "https://localhost:5001/api/LoginJwt";

    constructor(private http: HttpClient){

    }


    efetuarLogin(email: string, senha: string):Observable<string>{
         
             const headers = new HttpHeaders().set("content-type", "application/json");

             var body = {
                 email,
                 senha
             }

             return this.http.post<string>(this._baseUrl, body, {headers});

    }


}