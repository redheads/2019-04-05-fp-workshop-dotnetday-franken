module NonEmptyString

open System

type NonEmptyString = private NonEmptyString of string

let (|NonEmptyString|) = function
        | NonEmptyString s -> NonEmptyString s

let create s =
    match String.IsNullOrWhiteSpace(s) with
        | true -> Error ["String must not be empty"]
        | false -> Ok (NonEmptyString s)

let get (NonEmptyString nes) =
        nes