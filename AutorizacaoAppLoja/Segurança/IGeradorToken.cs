namespace AutorizacaoAppLoja.Segurança
{
    public interface IGeradorToken
    {
        string ObterTokenJwt(string email, string senha);
    }
}