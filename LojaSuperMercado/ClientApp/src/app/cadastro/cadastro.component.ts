import { Component, OnInit } from '@angular/core'
import { Usuario } from '../modelos/usuario.modelo';
import { Endereco } from '../modelos/endereco';
import { UsuarioServico } from '../servicos/usuario.servico';


@Component({
  selector: 'cadastro-app',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {
    
  public usuario: Usuario;

  constructor(private usuarioServico: UsuarioServico) {

  }

  ngOnInit(): void {
    this.usuario = new Usuario();
    this.usuario.sexo = 'masculino'
    this.usuario.endereco = new Endereco();
  }

  cadastrar(): void{

    this.usuarioServico.salvar(this.usuario).subscribe(
      response => {
        alert(response);
      },
      err => {
        alert(err.error);

      }
    )

  }

}
