using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pathfinder
{
    public List<OverlayTile> FindPath(OverlayTile startingNode, OverlayTile endNode)
    {
        List<OverlayTile> openList = new List<OverlayTile>();
        List<OverlayTile> closedList = new List<OverlayTile>();

        openList.Add(startingNode);

        while (openList.Count > 0)
        {
            OverlayTile currentOverlayTile = openList.OrderBy(x => x.F).First();

            openList.Remove(currentOverlayTile);
            closedList.Add(currentOverlayTile);

            if (currentOverlayTile == endNode)
            {
                return GetFinishedList(startingNode, endNode);
            }

            var neighborTiles = MapManager.Instance.GetNeighborTiles(currentOverlayTile);

            foreach(var neighbor in neighborTiles)
            {
                if (neighbor.isBlocked || closedList.Contains(neighbor))
                {
                    continue;
                }

                neighbor.G = GetManhattenDistance(startingNode, neighbor);
                neighbor.H = GetManhattenDistance(endNode, neighbor);

                neighbor.pervious = currentOverlayTile;

                if (!openList.Contains(neighbor))
                {
                    openList.Add(neighbor);
                }
            }
        }

        return new List<OverlayTile>();
    } 

    private List<OverlayTile> GetFinishedList(OverlayTile start, OverlayTile end)
    {
        List<OverlayTile> finishedList = new List<OverlayTile>();

        OverlayTile currentTile = end;

        while (currentTile != start)
        {
            finishedList.Add(currentTile);
            currentTile = currentTile.pervious;
        }

        finishedList.Reverse();

        return finishedList;
    }

    private int GetManhattenDistance(OverlayTile start, OverlayTile neighbor)
    {
        return Mathf.Abs(start.gridLocation.x - neighbor.gridLocation.x) + Mathf.Abs(start.gridLocation.y - neighbor.gridLocation.y);
    }
}
