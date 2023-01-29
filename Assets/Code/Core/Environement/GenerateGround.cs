using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGround : MonoBehaviour
{
    public int numberOfTiles = 100;
    public Sprite surfaceSprite;
    public Sprite underGroundSprite;
    public Vector2 origin = Vector2.zero;
    public int yDirt = 0;

    public float perlinNoiseAmplitude = 1;
    public float perlinNoiseSmoothness = 1;

    // Start is called before the first frame update

    void Start()
    {
        //perlinNoiseSmoothness = 10 : calculatedSmoothness=0.1
        //perlinNoiseSmoothness = 100 : calculatedSmoothness=0.01
        //perlinNoiseSmoothness = 1000 : calculatedSmoothness=0.001
        float calculatedSmoothness = 1 / perlinNoiseSmoothness;
        Vector2 calculatedOrigin = new Vector2(origin.x - numberOfTiles / 2, origin.y);

        for (int i = 0; i < numberOfTiles; i++)
        {
            float x = calculatedOrigin.x + i;
            float y = Mathf.PerlinNoise(x* calculatedSmoothness, 0) * perlinNoiseAmplitude;
            CreateLine(new Vector2(Mathf.Round(x), Mathf.Round(y)));
        } 
    }

    void CreateLine(Vector2 position)
    {
        CreateBlock(position, surfaceSprite);
            
        for (float i = position.y-1; i > yDirt; i--)
        {
            CreateBlock(new Vector2(position.x, i),underGroundSprite);
        }
    }



    void CreateBlock(Vector2 position, Sprite sprite)
    {
        GameObject tileObject = new GameObject("Tile");
        tileObject.AddComponent<SpriteRenderer>();
        Tiles tile = tileObject.AddComponent<Tiles>();
        tile.sprite = sprite;
        tile.position = position;
        tile.size = new Vector2(1, 1);
        tile.onFirstLayer = true;
        tile.Init();
    }
}
