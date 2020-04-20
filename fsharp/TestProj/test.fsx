(* let list1 = [ 3; 5 ]
let upperBound = 20
let sum = 0

let add value = sum = sum + value

let distinctList =
    list1
    |> Seq.collect (fun item -> [ item .. item .. upperBound - 1 ])
    |> Seq.distinct

printfn "%A" (Seq.toList distinctList)
printfn "%i" (Seq.sum distinctList) *)

let str:string = "hypeh"
printfn "%A" (
    str.ToCharArray()
    |> Seq.distinct
    |> Seq.map string
    |> String.concat "")
