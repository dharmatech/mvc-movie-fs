namespace MvcMovieFs.Models.MovieGenreViewModel

open Microsoft.AspNetCore.Mvc.Rendering
open MvcMovieFs.Models.Movie

[<CLIMutable>]
type MovieGenreViewModel = {
    // Movies : List<Movie>
    Movies : System.Collections.Generic.List<Movie>
    Genres : SelectList
    MovieGenre : string
    SearchString : string
}

