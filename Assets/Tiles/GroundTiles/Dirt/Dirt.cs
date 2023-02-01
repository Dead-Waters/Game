using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class Dirt : Tiles
    {
        public void Awake()
        {
            sprite = Resources.Load<Sprite>("Tiles/Dirt");
            Init();
        }
    }
}