using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesConfig : MonoBehaviour
{
    public int breakDistance = 5;

    private static TilesConfig instance;
    private TilesConfig() { }

    public static TilesConfig getInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)   // disable duplicate instance
            Destroy(this.gameObject);
        else
            instance = this;
    }
}
