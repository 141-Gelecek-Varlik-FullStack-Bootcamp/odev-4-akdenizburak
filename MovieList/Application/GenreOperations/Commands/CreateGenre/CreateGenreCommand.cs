using MovieList.DBOperations;
using MovieList.Entities;
using System;
using System.Linq;

namespace MovieList.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreCommand Model { get; set; }
        private readonly MovieListDbContext _context;
        public CreateGenreCommand(MovieListDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name ==Model.Name);
            if (genre is not null)
                throw new InvalidOperationException("Film Türü zaten mevcut");
            genre = new Genre();
            genre.Name = Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }
    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
