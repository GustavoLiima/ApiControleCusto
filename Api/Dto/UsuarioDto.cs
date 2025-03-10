﻿namespace Api.Dto
{
    public class UsuarioDto
    {
        public int cd_usuario { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string? telefone { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string? numeroCnh { get; set; }
        public string? categoriaCnh { get; set; }
        public DateTime? vencimentoCnh { get; set; }
        public bool ativo { get; set; }
        public int Plano { get; set; }
        public string TokenPagamento { get; set; }
    }
}
