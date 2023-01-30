using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TilesHelper
{
    public static void CreateBlock(Vector2 position, Sprite sprite, int backgroundLayerPosition = 0)
    {
        GameObject tileObject = new GameObject("Tile");
        tileObject.AddComponent<SpriteRenderer>();
        Tiles tile = tileObject.AddComponent<Tiles>();
        tile.sprite = sprite;
        tile.position = position;
        tile.size = new Vector2(1, 1);
        tile.backgroundLayerPosition = backgroundLayerPosition;
        tile.Init();
    }
}
