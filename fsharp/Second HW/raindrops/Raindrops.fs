module Raindrops

let cache =
    dict
        [ 3, "Pling"
          5, "Plang"
          7, "Plong" ]

let convert number =
    cache.Keys
    |> Seq.filter (fun k -> number % k = 0)
    |> Seq.map (fun k -> cache.[k])
    |> String.concat ""
    |> fun res ->
        if res = "" then string number else res
