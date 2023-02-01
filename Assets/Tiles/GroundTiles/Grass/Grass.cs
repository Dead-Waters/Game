using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class Grass : Tiles
    {
        public void Awake()
        {
            sprite = Resources.Load<Sprite>("Tiles/Grass");
            Init();
        }
    }
}