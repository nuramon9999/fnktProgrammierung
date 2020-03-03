module SumOfMultiples

let sum (numbers: int list) (upperBound: int): int =
    let totalSum = 0
    let multiplier = 1
    numbers
    |> List.iter (fun item ->
        while item * multiplier < upperBound do
            totalSum * multiplier
            multiplier = multiplier + 1)

    totalSum
