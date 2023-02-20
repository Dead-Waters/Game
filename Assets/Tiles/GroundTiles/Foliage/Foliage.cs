using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class Foliage : Tiles
    {
        public void Awake()
        {
            this.sprite = Resources.Load<Sprite>("Tiles/Foliages/Foliage" + Random.Range(1, 5).ToString());
            this.canPlaceOn = false;
            Init();
        }

        public override void OnRefresh()
        {
            if (!TilesHelper.IsPlacableHere(position))
                Destroy(this.gameObject);
            Debug.Log("Foliage refreshed");
        }
    }
}
