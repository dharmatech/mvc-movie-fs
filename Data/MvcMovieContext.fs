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
                Title = "Enter the Dragon"
                ReleaseDate = DateTime.Parse("1973-08-19")
                Genre = "Martial Arts"
                Price = 7.99M
                Rating = "R"
            },
            
            {
                Id = 0
                Title = "The Twilight Samurai"
                ReleaseDate = DateTime.Parse("2002-11-02")
                Genre = "Samurai"
                Price = 8.99M
                Rating = "R"
            },

            
            {
                Id = 0
                Title = "Ford v Ferrari"
                ReleaseDate = DateTime.Parse("2019-11-15")
                Genre = "Racing"
                Price = 9.99M
                Rating = "PG-13"
            },

            {
                Id = 0
                Title = "War Games"
                ReleaseDate = DateTime.Parse("1983-06-03")
                Genre = "Computer Hacker"
                Price = 3.99M
                Rating = "PG"
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

