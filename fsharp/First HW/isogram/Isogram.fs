module Isogram

open System

let isIsogram (str: string) =
    let word = str.ToUpper().ToCharArray() |> Seq.filter Char.IsLetter

    if (Seq.length word = (Seq.distinct word |> Seq.length))
    then true
    else false
