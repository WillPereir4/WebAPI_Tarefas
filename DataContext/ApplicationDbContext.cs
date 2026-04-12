using Microsoft.EntityFrameworkCore;
using WebApi_Tarefas.Models;

namespace WebApi_Tarefas.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
        }

        public DbSet<TarefaModel> Tarefas { get; set; }


    }
}
