using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class Log : Tiles
    {
        public void Awake()
        {
            sprite = Resources.Load<Sprite>("Tiles/Log");
        }
    }
}