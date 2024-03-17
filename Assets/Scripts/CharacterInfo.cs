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
    public GameObject selectorIcon;
    public bool selected;
    public GameObject dmgIcon;
    public Text dmgText;
    private MouseController movementStatus;
    private RangeFinder attackRange;
    private List<OverlayTile> inRangeAttacks = new List<OverlayTile>();
    private Vector3Int unitPosition;
    private int xPos;
    private int yPos;
    private int zPos;

    public GameObject raycastOrigin;
    public bool highlighted;

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
        unitPosition = new Vector3Int(-1, -1, 0);
        selectorIcon.SetActive(false);
        selected = false;

    }

    private void Update()
    {
        //xPos = (int) transform.position.x;
        //yPos = (int) transform.position.y;
        //zPos = (int) transform.position.z;

        //unitPosition = new Vector3Int(xPos, yPos, zPos);
        //currentTile = battleMap.GetTile(unitPosition);
        
    }
    private void OnMouseDown()
    {
        Debug.Log("clicked");
        if (activeMenu == true)
        {
            actionMenu.gameObject.SetActive(false);
            activeMenu = false;
            selected = false;
        }
        else if (activeMenu == false)
        {
            actionMenu.gameObject.SetActive(true);
            activeMenu = true;
            selected = true;
        }

        if (selected)
        {
            selectorIcon.SetActive(true);
        }

        else
        {
            selectorIcon.SetActive(true);
        }
    }

    public void SelectUnit(Vector3Int tilePosition)
    {
        unitPosition = tilePosition;
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
        if (raycastOrigin != null)
        {
            float raycastLength = 10f;
            Vector2 originPosition = raycastOrigin.transform.position;
            unitLayerMask = LayerMask.GetMask("Units");

            // Raycast upwards from one tile above the raycast origin, detect objects with "GermUnit" tag
            RaycastHit2D hitUp = Physics2D.Raycast(originPosition + Vector2.up, Vector2.up, raycastLength, unitLayerMask);
            Debug.DrawRay(originPosition + Vector2.up, Vector2.up * raycastLength, Color.red, 1f); // Draw the ray for visualization

            // Raycast downwards from one tile below the raycast origin, detect objects with "BritUnit" tag
            RaycastHit2D hitDown = Physics2D.Raycast(originPosition - Vector2.up, Vector2.down, raycastLength, unitLayerMask);
            Debug.DrawRay(originPosition - Vector2.up, Vector2.down * raycastLength, Color.blue, 1f); // Draw the ray for visualization


            if (hitUp.collider != null)
            {
                Debug.Log("Hit something above at position: " + hitUp.point);
                Debug.Log("Collider tag: " + hitUp.collider.tag);

                if (hitUp.collider.CompareTag("GermUnit"))
                {
                    CharacterInfo germUnitInfo = hitUp.collider.GetComponent<CharacterInfo>();
                    germUnitInfo.unitCurrHP -= unitAttack;
                    dmgIcon.SetActive(true);
                    dmgText.gameObject.SetActive(true);
                    dmgText.text = unitAttack + "\n DAMAGE";
                    Invoke("DeactivateDMG", 2f);

                    if (germUnitInfo.unitCurrHP <= 0)
                    {
                        Destroy(hitUp.collider.gameObject);
                    }
                }

            }

            if (hitDown.collider != null)
            {
                Debug.Log("Hit something below at position: " + hitDown.point);
                Debug.Log("Collider tag: " + hitDown.collider.tag);

                if (hitDown.collider.CompareTag("BritUnit"))
                {
                    CharacterInfo britUnitInfo = hitDown.collider.GetComponent<CharacterInfo>();
                    britUnitInfo.unitCurrHP -= unitAttack;
                    dmgIcon.SetActive(true);
                    dmgText.gameObject.SetActive(true);
                    dmgText.text = unitAttack + "\n DAMAGE";
                    Invoke("DeactivateDMG", 2f);

                    if (britUnitInfo.unitCurrHP <= 0)
                    {
                        Destroy(hitDown.collider.gameObject);
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Raycast origin is not assigned!");
        }

    }

    void DeactivateDMG()
    {
        dmgIcon.SetActive(false);
        dmgText.gameObject.SetActive(false);
    }

    private Vector3Int[] GetAllTilesInColumn(int column)
    {
        // Get the bounds of the tilemap
        BoundsInt bounds = battleMap.cellBounds;

        // Create a list to store the tile positions in the column
        List<Vector3Int> tilesInColumn = new List<Vector3Int>();

        // Iterate through all rows in the column
        for (int y = bounds.yMin; y < bounds.yMax; y++)
        {
            Vector3Int tilePos = new Vector3Int(column, y, 0);

            // Add the tile position to the list
            tilesInColumn.Add(tilePos);
        }

        // Convert the list to an array and return it
        return tilesInColumn.ToArray();
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
