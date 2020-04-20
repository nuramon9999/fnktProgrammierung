let list1 = [ 1; 5; 100; 450; 788 ]
for i in list1 do
    printfn "%d" i
list1 |> List.iter (fun item ->
    printfn "%d" item)

let sum (numbers: int list) (upperBound: int): int =
    let list: int list = [ 1; 2; 3 ]
    list
    |> List.iter (fun item -> item)

sum [3,4,5] 20