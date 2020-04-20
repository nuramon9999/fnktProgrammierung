module QueenAttack

let create (a, b) = a >= 0 && a < 8 && b >= 0 && b < 8

let canAttack (a1, b1) (a2, b2) =
    a1 = a2 || b1 = b2 || (a2 - a1) / (b2 - b1)
                          |> abs = 1
