# Description

TOY Robot is a simulator which follow following rules:
- The library allows for a simulation of a toy robot moving on a 5 x 5 square tabletop.
- There are no obstructions on the table surface.
- The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement that would result in this must be prevented, however further valid movement commands must still be allowed.
- PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
(0,0) can be considered as the SOUTH WEST corner and (5,5) as the NORTH EAST corner.
- The first valid command to the robot is a PLACE command. After that, any sequence of commands may be issued, in any order, including another PLACE command. The library should discard all commands in the sequence until a valid PLACE command has been executed.
- The PLACE command should be discarded if it places the robot outside of the table surface.
- Once the robot is on the table, subsequent PLACE commands could leave out the direction and only provide the coordinates. When this happens, the robot moves to the new coordinates without changing the direction.
- MOVE will move the toy robot one unit forward in the direction it is currently facing.
- LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
- REPORT will announce the X,Y and orientation of the robot.
- A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands.

# Instruction to complie the code.
Compile the code in Visual studio on .NET Core 3.1.
Execute the code.

# Instruction to execute the code.
- Run the code
- User can enter the following commands.
  * PLACE X,Y,DIRECTION
  * MOVE
  * RIGHT
  * LEFT
  * REPORT
  
# Sample Execution
    Creating Board of 5x5 tiles.
    Creating Robot.
    Place your robot on the board:
    Cmd>>PLACE 1,1,NORTH
    Congratulations you have successfully placed the robot on the board.
    Cmd>>MOVE
    Cmd>>MOVE
    Cmd>>LEFT
    Cmd>>MOVE
    Cmd>>REPORT
    Output: 0,3,WEST
    Cmd>>RIGHT
    Cmd>>REPORT
    Output: 0,3,NORTH
    Cmd>>PLACE 3,3,EAST
    Cmd>>MOVE
    Cmd>>LEFT
    Cmd>>MOVE
    Cmd>>REPORT
    Output: 4,4,NORTH
    Cmd>>RIGHT
    Cmd>>REPORT
    Output: 4,4,EAST
    Cmd>>