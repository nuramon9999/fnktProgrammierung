module SumOfMultiples

let sum (numbers: int list) (upperBound: int): int =
    numbers
    |> Seq.filter (fun n -> n > 0)
    |> Seq.collect (fun n -> [ n .. n .. upperBound - 1 ]) //n-start .. n-steps .. upperBound
    |> Seq.distinct
    |> Seq.sum
