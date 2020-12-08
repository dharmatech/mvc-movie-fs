namespace MvcMovieFs.Data

open System
open System.Linq
open Microsoft.EntityFrameworkCore
open MvcMovieFs.Models.Movie

type MvcMovieContext(options : DbContextOptions<MvcMovieContext>) =
    inherit DbContext(options)

    [<DefaultValue>]
    val mutable Movie : DbSet<Movie>

    member public this._Movie
        with get ()      = this.Movie
        and  set (value) = this.Movie <- value

module DataContextInitialize =

    let Initialize (context : MvcMovieContext) =
        context.Database.EnsureCreated() |> ignore

        context.Movie.AddRange(
            {
                Id = 0 
                Title = "When Harry Met Sally"
                ReleaseDate = DateTime.Parse("1989-2-12")
                Genre = "Romantic Comedy"
                Price = 7.99M
                Rating = "G"
            },
            
            {
                Id = 0
                Title = "Ghostbusters "
                ReleaseDate = DateTime.Parse("1984-3-13")
                Genre = "Comedy"
                Price = 8.99M
                Rating = "G"
            },

            
            {
                Id = 0
                Title = "Ghostbusters 2"
                ReleaseDate = DateTime.Parse("1986-2-23")
                Genre = "Comedy"
                Price = 9.99M
                Rating = "G"
            },
            
            {
                Id = 0
                Title = "Rio Bravo"
                ReleaseDate = DateTime.Parse("1959-4-15")
                Genre = "Western"
                Price = 3.99M
                Rating = "G"
            }            
        ) |> ignore

        context.SaveChanges() |> ignore

