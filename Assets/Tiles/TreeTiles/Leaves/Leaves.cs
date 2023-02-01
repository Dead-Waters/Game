using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class Leaves : Tiles
    {
        public void Awake()
        {
            sprite = Resources.Load<Sprite>("Tiles/Leaves");
        }
    }
}
