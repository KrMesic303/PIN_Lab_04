using MoviesApp.Data;

namespace MoviesApp.Services
{
    public class MoviesService
    {
        private AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }

        #region Search/Get

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();

        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        #endregion

        #region Create/Update/Delete
        public void AddMovie(Movie movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Year = movie.Year,
                Genre = movie.Genre,

            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();

        }

        public Movie UpdateMovieById(int id, Movie updateMovie)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                movie.Name = updateMovie.Name;
                movie.Year = updateMovie.Year;
                movie.Genre = updateMovie.Genre;

                _context.SaveChanges();
            }

            return movie;

        }

        public void DeleteMovie(int id)
        {
            var book = _context.Movies.FirstOrDefault(x => x.Id == id);
            _context.Movies.Remove(book);
            _context.SaveChanges();
        }

        #endregion

    }
}
