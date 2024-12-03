using Api.Dto;
using Api.Model;

namespace Api.Intefaces
{
    public interface IRecuperarSenha
    {
        public void AdicionarNovaRecuperacao(RecuperacaoSenhaModel pRecuperacao);
        public Task<RecuperacaoSenhaModel?> GetRecuperacao(RedefinirSenhaRequest pModel);
    }
}
