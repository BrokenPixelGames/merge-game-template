using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public string ID
    {
        get
        {
            return this.gameObject.name.Replace("(Clone)", "");
        }
    }
    
    public bool IsPrimed { get; set; }
    public TileSpace TileSpace { get; private set; }
    public Vector2Int coord { get; private set; }

    public void Set(TileSpace parent)
    {
        coord = parent.coord;
        TileSpace = parent;
    }
    
    public bool IsMatch(Tile other)
    {
        return other.ID == this.ID;
    }

    private void OnMouseDown()
    {
        GameManager.Instance.Select(this);
    }
}