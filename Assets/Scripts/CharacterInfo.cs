using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public OverlayTile activeTile;

    public float unitMaxHP;
    public float unitMaxAttack;
    public float unitMaxAccuracy;
    public float unitMaxEvasion;

    private float unitcurrHP;
    private float unitcurrAttack;
    private float unitcurrAccuracy;
    private float unitcurrEvasion;

    private void Start()
    {
        unitcurrHP = unitMaxHP;
        unitcurrAttack = unitMaxAttack;
        unitcurrAccuracy = unitMaxAccuracy;
        unitcurrEvasion = unitMaxEvasion;
    }
}
