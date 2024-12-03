using Api.Dto;
using Api.Intefaces;
using Api.Model;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class RecuperacaoSenhaRepository : DbContext, IRecuperarSenha
    {
        private readonly ConnectionContext _Context;

        // Injeta o ConnectionContext no repositório
        public RecuperacaoSenhaRepository(ConnectionContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AdicionarNovaRecuperacao(RecuperacaoSenhaModel pRecuperacao)
        {
            _Context.tabRecuperacaoSenha.Add(pRecuperacao);
            _Context.SaveChanges();
        }

        public async Task<RecuperacaoSenhaModel?> GetRecuperacao(RedefinirSenhaRequest pModel)
        {
            return await _Context.tabRecuperacaoSenha.Where(r => r.Codigo == pModel.Codigo && r.Email == pModel.Email)
                .OrderByDescending(r => r.DataHora)
                .FirstOrDefaultAsync();
        }
    }
}
