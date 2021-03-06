using MovieList.DBOperations;
using System;
using System.Linq;

namespace MovieList.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        private readonly MovieListDbContext _context;
        public UpdateGenreCommand(MovieListDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Film türü bulunamadı");
            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException("Aynı isimli bir Film zaten mevcut");
            genre.Name =String.IsNullOrEmpty(Model.Name.Trim())  == default ?   genre.Name: Model.Name;
            genre.IsActive=Model.IsActive;
            _context.SaveChanges();
        }
    }
    
    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
