using JetBrains.Annotations;
using UnityEngine;

public static class TileService
{
    private static Tile[] _database;

    private static Tile[] dataBase
    {
        get
        {
            if (_database == null)
            {
                _database = Resources.LoadAll<Tile>("Tiles/");
            }
            return _database;
        }
    }

    public static Tile GetTileByID(string id)
    {
        Tile result = null;
        foreach (Tile t in dataBase)
        {
            if (t.ID == id)
            {
                result = t;
                break;
            }
        }

        if (result != null)
        {
            result = Object.Instantiate(result);
        }
        
        return result;
    }

    public static Tile GetRandomTile()
    {
        int rand = UnityEngine.Random.Range(0, dataBase.Length);
        Tile result = dataBase[rand];
        if (result != null)
        {
            result = Object.Instantiate(result);
        }
        return result;
    }
}