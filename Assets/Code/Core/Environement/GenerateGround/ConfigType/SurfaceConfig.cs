using UnityEditor;
using UnityEngine;


[System.Serializable]
public struct SurfaceConfig
{
    public int foliageBackgroundLayerPosition;
    [Range(-50, 20)]
    public int stonePositionY;
    public GameObject surfaceTile;
    public GameObject undergroundTile;
    public GameObject foliageTile;
    public GameObject flowerTile;
    public GameObject stoneTile;
    public GameObject doomStoneTile;
}

