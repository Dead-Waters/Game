using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TreeGenerator
{
    public static void AddTree(Vector2 position)
    {
        TreeConfig treeConfigurations = GeneratorConfig.getInstance().treeConfiguration;
        TilesHelper.CreateBlock(position, treeConfigurations.treeBaseSprite, treeConfigurations.backgroundLayerPosition);
        for (float i = position.y; i < position.y + 4; i++)
        {
            TilesHelper.CreateBlock(new Vector2(position.x, i), treeConfigurations.treeLogSprite, treeConfigurations.backgroundLayerPosition);
        }
        // nine leaves 3x3

        for (float i = position.x - 1; i < position.x + 2; i++)
            for (float j = position.y + 2; j < position.y + 5; j++)
                TilesHelper.CreateBlock(new Vector2(i, j), treeConfigurations.treeLeavesSprite, treeConfigurations.backgroundLayerPosition -0.01f);
    }
}
