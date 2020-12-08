namespace MvcMovieFs.Models.Movie

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

        Rating : string
    }

// type ErrorViewModel =
//     { RequestId: string }

//     member this.ShowRequestId =
//         not (String.IsNullOrEmpty(this.RequestId))