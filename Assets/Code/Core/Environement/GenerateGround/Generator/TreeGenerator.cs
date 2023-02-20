using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiles;

public static class TreeGenerator
{
    public static void AddTree(Vector2 position)
    {
        TreeConfig treeConfigurations = GeneratorConfig.getInstance().treeConfiguration;
        int height = Random.Range(treeConfigurations.minHeight, treeConfigurations.maxHeight+1);

        TilesHelper.CreateBlock(position, treeConfigurations.footTile, treeConfigurations.backgroundLayerPosition);
        for (float i = position.y + 1; i < position.y + height; i++)
            TilesHelper.CreateBlock(new Vector2(position.x, i), treeConfigurations.logTile, treeConfigurations.backgroundLayerPosition);

        // nine leaves 3x3
        for (float i = position.y + height - 2; i < position.y + height + 1; i++)
            for (float j = position.x - 1; j < position.x + 2; j++)
                CreateLeave(new Vector2(j, i));


    }

    public static void CreateLeave(Vector2 centerLeave)
    {                                     
        TreeConfig treeConfigurations = GeneratorConfig.getInstance().treeConfiguration;
        Vector2 position = new Vector2(Random.Range(0, 100), Random.Range(0, 100));
        TilesHelper.CreateBlock(centerLeave, treeConfigurations.leavesTile, treeConfigurations.backgroundLayerPosition - 0.1f);
                                               
        if (Random.Range(0, 20) == 0)
            TilesHelper.CreateBlock(centerLeave, treeConfigurations.appleTile, treeConfigurations.backgroundLayerPosition - 0.2f);

    }
}
