using MovieList.DBOperations;
using System;
using System.Linq;

namespace MovieList.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly MovieListDbContext _context;
        public DeleteGenreCommand(MovieListDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
                throw new InvalidOperationException("Film Türü Bulunamadı!");
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}
