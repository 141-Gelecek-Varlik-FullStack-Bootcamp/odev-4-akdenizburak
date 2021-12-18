using AutoMapper;
using MovieList.DBOperations;
using System.Collections.Generic;
using System.Linq;

namespace MovieList.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        public readonly MovieListDbContext _context;
        public readonly IMapper _mapper;
        public GetGenresQuery(IMapper mapper, MovieListDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public GetGenresQuery(MovieListDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public MovieListDbContext Context { get; }
        public IMapper Mapper { get; }

        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
            return returnObj;
        }
    }
    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
