module Gigasecond

open System

let gigasecond = 1_000_000_000
let gigasecondTimeSpan = TimeSpan(0, 0, gigasecond)

let add (dateData: DateTime): DateTime = dateData.Add(gigasecondTimeSpan)
