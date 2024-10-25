using Microsoft.AspNetCore.Mvc;
using moviedb.Domain.Entidades;
using moviedb.Infra.Repositorios;

namespace moviedb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SerieController: Controller
    {
        public SerieController(SerieRepositorio repositorio)
        {
            SerieRepositorio = repositorio;
        }

        public SerieRepositorio SerieRepositorio { get; set; }

        [HttpGet(Name = "BuscarTodosSeries")]
        public IEnumerable<Serie> Get()
        {
            return SerieRepositorio.BuscarTodosSeries();
        }

        [HttpGet("{nome}")]
        public ActionResult<Serie> BuscarSeriePorNome(string nome)
        {
            return SerieRepositorio.BuscarSeriePorNome(nome);
        }

        [HttpPost(Name = "CriarSerie")]
        public void CriarSerie([FromBody] Serie serie)
        {
            SerieRepositorio.Criar(serie);
        }
    }
}
