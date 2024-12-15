namespace Api.Helpers
{
    public static class GerarCorpoEmail
    {
        public static string GeneratePasswordRecoveryEmailBody(string code)
        {
            return $@"
            <html>
            <body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
                <h2 style='color: #007BFF;'>Recuperação de Senha - Cofauto</h2>
                <p>Você solicitou a recuperação de senha do aplicativo <strong>Cofauto</strong>.</p>
                <p>Por favor, digite o código abaixo no aplicativo para continuar com o processo de recuperação:</p>
                <div style='font-size: 20px; font-weight: bold; color: #007BFF; margin: 20px 0;'>
                    {code}
                </div>
                <p>Se você não solicitou esta ação, ignore este e-mail.</p>
                <p>Atenciosamente,</p>
                <p>Equipe Cofauto</p>
            </body>
            </html>
        ";
        }
    }
}
