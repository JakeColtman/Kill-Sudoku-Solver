// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

module Cube = 

    type Color = 
        | Red
        | Blue
        | Green

    type TurnDirection = 
        | Left
        | Right

    type FaceDirection = 
        | Into
        | OutOf

    type Axis = 
        | X
        | Y 
        | Z

    type Turn = Axis * TurnDirection

    type CubePosition = Axis * FaceDirection

    type Cube = Map<CubePosition, Color>

    let create  (input : List<(CubePosition * Color)>) : Cube = input|> Map.ofList

    let rotate (cube:Cube) (turn: Turn) : Cube = 
        let update_axis turn_axis old_axis =
            match (old_axis, turn_axis) with 
                | (X, Y) -> Z
                | (X, Z) -> Y
                | (Z, X) -> Y
                | (Z, Y) -> X
                | (Y, X) -> Z
                | (Y, Z) -> X

        let update_face_direction turn_direction old_face_direction = 
            match (old_face_direction, turn_direction) with 
            | (Into, Right) -> OutOf
            | (OutOf, Right) -> Into
            | (Into, Left) -> Into
            | (OutOf, Left) -> OutOf

        let (axis_of_turn, direction_of_turn) = turn
        let update_position (cube_position , color) = 
            let axis, face_position = cube_position
            let newKey = ((update_axis axis_of_turn axis), (update_face_direction direction_of_turn face_position))
            newKey, color
        cube |> Map.toList |>  List.map update_position |> Map.ofList


[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
