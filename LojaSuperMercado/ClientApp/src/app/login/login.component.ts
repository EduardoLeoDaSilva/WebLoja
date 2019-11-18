import { Component } from '@angular/core'
import { LoginServico } from '../servicos/login.servico';
import { Router } from '@angular/router'

@Component({
  selector: 'login-component',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {


  public email: string;
  public senha: string;

  constructor(private loginServico: LoginServico, private router: Router){

  }

  logar():void{
    this.loginServico.efetuarLogin(this.email, this.senha).subscribe(
         data=>{
           debugger;
                sessionStorage.setItem("token", data)
                sessionStorage.setItem("userEmail", this.email)
                this.router.navigate(['/produtos'])
         },
         err => {
           alert(err.error)
           debugger;

         }

    )
  }

}
