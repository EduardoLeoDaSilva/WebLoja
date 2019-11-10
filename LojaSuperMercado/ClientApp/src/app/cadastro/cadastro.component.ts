import { Component, OnInit } from '@angular/core'
import { Router, ActivatedRoute } from '@angular/router'
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
  public cpfParaValidar: string;
  //Msg variaveis
  public cpfMsg: string;
  public isFotoOk: boolean;
  public msgGeral: string
  public msgAPIPosCadastro: string
  public fotoURL: any;


  constructor(private usuarioServico: UsuarioServico, private router: Router, private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.usuario = new Usuario();
    this.usuario.sexo = 'masculino'
    this.usuario.endereco = new Endereco();
    this.msgAPIPosCadastro = this.route.snapshot.params.msg;
  }


  private validarSubmit(): boolean {

    let emailTest = new RegExp(/[a-zA-Z0-9]+\@[a-zA-Z0-9]+\.com/);

    if (this.usuario.cpf == null || this.usuario.cpf.length < 11 || emailTest.test(this.usuario.email) == false || this.usuario.nome == null || this.usuario.nome == ''
      || this.usuario.foto == null || this.usuario.foto == '' || this.usuario.senha == null || this.usuario.senha.length < 6 || this.usuario.endereco.rua == null || this.usuario.endereco.cidade == null ||
      this.usuario.endereco.estado == null) {
      return false;
    } else {
      return true;
    }
  }

  validarCpf(): void {
    var reg = new RegExp(/\d{11}/);
    let isValid = reg.test(this.usuario.cpf);
    if (isValid) {
      this.cpfMsg = "CPF válido"
    } else {
      this.cpfMsg = "CPF inválido";
    }
  }




  public teste(event) {
    this.usuario.foto = event.target.files[0];

    var fr = new FileReader();

    fr.onloadend = () => {
    this.fotoURL = fr.result;

    }

    fr.readAsDataURL(this.usuario.foto);



      this.isFotoOk = true;
  }

  cadastrar(): void {
    if (this.validarSubmit() == false) {
      console.log("Entrou")
      this.msgGeral = "Há campos que não foram preenchidos ou estão inválidos"
      if (this.usuario.foto == null || this.usuario.foto == '') {

        this.isFotoOk = false
      }
    } else {
      this.msgGeral = null;

      console.log(event)
      this.usuarioServico.salvar(this.usuario).subscribe(
        response => {
          this.router.navigate(['/cadastro'], { queryParams: { msg: response } })
        },
        err => {
          alert(err.error);

        }
      )
    }
  }

}
