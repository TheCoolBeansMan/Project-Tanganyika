using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    public OverlayTile activeTile;
    public Tilemap battleMap;
    public Tile currentTile;
    public GameObject actionMenu;
    public LayerMask unitLayerMask;
    public string unitTag;
    private MouseController movementStatus;
    private RangeFinder attackRange;
    private List<OverlayTile> inRangeAttacks = new List<OverlayTile>();
    private Vector3Int unitPosition;
    private int xPos;
    private int yPos;
    private int zPos;

    public GameObject raycastOrigin;

    public int unitMaxHP;
    public int unitCurrHP;

    public int unitAttack;
    public int unitAccuracy;
    public int unitEvasion;
    public int unitSpeed;
    public int unitDefense;

    private bool activeMenu;

    public void Start()
    {
        actionMenu.GetComponentInChildren<Slider>().maxValue = unitMaxHP;
        unitCurrHP = unitMaxHP;
        activeMenu = false;
        movementStatus = new MouseController();
        attackRange = new RangeFinder();
        movementStatus.GetComponent<MouseController>().character = this.GetComponent<CharacterInfo>();
        movementStatus.GetComponent<MouseController>().PositionCharacterOnTile(activeTile);
    }

    private void Update()
    {
        xPos = (int) transform.position.x;
        yPos = (int) transform.position.y;
        zPos = (int) transform.position.z;

        unitPosition = new Vector3Int(xPos, yPos, zPos);
        //currentTile = battleMap.GetTile(unitPosition);
    }
    private void OnMouseDown()
    {
        Debug.Log("clicked");
        if (activeMenu == true)
        {
            actionMenu.gameObject.SetActive(false);
            activeMenu = false;
        }
        else if (activeMenu == false)
        {
            actionMenu.gameObject.SetActive(true);
            activeMenu = true;
        }
    }

    public void Attack()
    {
        inRangeAttacks = attackRange.GetTilesInRange(activeTile, 1);

        foreach (var item in inRangeAttacks)
        {
            item.ShowTile();
        }

        if (Input.GetMouseButtonDown(0))
        {

        }

    }

    public void UnitAttack()
    {

        //// Check if the raycast origin is assigned
        //if (raycastOrigin != null)
        //{
        float raycastLength = 10f;
        Vector2 originPosition = raycastOrigin.transform.position;

        //    // Raycast upwards from one tile above the raycast origin, detect objects with "GermUnit" tag
        //    RaycastHit2D hitUp = Physics2D.Raycast(originPosition + Vector2.up, Vector2.up, raycastLength);
        //    Debug.DrawRay(originPosition + Vector2.up, Vector2.up * raycastLength, Color.red, 1f); // Draw the ray for visualization

        //    // Raycast downwards from one tile below the raycast origin, detect objects with "BritUnit" tag
        //    RaycastHit2D hitDown = Physics2D.Raycast(originPosition - Vector2.up, Vector2.down, raycastLength);
        //    Debug.DrawRay(originPosition - Vector2.up, Vector2.down * raycastLength, Color.blue, 1f); // Draw the ray for visualization

        //    // Handle hit results if needed
        //    if (hitUp.collider != null && hitUp.collider.tag == "GermUnit")
        //    {
        //        Debug.Log("Hit something above with GermUnit tag!");
        //        // You can perform actions when hitting something above with GermUnit tag
        //    }

        //    if (hitDown.collider != null && hitDown.collider.tag == "BritUnit")
        //    {
        //        Debug.Log("Hit something below with BritUnit tag!");
        //        // You can perform actions when hitting something below with BritUnit tag
        //    }
        //}
        //else
        //{
        //    Debug.LogError("Raycast origin is not assigned!");
        //}

        if (raycastOrigin != null)
        {
            // Perform a raycast upwards
            RaycastHit2D hitUp = Physics2D.Raycast(originPosition + Vector2.up, Vector2.up, raycastLength);
            if (hitUp.collider != null && hitUp.collider.CompareTag(unitTag))
            {
                Debug.Log("Detected object with tag " + unitTag + " above.");
            }

            // Perform a raycast downwards
            RaycastHit2D hitDown = Physics2D.Raycast(originPosition - Vector2.up, Vector2.down, raycastLength);
            if (hitDown.collider != null && hitDown.collider.CompareTag(unitTag))
            {
                Debug.Log("Detected object with tag " + unitTag + " below.");
            }
        }
        else
        {
            Debug.LogError("Raycast origin is not assigned!");
        }

    }


    public void Move()
    {
        movementStatus.canMove = true;
    }

    public void Board()
    {

    }

    public void Aim()
    {

    }

    public void HealAndRepair()
    {

    }

    public void Deactivate()
    {
        this.enabled = false;
    }
}
