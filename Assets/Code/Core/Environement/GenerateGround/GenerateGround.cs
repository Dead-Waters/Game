using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGround : MonoBehaviour
{
    public int numberOfTiles = 100;
    public Vector2 origin = Vector2.zero;
    public int yDirt = 0;
    public GameObject player;

    public float perlinNoiseAmplitude = 1;
    public float perlinNoiseSmoothness = 1;

    // Start is called before the first frame update

    void Start()
    {
        //perlinNoiseSmoothness = 10 : calculatedSmoothness=0.1
        //perlinNoiseSmoothness = 100 : calculatedSmoothness=0.01
        //perlinNoiseSmoothness = 1000 : calculatedSmoothness=0.001
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
        SurfaceConfig surfaceConfiguration = GeneratorConfig.getInstance().surfaceConfiguration;
        int random = Random.Range(0, 100);
        if (random <= 5)
            TilesHelper.CreateBlock(new Vector2(position.x, position.y + 1), TilesHelper.getRandomSprite(surfaceConfiguration.flowersSprite), surfaceConfiguration.foliageBackgroundLayerPosition);
        if (random > 5)
            TilesHelper.CreateBlock(new Vector2(position.x, position.y + 1), TilesHelper.getRandomSprite(surfaceConfiguration.foliagesSprite), surfaceConfiguration.foliageBackgroundLayerPosition);

        if(Random.Range(0, 100) < 5)
            TreeGenerator.AddTree(new Vector2(position.x, position.y + 1));
        TilesHelper.CreateBlock(position, surfaceConfiguration.surfaceSprite);
        for (float i = position.y-1; i > yDirt; i--)
        {
            TilesHelper.CreateBlock(new Vector2(position.x, i), surfaceConfiguration.underGroundSprite);
        }
    }
}
