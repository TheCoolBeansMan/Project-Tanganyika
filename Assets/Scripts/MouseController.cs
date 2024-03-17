using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MouseController : MonoBehaviour
{
    public CharacterInfo character;
    public float speed;

    public bool canMove;


    private Pathfinder pathFinder;
    private RangeFinder rangeFinder;
    private List<OverlayTile> path = new List<OverlayTile>();
    private List<OverlayTile> inRangeTiles = new List<OverlayTile>();

    private void Start()
    {
        canMove = false;
        pathFinder = new Pathfinder();
        rangeFinder = new RangeFinder();
    }

    private void LateUpdate()
    {
        var focusedTileHit = GetFocusedOnTile();

        if (focusedTileHit.HasValue)
        {
            OverlayTile overlayTile = focusedTileHit.Value.collider.gameObject.GetComponent<OverlayTile>();
            transform.position = overlayTile.transform.position;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;

            GetInRangeTiles();
            if (Input.GetMouseButtonDown(0))
            {
                path = pathFinder.FindPath(character.activeTile, overlayTile, inRangeTiles);
            }
            
            /*if (canMove == true)
            {
                GetInRangeTiles();
                if (Input.GetMouseButtonDown(0))
                {
                    path = pathFinder.FindPath(character.activeTile, overlayTile, inRangeTiles);
                }

                //if (character == null)
                //{
                //    character = Instantiate(characterPrefab).GetComponent<CharacterInfo>();
                //    //PositionCharacterOnTile(overlayTile);
                //}
                //else
                //{
                //    path = pathFinder.FindPath(character.activeTile, overlayTile, inRangeTiles);
                //}
            }*/
        }

        if (path.Count > 0)
        {
            MoveAlongPath();
            //canMove = false;
            TurnOffTiles();
        }
    }

    private void GetInRangeTiles()
    {
        foreach (var item in inRangeTiles)
        {
            item.HideTile();
        }

        inRangeTiles = rangeFinder.GetTilesInRange(character.activeTile, character.unitSpeed);

        foreach (var item in inRangeTiles)
        {
            item.ShowTile();
        }
    }

    private void TurnOffTiles()
    {
        foreach (var item in inRangeTiles)
        {
            item.HideTile();
        }
    }

    private void MoveAlongPath()
    {
        var step = speed * Time.deltaTime;

        var zIndex = path[0].transform.position.z;
        character.transform.position = Vector2.MoveTowards(character.transform.position, path[0].transform.position, step);
        character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, zIndex);

        if (Vector2.Distance(character.transform.position, path[0].transform.position) < 0.0001f)
        {
            PositionCharacterOnTile(path[0]);
            path.RemoveAt(0);
        }

        if (path.Count == 0)
        {
            GetInRangeTiles();
        }
    }

    public RaycastHit2D? GetFocusedOnTile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

        if (hits.Length > 0)
        {
            return hits.OrderByDescending(i => i.collider.transform.position.z).First();
        }
        return null;
    }

    public void PositionCharacterOnTile(OverlayTile tile)
    {
        character.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y + 0.0001f, tile.transform.position.z);
        character.GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
        character.activeTile = tile;
    }
}
