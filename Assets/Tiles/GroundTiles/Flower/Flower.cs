using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class Flower : Tiles
    {
        public void Awake()
        {
            this.sprite = Resources.Load<Sprite>("Tiles/Flowers/Flower" + Random.Range(1, 7).ToString());
            this.canPlaceOn = false;
            Init();
        }

        public override void OnRefresh()
        {
            if (!TilesHelper.IsPlacableHere(position))
                Destroy(this.gameObject);
            Debug.Log("Flower refreshed");
        }

    }
}





        