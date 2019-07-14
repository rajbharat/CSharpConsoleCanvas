# consolecanvas
A simple, fun program to draw on console.

# overview
The program was built using .Net 4.7.2 and VS 2019 Community Edition

# usage

```
Command 		Description
C w h           Create a new canvas of width w and height h.
L x1 y1 x2 y2   Create a new line of 'x' from (x1,y1) to (x2,y2). Only support 
                horizontal or vertical lines.
R x1 y1 x2 y2   Create a new rectangle, (x1,y1) is upper left corner & (x2,y2) is 
                lower right corner.
B x y c         Fill the entire area around (x,y) with "character" c.
                Same as that of the "bucket fill" tool in paint programs.
Q               Quit.
``` 

# example - Enter Commands as shown below
```
$ C 20 4
----------------------
|                    |
|                    |
|                    |
|                    |
----------------------

$ L 1 2 6 2
----------------------
|                    |
|xxxxxx              |
|                    |
|                    |
----------------------

$ L 6 3 6 4
----------------------
|                    |
|xxxxxx              |
|     x              |
|     x              |
----------------------

$ R 14 1 18 3
----------------------
|             xxxxx  |
|xxxxxx       x   x  |
|     x       xxxxx  |
|     x              |
----------------------

$ B 10 3 0
----------------------
|0000000000000xxxxx00|
|xxxxxx0000000x   x00|
|     x0000000xxxxx00|
|     x00000000000000|
----------------------
```
# commands

- From prebuilt CMD: in Command Prompt, navigate to Solution Dir\Out 
	-Type ConsoleCanvas and start using commands as provided above
- From source:
    - Run program and tests from visual studio
	
	
# Restrictions & Assumptions
- When You create Canvas Multiple Times, Canvas is recreated as per new dimensions
- Validated Negative params and out of bounds params (Based on Canvas Size) 
- Color takes only numerical input : 0-9
- Max Size for Canvass to be Validated - Say 100. Fill Should Take only Positive Numbers 
- If Canvas Size is defined as 20 x 20, Actual Size will be 22 x 22 ; 2 extra units are added for border.
- Filled Area can be overwritten by Rectangle / Line but not by another Fill Color character
