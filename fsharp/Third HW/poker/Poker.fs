module Poker

open System
open System.Linq

type cardFormat = int * string

let picturesToInt =
    function
    | "J" -> 11
    | "Q" -> 12
    | "K" -> 13
    | "A" -> 14
    | x -> x |> int

let defineCard (card: string): cardFormat =
    let value =
        card
        |> Seq.take (card.Length - 1)
        |> String.Concat
        |> picturesToInt

    let color =
        card
        |> Seq.skip (card.Length - 1)
        |> String.Concat

    (value, color)

let calcScore (hand: string) =
    let listOfCards =
        hand.Split [| ' ' |]
        |> Array.toList
        |> List.map defineCard

    let numberVal, color = List.unzip listOfCards
    let sortedValues = List.sort numberVal

    let _, flush =
        color
        |> Seq.countBy id
        |> Seq.toList
        |> List.unzip
    let highCards =
        sortedValues
        |> List.map string
        |> (fun x -> String.Join("", x |> List.toArray))

    let straight = ("234567891011121314").Contains(highCards)
    let babyStraight = ("234514").Contains(highCards)

    let matchingCardVal, matchingCardsCount =
        numberVal
        |> Seq.countBy id
        |> Seq.toList
        |> List.sortBy (fun (x, y) -> (y, x))
        |> List.rev
        |> List.unzip

    let score =
        if (straight) && flush.Contains(5) then
            500000 + (sortedValues.Head) + (sortedValues.Item(1)) + (sortedValues.Item(2))
        else if (babyStraight) && flush.Contains(5) then
            500000
        else if matchingCardsCount.Contains(4) then
            450000 + (matchingCardVal.Head * 10) + matchingCardVal.Item(1)
        else if (matchingCardsCount.Contains(3) && matchingCardsCount.Contains(2)) then
            400000 + matchingCardVal.Head * 10 + matchingCardVal.Item(1)
        else if (flush.Contains(5)) then // the flush with the highest card wins
            350000 + (sortedValues.Head) + (sortedValues.Item(1)) + (sortedValues.Item(2))
        else if (straight) then
            300000 + (sortedValues.Item(4))
        else if (babyStraight) then
            300000
        else if (matchingCardsCount.Contains(3)) then
            250000 + (200 * matchingCardVal.Head) + (20 * (matchingCardVal.[1..].Item(0)))
            + (matchingCardVal.[1..].Item(1))
        else if (matchingCardsCount.Head = 2 && matchingCardsCount.Item(1) = 2) then
            230000 + (if (matchingCardVal.Item(0) > matchingCardVal.Item(1))
                      then matchingCardVal.Item(0) * 100 + matchingCardVal.Item(1) * 10 + matchingCardVal.Item(2)
                      else matchingCardVal.Item(1) * 100 + matchingCardVal.Item(0) * 10 + matchingCardVal.Item(2))
        else if (matchingCardsCount.Contains(2)) then
            170000 + (2000 * matchingCardVal.Head) + (200 * (matchingCardVal.[1..].Item(0)))
            + (20 * matchingCardVal.[1..].Item(1)) + (matchingCardVal.[1..].Item(1))
        else
            (sortedValues.Head * 10000) + (sortedValues.Item(1) * 1000) + (sortedValues.Item(2) * 100)
            + (sortedValues.Item(3) * 10) + (sortedValues.Item(4))

    score

let bestHands (hands: string list): string list =
    hands
    |> Seq.groupBy calcScore
    |> Seq.sortByDescending (fun (x, _) -> x)
    |> Seq.head
    |> snd
    |> Seq.toList
