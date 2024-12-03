namespace Api.Dto
{
    public class RecuperacaoSenhaDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Codigo { get; set; }
        public DateTime DataHora { get; set; }
    }
}
