namespace MvcMovieFs.Models

open System
open System.ComponentModel.DataAnnotations

[<CLIMutable>]
type Movie =
    {
        Id : int
        Title : string

        [<DataType(DataType.Date)>]
        ReleaseDate : DateTime
        
        Genre : string
        Price : decimal
    }