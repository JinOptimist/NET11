using BusinessLayerInterfaces.BusinessModels;
using DALInterfaces.Models;

namespace BusinessLayerInterfaces.MovieServices;

public interface IAddMovieServices
{
    void Add (MovieBlm  movieBlm);
}