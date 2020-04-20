module Accumulate

let accumulate (inputFunc: 'a -> 'b) (input: 'a list): 'b list =
    [ for x in input do
        yield inputFunc x ]
