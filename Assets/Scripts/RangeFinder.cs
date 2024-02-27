using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RangeFinder
{
    public List<OverlayTile> GetTilesInRange(OverlayTile startingTile, int range)
    {
        var inRangeTiles = new List<OverlayTile>();
        int stepCount = 0;

        inRangeTiles.Add(startingTile);

        var tileForPreviousStep = new List<OverlayTile>();
        tileForPreviousStep.Add(startingTile);

        while (stepCount < range)
        {
            var surrondingTiles = new List<OverlayTile>();

            foreach (var item in tileForPreviousStep)
            {
                surrondingTiles.AddRange(MapManager.Instance.GetNeighborTiles(item));
            }

            inRangeTiles.AddRange(surrondingTiles);
            tileForPreviousStep = surrondingTiles.Distinct().ToList();
            stepCount++;
        }

        return inRangeTiles.Distinct().ToList();
    }
}
