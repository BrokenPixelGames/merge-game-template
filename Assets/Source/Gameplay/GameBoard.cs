using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    private static GameBoard _inst;
    public static GameBoard Instance
    {
        get
        {
            if (_inst == null)
            {
                _inst = FindObjectOfType<GameBoard>();
            }
            return _inst;
        }
    }
    
    public float viewStartX = 0;
    public float viewStartY = 0;

    public Transform tilesParent;

    public const int Size = 5;
    
    public TileSpace[,] Spaces = new TileSpace[Size, Size];

    public TileSpace At(Vector2Int coord)
    {
        return Spaces[coord.x, coord.y];
    }

    public void Set(Tile tile, Vector2Int coord)
    {
        tile.transform.SetParent(tilesParent);
        
        tile.Set(Spaces[coord.y,coord.y]);
        Spaces[coord.x, coord.y].Set(tile);
    }

    public void DestroyAt(Vector2Int coord)
    {
        TileSpace s = Spaces[coord.x, coord.y];
        if (s.tile != null)
        {
            GameObject.Destroy(s.tile.gameObject);
        }
    }

    public void Clear(Vector2Int coord, bool destroy)
    {
        if (destroy)
        {
            DestroyAt(coord);
        }
        Spaces[coord.x, coord.y].tile = null;
    }

    public Tile GetTileAt(Vector2Int coord)
    {
        return Spaces[coord.x, coord.y].tile;
    }

    public IEnumerator GetEnumerator()
    {
        return Spaces.GetEnumerator();
    }

    private void Awake()
    {
        for (int x = 0; x < Spaces.GetLength(0); x++)
        {
            for (int y = 0; y < Spaces.GetLength(1); y++)
            {
                Spaces[x, y] = new TileSpace()
                {
                    tile = null,
                    coord = new Vector2Int(x,y)
                };
            }
        }

        tilesParent.transform.localPosition = new Vector3()
        {
            x = viewStartX,
            y = viewStartY,
            z = 0
        };
    }

    private void OnDrawGizmos()
    {
        return;
        for (int x = 0; x < Spaces.GetLength(0); x++)
        {
            for (int y = 0; y < Spaces.GetLength(1); y++)
            {
                Vector3 pos = new Vector3(viewStartX + x, viewStartY + y, 0);
                Gizmos.DrawWireCube(pos, Vector3.one);
            }
        }
    }
}
