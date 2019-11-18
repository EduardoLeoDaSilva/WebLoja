import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './login/login.component';
import { ProdutosCarrosselComponent } from './produtos-carrossel/produtos-carrossel.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { UsuarioServico } from './servicos/usuario.servico';
import { NgxMaskModule } from 'ngx-mask'
import { GuardaRotas } from './autorizacao/GuardaRotas';
import { ProdutoServico } from './servicos/produto.servico';
import { PedidoResumoComponent } from './pedido-resumo/pedido-resumo.component';
import { PedidoServico } from './servicos/pedido.servico';
import { LoginServico } from './servicos/login.servico';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    ProdutosCarrosselComponent,
    CadastroComponent,
    PedidoResumoComponent

  ],

  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgxMaskModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: LoginComponent },
      { path: 'login', component: LoginComponent },
      { path: 'produtos', component: ProdutosCarrosselComponent, canActivate: [GuardaRotas]},
      { path: 'cadastro', component: CadastroComponent },
      {path: 'resumo', component: PedidoResumoComponent, canActivate: [GuardaRotas]}
    ])
  ],
  providers: [UsuarioServico, ProdutoServico, PedidoServico, LoginServico],
  bootstrap: [AppComponent]
})
export class AppModule { }
