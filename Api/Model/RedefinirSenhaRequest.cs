﻿namespace Api.Model
{
    public class RedefinirSenhaRequest
    {
        public string Email { get; set; }
        public string Codigo { get; set; }
        public string NovaSenha { get; set; }
    }
}
