using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class MovicesService : EntityBaseRepository<Movie>, IMoviesSerivce
    {
        public MovicesService(AppDbContext context) : base(context) { }
    }
}
