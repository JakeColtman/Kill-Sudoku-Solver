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

    type Location = 
        | Top of Axis
        | Bottom of Axis
        | Middle of Axis

    type SideAxes = Axis * Axis

    type Side = 
        | Back
        | TopSide
        | Base
        | LeftSide
        | RightSide
        | Front

    let position_of_side side = 
        match side with 
            | Back -> Bottom Z
            | Front -> Top Z
            | LeftSide -> Bottom X
            | RightSide -> Top X
            | TopSide -> Top Y
            | Base -> Bottom Y


//        
//    type XPosition = 
//       | Bottom of X * Bottom
//       | XMiddle
//       | Top 
//       
//    type YPosition = 
//       | Left
//       | YMiddle
//       | Right
//       
//    type ZPosition = 
//       | Front
//       | ZMiddle
//       | Back
//
//    type Position = 
//        | ZPosition of ZPosition
//        | YPosition of YPosition
//        | XPosition of XPosition

    type Coordinate = 
      | Coordinate of Location * Location * Location

    let all_locations = 
        
        let produce_all_positions x = [Top x ; Middle x ; Bottom x]
        produce_all_positions X
        |> List.collect (fun x -> (produce_all_positions Y) |> List.map (fun y -> x, y))
        |> List.collect (fun (x, y) -> (produce_all_positions Z) |> List.map (fun z -> Coordinate(x,y,z)))

    type RotationRequest = Side * Rotation

    type X2DPosition = 
        | Bottom2D
        | XMiddle2D
        | Top2D

    type Y2DPosition = 
        | Left2D
        | MiddleY2D
        | Right2D

    type Coordinate2D = X2DPosition * Y2DPosition

//    let mapper_into_2d side = 
//        match side with 
//            | Front -> (fun (x, y, z) -> match (x, y, z) with 
//                                            | (Top X, Left Y, _) -> (Top2D , Left2D)
//                                            | (Top X, Left Y, _) -> (Top2D , Left2D)
//                                            | (Top X, Left Y, _) -> (Top2D , Left2D)
//                                            | (Top X, Left Y, _) -> (Top2D , Left2D)
//
//            | Back -> 



module Cube = 

    open Geometry;

    type Color = 
        | Red
        | Blue
        | Green

    type Cube = 
        | Cube of Map<Axis, Color>

   // let rotateCube rotation_request cube = 
     //   let ((rotation_axis, _),_) = rotation_request
       // let update_function = axis_after_turn rotation_axis 

       /// cube |> Map.toList |> List.map (fun (axis, color) -> (update_function axis, color)) |> Map.ofList
       /// /
    let create color = 
        let mapping = [(X , color)] |> Map.ofList 
        Cube mapping

module RubikCube = 
    open Geometry;
    open Cube;

    type RubikCube = Map<Coordinate, Cube>

    let create = Geometry.all_locations 
                    |> List.map (fun x -> (x, Cube.create Cube.Red)) 
                    |> Map.ofList

    let extract_face rcube side = 
        
        let coordinate = Geometry.position_of_side side

        let newMapping = rcube |> Map.toList |> List.filter (fun (Coordinate (x, y, z), (value : Cube)) -> 
                                    match (coordinate, x, y, z) with 
                                        | (coordinate, x, y, z) when coordinate = x -> true
                                        | (coordinate, x, y, z) when coordinate = y -> true
                                        | (coordinate, x, y, z) when coordinate = z -> true
                                        | (_, _, _, _) -> false
                                        ) 
                                |> Map.ofList
        newMapping

//    let identify_remaining_no_zero_length_dimension (rcube: RubikCube) = 
//        rcube 
//            |> Map.toList 
//            |> List.map (fun (Coordinate (x,y,z), value) -> [x; y; z])
//            |> List.concat
//            |> List.distinct
//            |> List.groupBy (fun a ->
//                                match a with 
//                                    | XPosition x -> "x"
//                                    | YPosition y -> "y"
//                                    | ZPosition z -> "z"
//                            )
//           |> List.filter (fun (key,value) -> value.Length = 3)
//           |> List.map (fun (key, value) -> key)
//           |> List.take 1
//
//    let make_slices_from_dimension slice dimension_string = 
//        let position_list = 
//            match dimension_string with 
//                | "x" -> xPositions 
//                | "y" -> yPositions
//                | "z" -> zPositions
//
//        position_list 
//            |> List.map (fun x -> extract_slice slice x)
//           
//
//    let replace_slice rcube mapping = 
//        let cubeList = rcube |> Map.toList 
//        let newList = mapping |> Map.toList
//        (List.concat [newList; cubeList]) 
//            |> List.distinctBy (fun (key, value) -> key)
//            |> Map.ofList
//
//    let rotate_slice mapping = 
//        mapping |> Map.toList |> List.map (fun (key, value) -> (key, (Cube.rotateCube value))) |> Map.ofList
//
//    let create_by_positions cubes (xPos: Position list) (yPos: Position list) (zPos: Position list) = 
//
//        let allPositions  = create_positions xPos yPos zPos
//
//        List.zip allPositions cubes |> Map.ofList
//
//    let create cubes = create_by_positions cubes xPositions yPositions zPositions
//
//    let create_from_perspective (rcube: RubikCube) perspective = 
//   
//
//        let coordinates = 
//            match perspective with 
//            | (X, _) -> create_positions xPositions yPositions zPositions
//
//            | (Y, _) -> create_positions yPositions xPositions zPositions
//            | (Z, _) -> create_positions xPositions yPositions zPositions
//
//        let cubes = coordinates |> List.map (fun x -> Map.find x rcube)
//        create cubes
             
        
////
////
////    type convert_to_perspective cube perspective = 
////        match perspective with 
////            | ()
////
////    let rotate (cube:Cube) (turn: Turn) : Cube = 
////        let update_axis turn_axis old_axis =
////            match (old_axis, turn_axis) with 
////                | (X, Y) -> Z
////                | (X, Z) -> Y
////                | (Z, X) -> Y
////                | (Z, Y) -> X
////                | (Y, X) -> Z
////                | (Y, Z) -> X
////
////        let update_face_direction turn_direction old_face_direction = 
////            match (old_face_direction, turn_direction) with 
////            | (Into, Right) -> OutOf
////            | (OutOf, Right) -> Into
////            | (Into, Left) -> Into
////            | (OutOf, Left) -> OutOf
////
////        let (axis_of_turn, direction_of_turn) = turn
////        let update_position (cube_position , color) = 
////            let axis, face_position = cube_position
////            let newKey = ((update_axis axis_of_turn axis), (update_face_direction direction_of_turn face_position))
////            newKey, color
////        cube |> Map.toList |>  List.map update_position |> Map.ofList
////l

[<EntryPoint>]
let main argv = 
//    let cubes = [ for i in 1 .. 27 -> Cube.create Cube.Red ]
//    let perspective = Geometry.X , Geometry.Right
//    let cube = RubikCube.create (cubes)
//    let slice = RubikCube.extract_slice cube (Geometry.ZPosition Geometry.Front)
//    printfn "%A" slice
//    let newDimension = RubikCube.identify_remaining_no_zero_length_dimension slice
//    let slicetwo = RubikCube.make_slices_from_dimension slice (newDimension.Head)
//    printfn "%A" slicetwo
    let RCube = RubikCube.create 
    let side = RubikCube.extract_face RCube Geometry.LeftSide
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
