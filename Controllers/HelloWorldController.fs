namespace MvcMovieFs.Controllers

open Microsoft.AspNetCore.Mvc
open System.Text.Encodings.Web

type HelloWorldController () =
    inherit Controller()

    member this.Index () = "default action"