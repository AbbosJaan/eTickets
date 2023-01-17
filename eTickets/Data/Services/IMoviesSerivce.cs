using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IMoviesSerivce : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

    }
}
