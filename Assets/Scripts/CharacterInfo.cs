using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    public OverlayTile activeTile;
    public GameObject actionMenu;
    public GameObject healthBar;

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
        healthBar.GetComponent<Slider>().maxValue = unitMaxHP;
        unitCurrHP = unitMaxHP;
        activeMenu = false;
    }
    private void OnMouseDown()
    {
        Debug.Log("clicked");
        if (activeMenu == true)
        {
            actionMenu.SetActive(false);
            activeMenu = false;
        }
        if (activeMenu == false)
        {
            actionMenu.SetActive(true);
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

    public void HealAndRepair()
    {

    }
}
