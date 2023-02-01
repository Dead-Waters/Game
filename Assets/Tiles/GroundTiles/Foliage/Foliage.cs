using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class Foliage : Tiles
    {
        public void Awake()
        {
            sprite = Resources.Load<Sprite>("Tiles/Foliages/Foliage" + Random.Range(1, 5).ToString());
            Init();
        }
    }
}
