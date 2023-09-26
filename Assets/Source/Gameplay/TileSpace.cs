using System;
using UnityEngine;

[Serializable]
public struct TileSpace
{
    public Tile tile;
    public Vector2Int coord;

    public bool IsMatch(Tile other)
    {
        if (tile == null || other == null)
        {
            return false;
        }

        return tile.IsMatch(other);
    }

    public void Set(Tile t)
    {
        t.transform.localPosition = new Vector3(coord.x, coord.y, 0);
        t.Set(this);
        tile = t;
    }
}