using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    [SerializeField] private Color baseColor;
    [SerializeField] private Color offsetColor;

    [SerializeField] private SpriteRenderer render;

    [SerializeField] private GameObject highlight;

    public void Init(bool isOffset)
    {
        render.color = isOffset ? offsetColor : baseColor; 
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
