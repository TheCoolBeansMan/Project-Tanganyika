using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    public OverlayTile activeTile;
    public GameObject actionMenu;
    public GameObject cursorStatus;

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
        cursorStatus.GetComponent<MouseController>().character = this.GetComponent<CharacterInfo>();
        cursorStatus.GetComponent<MouseController>().PositionCharacterOnTile(activeTile);
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
        
    }

    public void Move()
    {
        
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
}
