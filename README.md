# Merge Game Template
Template for developing merge games for mobile platforms. This document describes the public-facing methods you can use to start building your own merge, match or tile-based Hyper-Casual Game (HCG).

# Game Manager
### Sets up the game board and allows selecting of tiles.

## Functions
- **Select**
	- Nominates a given tile for selection.

# GameBoard
### Contains a grid system that holds spaces for each tile on the board.
## Variables
- **TilesParent**: Transform
	- The gameobject that acts as the parent for all Tiles on the GameBoard
## Functions
- **At** (***Vector2Int***: Coordinate)
	- returns the *TileSpace* at a specified coordinate.
- **Set** (***Tile***: Tile, ***Vector2Int***: Coordinate)
	- Places a given *Tile* at the specified coordinate.
- **DestroyAt** (**Vector2Int** Coordinate)
	- Removes *Tile* at specified coordinate. If empty, nothing happens.
- **GetTileAt** (**Vector2Int**: Coordinate)
	- Returns the *Tile* at a specified coordinate.

# TileSpace
###  The cell that makes up the gameboard. Each Tilespace can be occupied or empty.
## Variables
- **Tile**: Tile
- **Coord**: Vector2Int
## Functions
- **IsMatch**(**Tile**: Other)
	- Returns true if the ID of **Other** *Tile* matches the ID of the tile in this TileSpace. Returns false if no tile exists in this TileSpace.
- **Set**(**Tile**: tile)
		- Places the given tile into this TileSpace and marks the space as 'occupied'.

# Tile
### Interactable game object that displays with graphical representation.
## Variables
- **ID** : String
- **IsPrimed** : Bool
	- Whether this tile has been marked for selected during the next comparison. *e.g. The first tile clicked before clicking another one to match with.*)
- **TileSpace** : TileSpace
	- The parent cell on the GameBoard
- **Coord** : Vector2Int
## Functions
- **IsMatch**(**Tile**: Other)
	- Returns true if the ID of **Other** *Tile* matches this one.
