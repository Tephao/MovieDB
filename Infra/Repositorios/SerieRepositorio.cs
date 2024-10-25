using moviedb.Domain.Entidades;

namespace moviedb.Infra.Repositorios
{
    public class SerieRepositorio
    {
        public List<Serie> Series { get; set; }
        public SerieRepositorio()
        {
            this.Series = new List<Serie>();
        }
        public void Criar(Serie serie)
        {
            this.Series.Add(serie);
        }

        public List<Serie> BuscarTodosSeries()
        {
            return this.Series;
        }

        public Serie BuscarSeriePorNome(string nome)
        {
            return this.Series.Find(x => x.Nome == nome);
        }

        public void AtualizarSerie(Serie serie)
        {
            var serieResult = this.Series.Find(x => x.Nome == serie.Nome);
            if (serieResult != null)
            {
                serieResult = serie;
            }

        }

        public void DeletarSerie(Serie serie)
        {
            this.Series.Remove(serie);
        }
    }
}
