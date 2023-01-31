namespace SiteMVC.Repositorio
{
    public interface IEmail
    {
        public bool EnviarEmail(string email, string assunto, string mensagem);
    }
}
