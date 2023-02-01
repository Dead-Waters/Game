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
    }
}