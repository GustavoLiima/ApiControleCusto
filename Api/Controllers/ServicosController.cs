using Api.Dto;
using Api.Intefaces;
using Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/Servicos")]
    public class ServicosController : ControllerBase
    {
        private readonly IServicoRepository _servicoRep;
        public ServicosController(IServicoRepository pServicoRep)
        {
            _servicoRep = pServicoRep;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Adicionar(ServicoDto pServico)
        {
            _servicoRep.AdicionarAtualizarServico(new ServicoModel(pServico.cdServico, pServico.TituloServico, pServico.DescricaoServico, pServico.Valor, pServico.cdEmpresa, pServico.tempo));

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public IActionResult PegarServico()
        {
            return Ok(_servicoRep.GetServicos());
        }

        [HttpDelete]
        [Authorize]
        public IActionResult RemoverServico(ServicoDto pServico)
        {
            _servicoRep.RemoverServico(pServico);
            return Ok();
        }
    }
}
