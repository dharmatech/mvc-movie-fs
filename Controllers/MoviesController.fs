namespace MvcMovieFs.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open System.Diagnostics

open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Mvc.Rendering
open Microsoft.Extensions.Logging

open MvcMovieFs.Data
open MvcMovieFs.Models.MovieGenreViewModel

type MoviesController private () =

    inherit Controller()

    [<DefaultValue>]
    val mutable _Context : MvcMovieContext

    new (context : MvcMovieContext) as this =
        new MoviesController () then
        this._Context <- context

    member this.Index(movie_genre : string, search_string : string) =

        // let movies = this._Context.Movie.Select(fun elt -> elt)
        
        let mutable movies = this._Context.Movie.Select(id)

        // if not (String.IsNullOrEmpty(search_string)) then
        //     movies <- movies.Where(fun elt -> elt.Title.Contains(search_string))

        // if not (String.IsNullOrEmpty(movie_genre)) then
        //     movies <- movies.Where(fun elt -> elt.Genre = movie_genre)

        this.View(
            { 
                Genres = new SelectList(this._Context.Movie.OrderBy(fun elt -> elt.Genre).Select(fun elt -> elt.Genre).Distinct().ToList())
                Movies = movies.ToList()
                MovieGenre = null
                SearchString = null
            }
        )

        // "abc"