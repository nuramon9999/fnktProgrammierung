module TwoFer

let twoFer (input: string option): string =
    let name =
        match input with
        | None -> "you"
        | Some input -> input
    sprintf "One for %s, one for me." name
