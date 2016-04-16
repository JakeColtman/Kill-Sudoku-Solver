// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

module Geometry = 

    type Rotation = 
        | Left
        | Right

    type Direction = 
        | Into
        | OutOf

    type Axis = 
        | X
        | Y 
        | Z
        
    type XPosition = 
       | Bottom
       | XMiddle
       | Top 
       
    type YPosition = 
       | Left
       | YMiddle
       | Right
       
    type ZPosition = 
       | Front
       | ZMiddle
       | Back

    type Position = 
        | ZPosition of ZPosition
        | YPosition of YPosition
        | XPosition of XPosition

    type Coordinate = 
      | Coordinate of Position * Position * Position

    type Perspective = Axis * Direction

    type RotationRequest = Perspective * Rotation

    let axis_after_turn axis_of_turn original_axis  = 
        let mapping = [((X, Z),Y); ((X, Y),Z); ((Y, X),Z); ((Y, Z),X);((Z, Y),X); ((Z,X),Y) ] |> Map.ofList
        mapping.Item (original_axis, axis_of_turn)
    

module Cube = 

    open Geometry;

    type Color = 
        | Red
        | Blue
        | Green

    type Cube = 
        | Cube of Map<Axis, Color>

    let rotateCube rotation_request cube = 
        let ((rotation_axis, _),_) = rotation_request
        let update_function = axis_after_turn rotation_axis 

        cube |> Map.toList |> List.map (fun (axis, color) -> (update_function axis, color)) |> Map.ofList

    let create color = 
        let mapping = [(X , color)] |> Map.ofList 
        Cube mapping

module RubikCube = 
    open Geometry;
    open Cube;

    type RubikCube = Map<Coordinate, Cube>


    let create_positions xs ys zs = 
        xs 
        |> List.collect (fun x -> ys |> List.map (fun y -> x, y))
        |> List.collect (fun (x, y) -> zs |> List.map (fun z -> Coordinate(x,y,z)))

    let xPositions = [XPosition Bottom; XPosition XMiddle; XPosition Top] 
    let yPositions = [YPosition Left; YPosition YMiddle; YPosition Right] 
    let zPositions = [ZPosition Front; ZPosition ZMiddle; ZPosition Back]

    let create_by_positions cubes xPos yPos zPos = 

        let allPositions  = create_positions xPos yPos zPos

        List.zip allPositions cubes |> Map.ofList

    let create cubes = create_by_positions cubes xPositions yPositions zPositions

    let create_from_perspective (rcube: RubikCube) perspective = 
   

        let coordinates = 
            match perspective with 
            | (X, _) -> create_positions xPositions yPositions zPositions
            | (Y, _) -> create_positions yPositions xPositions zPositions
            | (Z, _) -> create_positions xPositions yPositions zPositions

        let cubes = coordinates |> List.map (fun x -> Map.find x rcube)
        create cubes
             
        
//
//
//    type convert_to_perspective cube perspective = 
//        match perspective with 
//            | ()
//
//    let rotate (cube:Cube) (turn: Turn) : Cube = 
//        let update_axis turn_axis old_axis =
//            match (old_axis, turn_axis) with 
//                | (X, Y) -> Z
//                | (X, Z) -> Y
//                | (Z, X) -> Y
//                | (Z, Y) -> X
//                | (Y, X) -> Z
//                | (Y, Z) -> X
//
//        let update_face_direction turn_direction old_face_direction = 
//            match (old_face_direction, turn_direction) with 
//            | (Into, Right) -> OutOf
//            | (OutOf, Right) -> Into
//            | (Into, Left) -> Into
//            | (OutOf, Left) -> OutOf
//
//        let (axis_of_turn, direction_of_turn) = turn
//        let update_position (cube_position , color) = 
//            let axis, face_position = cube_position
//            let newKey = ((update_axis axis_of_turn axis), (update_face_direction direction_of_turn face_position))
//            newKey, color
//        cube |> Map.toList |>  List.map update_position |> Map.ofList
//l

[<EntryPoint>]
let main argv = 
    let cubes = [ for i in 1 .. 27 -> Cube.create Cube.Red ]
    let perspective = Geometry.X , Geometry.Right
    let cube = RubikCube.create (cubes)
    let zcube = RubikCube.create_from_perspective cube perspective
    printfn "%A" (RubikCube.create (cubes))
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
