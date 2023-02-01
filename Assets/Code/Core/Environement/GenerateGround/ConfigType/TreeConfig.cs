using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TreeConfig
{
    public int backgroundLayerPosition;
    [Range(3, 10)]
    public int minHeight = 4;
    [Range(4, 11)]
    public int maxHeight = 6;

    public GameObject footTile;
    public GameObject logTile;
    public GameObject leavesTile; 
}
