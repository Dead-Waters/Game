using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class Apple : Tiles
    {
        public void Awake()
        {
            sprite = Resources.Load<Sprite>("Tiles/Organic/Apple");
            Init();
        }
    }
}
