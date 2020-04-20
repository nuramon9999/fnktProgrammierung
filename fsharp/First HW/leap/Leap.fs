module Leap

let leapYear (year: int): bool =
    let currYear: int = year
    let mutable result: bool = false
    let div4 = currYear % 4
    result <- if div4 = 0 then true else false
    if (result) then
        (let div100 = currYear % 100
         result <- if div100 = 0 then false else true
         if (not result) then
             (let div400 = currYear % 400
              result <- if div400 = 0 then true else false))
    result
