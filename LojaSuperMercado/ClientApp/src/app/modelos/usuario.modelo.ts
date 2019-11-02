import { Endereco } from "./endereco";

export class Usuario {
  usuarioId: number;
  nome: string;
  sexo: string;
  cpf: string;
  email: string;
  senha: string;
  endereco : Endereco
}
