import { Injectable, Inject } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router'
import { Usuario } from '../modelos/usuario.modelo';


@Injectable({
  providedIn:'root'
})
export class UsuarioServico {

  private _baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
    this._baseUrl = baseUrl;
  }


  public salvar(usuario: Usuario): Observable<Usuario> {

    var formData = new FormData();

    formData.append("nome", usuario.nome);
    formData.append("sexo", usuario.sexo);
    formData.append("cpf", usuario.cpf);
    formData.append("email", usuario.email);
    formData.append("senha", usuario.senha);
    formData.append("enderecos[0].rua", usuario.endereco.rua);
    formData.append("enderecos[0].cidade",usuario.endereco.cidade);
    formData.append("enderecos[0].estado", usuario.endereco.estado);
    formData.append("foto", usuario.foto);


    return this.http.post<Usuario>(`${this._baseUrl}api/usuario`, formData);
  }


}
