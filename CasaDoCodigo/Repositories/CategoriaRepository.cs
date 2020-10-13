using CasaDoCodigo.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> SaveCategoria(string nome);
    }

    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private Categoria categoria;

        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<Categoria> SaveCategoria(string nome)
        {
            if (dbSet.Where(p => p.Nome != nome).Any())
            {
                categoria = dbSet.Add(new Categoria(nome)).Entity;
            }

            await contexto.SaveChangesAsync();
            return categoria;
        }
    }
}
