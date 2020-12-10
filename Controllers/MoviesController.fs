namespace MvcMovieFs.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open System.Diagnostics

open Microsoft.EntityFrameworkCore
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Mvc.Rendering
open Microsoft.Extensions.Logging

open MvcMovieFs.Data
open MvcMovieFs.Models.Movie
open MvcMovieFs.Models.MovieGenreViewModel

type MoviesController private () =

    inherit Controller()

    [<DefaultValue>]
    val mutable _Context : MvcMovieContext

    new (context : MvcMovieContext) as this =
        new MoviesController () then
        this._Context <- context

    member this.Index(movieGenre : string, searchString : string) =
        
        let mutable movies = query {
            for elt in this._Context.Movie do
                select elt
        }

        if not (String.IsNullOrEmpty(searchString)) then
            movies <- query {
                for elt in movies do
                    where (elt.Title.Contains(searchString))
                    select elt
            }
        
        if not (String.IsNullOrEmpty(movieGenre)) then
            movies <- query {
                for elt in movies do
                    where (elt.Genre = movieGenre)
                    select elt
            }

        this.View(
            { 
                Genres = new SelectList(this._Context.Movie
                    .OrderBy(fun elt -> elt.Genre)
                    .Select(fun elt -> elt.Genre)
                    .Distinct()
                    .ToList())
                    
                Movies = movies.ToList()
                MovieGenre = null
                SearchString = null
            }
        )

    member this.Details(id : Nullable<int>) =

        if (not id.HasValue) then 
            this.NotFound() :> IActionResult
        else

            let id_val = id.Value
                        
            let movie = this._Context.Movie.FirstOrDefault(fun elt -> elt.Id = id_val)
            
            if (isNull (box movie)) then
                this.NotFound() :> IActionResult
            else
                this.View(movie) :> IActionResult

    member this.Create() = this.View()

    [<HttpPost>]
    [<ValidateAntiForgeryToken>]
    member this.Create([<Bind("Id,Title,ReleaseDate,Genre,Price,Rating")>]movie : Movie) =
        if this.ModelState.IsValid then
            this._Context.Add(movie) |> ignore
            this._Context.SaveChanges() |> ignore
            this.RedirectToAction("Index") :> IActionResult
        else
            this.View(movie) :> IActionResult

    member this.Edit(id : Nullable<int>) =
        if (not id.HasValue) then
            this.NotFound() :> IActionResult
        else
            let movie = this._Context.Movie.Find(id)

            if (isNull (box movie)) then 
                this.NotFound() :> IActionResult
            else 
                this.View(movie) :> IActionResult
    
    [<HttpPost>]
    [<ValidateAntiForgeryToken>]
    member this.Edit(id : int, [<Bind("Id,Title,ReleaseDate,Genre,Price,Rating")>]movie : Movie) =

        if id <> movie.Id then
            this.NotFound() :> IActionResult
        elif this.ModelState.IsValid then
            try
                this._Context.Update(movie) |> ignore
                this._Context.SaveChanges() |> ignore
                this.RedirectToAction("Index") :> IActionResult
            with
                | :? DbUpdateConcurrencyException as ex ->
                    if not (this._Context.Movie.Any(fun elt -> elt.Id = id)) then
                        this.NotFound() :> IActionResult
                    else
                        failwith "abc"
        else
            this.View(movie) :> IActionResult

    member this.Delete(id : Nullable<int>) =
        if not id.HasValue then
            this.NotFound() :> IActionResult
        else
            let id_value = id.Value

            let movie = this._Context.Movie.FirstOrDefault(fun elt -> elt.Id = id_value)

            if isNull (box movie) then
                this.NotFound() :> IActionResult
            else
                this.View(movie) :> IActionResult

    [<HttpPost>]
    [<ValidateAntiForgeryToken>]
    member this.Delete(id : int) =
        let movie = this._Context.Movie.Find(id)
        this._Context.Movie.Remove(movie) |> ignore
        this._Context.SaveChanges() |> ignore
        this.RedirectToAction("Index")
