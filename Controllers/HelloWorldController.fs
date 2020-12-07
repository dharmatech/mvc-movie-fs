namespace MvcMovieFs.Controllers

open Microsoft.AspNetCore.Mvc
open System.Text.Encodings.Web

type HelloWorldController () =
    inherit Controller()

    member this.Index () = "default action"

    member this.Welcome () = "welcome action method"

    member this.WelcomeAlt (name : string, num_times : int) =
        HtmlEncoder.Default.Encode($"Hello {name}, num_times is: {num_times}")

    member this.WelcomeAlt2 (name : string, id : int) =
        HtmlEncoder.Default.Encode($"Hello {name}, id: {id}")