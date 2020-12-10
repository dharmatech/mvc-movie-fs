namespace MvcMovieFs.Models.Movie

open System
open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema

[<CLIMutable>]
type Movie =
    {
        Id : int

        [<StringLength(60, MinimumLength = 3)>]
        [<Required>]
        Title : string

        [<Display(Name = "Release Date")>]
        [<DataType(DataType.Date)>]
        ReleaseDate : DateTime

        [<RegularExpression(@"^[A-Z]+[a-zA-Z]*$")>]
        [<Required>]
        Genre : string

        [<Range(1, 100)>]
        // [<DataType(DataType.Currency)>]
        [<Column(TypeName = "decimal(18, 2)")>]
        Price : decimal

        [<RegularExpression(@"^[A-Z]+[a-zA-Z0-9-]*$")>]
        [<StringLength(5)>]
        [<Required>]
        Rating : string
    }