using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiles;
using UnityEngine.UIElements;
using System;

public class GenerateGround : MonoBehaviour
{
    public int numberOfTiles = 100;
    public Vector2 origin = Vector2.zero;
    public int minBlockY = 0;
    public GameObject player;

    public float perlinNoiseAmplitude = 1;
    public float perlinNoiseSmoothness = 1;

    // Start is called before the first frame update

    void Start()
    {
        //perlinNoiseSmoothness = 10 : calculatedSmoothness=0.1
        //perlinNoiseSmoothness = 100 : calculatedSmoothness=0.01
        //perlinNoiseSmoothness = 1000 : calculatedSmoothness=0.001
        player.tag = "Player";
        
        float calculatedSmoothness = 1 / perlinNoiseSmoothness;
        Vector2 calculatedOrigin = new Vector2(origin.x - (numberOfTiles / 2), origin.y);

        for (int i = 0; i < numberOfTiles; i++)
        {
            float x = calculatedOrigin.x + i;
            float y = origin.y + Mathf.PerlinNoise(x* calculatedSmoothness, 0) * perlinNoiseAmplitude;
            if (player && x == origin.x)
                player.transform.position = new Vector3(origin.x, Mathf.Round(y) + 1, 0);
            CreateLine(new Vector2(Mathf.Round(x), Mathf.Round(y)));
        } 
    }

    void CreateLine(Vector2 position)
    {
        float calculatedSmoothness = 1 / perlinNoiseSmoothness;
        SurfaceConfig surfaceConfiguration = GeneratorConfig.getInstance().surfaceConfiguration;
        
        setDecoration(position);
        
        TilesHelper.CreateBlock(position, surfaceConfiguration.surfaceTile);
        
        if (surfaceConfiguration.stonePositionY > minBlockY)
        {
            int offset = Mathf.RoundToInt(Mathf.PerlinNoise(position.x * calculatedSmoothness, 0) * (perlinNoiseAmplitude/2));
            fillLine(position, Convert.ToInt32(position.y - 1), surfaceConfiguration.stonePositionY + offset, surfaceConfiguration.undergroundTile);
            fillLine(position, surfaceConfiguration.stonePositionY + offset, minBlockY, surfaceConfiguration.stoneTile);
        }
        else
            fillLine(position, Convert.ToInt32(position.y - 1), minBlockY, surfaceConfiguration.undergroundTile);
        TilesHelper.CreateBlock(new Vector2(position.x,minBlockY), surfaceConfiguration.doomStoneTile);
    }

    void fillLine(Vector2 position, int startPos, int endPos, GameObject tile)
    {
        
        for (float i = startPos; i > endPos; i--)
        {
            TilesHelper.CreateBlock(new Vector2(position.x, i), tile);
        }
    }

    void setDecoration(Vector2 position)
    {
        SurfaceConfig surfaceConfiguration = GeneratorConfig.getInstance().surfaceConfiguration;
        int random = UnityEngine.Random.Range(0, 100);
        if (random <= 8)
            TilesHelper.CreateBlock(new Vector2(position.x, position.y + 1), surfaceConfiguration.flowerTile, surfaceConfiguration.foliageBackgroundLayerPosition);
        if (random > 8)
            TilesHelper.CreateBlock(new Vector2(position.x, position.y + 1), surfaceConfiguration.foliageTile, surfaceConfiguration.foliageBackgroundLayerPosition);

        if (UnityEngine.Random.Range(0, 100) < 5)
            TreeGenerator.AddTree(new Vector2(position.x, position.y + 1));
    }
}
