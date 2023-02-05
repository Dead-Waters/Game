using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles{
    
    public static class TilesHelper
    {
        public static void CreateBlock(Vector2 position, GameObject tile, float backgroundLayerPosition = 0)
        {
            GameObject tileObject = MonoBehaviour.Instantiate(tile, position, Quaternion.identity);
            Tiles localTile = tileObject.GetComponent<Tiles>();
            localTile.position = position;
            localTile.backgroundLayerPosition = backgroundLayerPosition;
            localTile.Init();
        }
        public static bool isPlacableHere(Vector2 position)
        {
            // get the tile at the bottom of the provided position
            Vector2 bottomPosition = new Vector2(position.x, position.y - 1);
            RaycastHit2D hit = Physics2D.Raycast(bottomPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Tiles tile = hit.collider.GetComponent<Tiles>();
                if (tile != null)
                    return tile.canPlaceOn;
            }
            return false;
        }
    }
}