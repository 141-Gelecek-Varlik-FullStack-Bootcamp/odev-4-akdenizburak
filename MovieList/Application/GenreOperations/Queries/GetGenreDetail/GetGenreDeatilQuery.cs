using AutoMapper;
using MovieList.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieList.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        public readonly MovieListDbContext _context;
        public readonly IMapper _mapper;
        public GetGenreDetailQuery(IMapper mapper, MovieListDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<GenreDetailViewModel> Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive&&x.Id==GenreId);
            if (genre is null)
                throw new InvalidOperationException("Film Türü Bulunamadı");
            return _mapper.Map<GenreDetailViewModel>(genre);
        }
    }
    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
