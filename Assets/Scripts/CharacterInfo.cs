using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    public OverlayTile activeTile;
    public GameObject actionMenu;
    private MouseController movementStatus;
    private RangeFinder attackRange;
    private List<OverlayTile> inRangeAttacks = new List<OverlayTile>();

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
