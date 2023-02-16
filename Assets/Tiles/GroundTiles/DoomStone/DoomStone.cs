using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class DoomStone : Tiles
    {
        public void Awake()
        {
            sprite = Resources.Load<Sprite>("Tiles/Doomstone");
            Init();
        }

        public override void OnBreak()
        {
            // doomstone can't be broken
            return;
        }
    }
}