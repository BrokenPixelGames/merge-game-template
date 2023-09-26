using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private static GameManager _inst;
    public static GameManager Instance
    {
        get
        {
            if (_inst == null)
            {
                _inst = FindObjectOfType<GameManager>();
            }
            return _inst;
        }
    }
    
    private Tile primerTile;

    public void Select(Tile tile)
    {
        if (primerTile == null)
        {
            primerTile = tile;
            primerTile.IsPrimed = true;
        }
        else
        {
            if (tile == primerTile)
            {
                primerTile.IsPrimed = false;
                primerTile = null;
            }
            else
            {
                if (tile.IsMatch(primerTile))
                {
                    GameBoard.Instance.Clear(tile.coord, true);
                    GameBoard.Instance.Clear(primerTile.coord, true);
                    primerTile = null;
                }
                else
                {
                    primerTile.IsPrimed = false;
                    primerTile = null;
                }
            }
        }
    }

    private void SetupDebugBoard()
    {
        GameBoard board = GameBoard.Instance;
        for (int x = 0; x < GameBoard.Size; x++)
        {
            for (int y = 0; y < GameBoard.Size; y++)
            {
                Tile newTile = null;
                int val = Random.Range(0, 4);
                switch (val)
                {
                    case 0:
                        newTile = TileService.GetTileByID("Tile_Fire");
                        break;
                    case 1:
                        newTile = TileService.GetTileByID("Tile_Ice");
                        break;
                    case 2:
                        newTile = TileService.GetTileByID("Tile_Heart");
                        break;
                    case 3:
                        newTile = TileService.GetTileByID("Tile_Thunder");
                        break;
                    case 4:
                        newTile = TileService.GetTileByID("Tile_Water");
                        break;
                    default:
                        newTile = TileService.GetTileByID("Tile_Fire");
                        break;
                }
                
                board.Set(newTile, new Vector2Int(x,y));
            }
        }
    }

    private void Start()
    {
        SetupDebugBoard();
    }
}