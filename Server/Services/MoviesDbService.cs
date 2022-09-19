using Microsoft.EntityFrameworkCore;
using MovieApp.Server.Data;
using MovieApp.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Server.Services
{
    public interface IMoviesRepository
    {

    }

    public interface IMoviesDbService
    {
        Task<List<Movie>> GetMovies();
        Task<Movie> AddMovie(Movie movie);
        Task<Movie> EditMovie(Movie movie);
        Task<Movie> DeleteMovie(int id);

    }

    public class MoviesDbService : IMoviesDbService
    {
        private ApplicationDbContext _context;

        public MoviesDbService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _context.Movies.ToListAsync();

        }



        public async Task<Movie> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;

        }

        public async Task<Movie> EditMovie(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return movie;

        }

        public async Task<Movie> DeleteMovie(int id)
        {

            var movie = await _context.Movies.FindAsync(id);

            _context.Movies.Remove(movie);

            await _context.SaveChangesAsync();

            return movie;

        }

    }
}
