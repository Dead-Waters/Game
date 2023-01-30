using System;
using UnityEngine;

// use singleton pattern to keep no-static attributes and let the value be accessible from editor
public class GeneratorConfig : MonoBehaviour
{
    public SurfaceConfig surfaceConfiguration;
    public TreeConfig treeConfiguration;
    
    private static GeneratorConfig instance;
    private GeneratorConfig() { }

    public static GeneratorConfig getInstance()
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
