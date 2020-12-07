namespace MvcMovieFs.Controllers

open Microsoft.AspNetCore.Mvc
open System.Text.Encodings.Web
open Microsoft.AspNetCore.Mvc.ViewFeatures

type HelloWorldController () =
    inherit Controller()

    member this.Index () = this.View()
        
    member this.Welcome (name : string, num_times : int) =
        this.ViewData.Add("Message", box ("Hello " + name))
        this.ViewData.Add("NumTimes", box num_times)

        this.View()    