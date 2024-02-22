using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    bool playerSelected = false;
    SpriteRenderer spriteRenderer;
    public Color myColor;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = myColor;
    }

    public void Update()
    {
        if (playerSelected)
        {
            spriteRenderer.color = Color.green;
        }
        else if (!playerSelected)
        {
            spriteRenderer.color = myColor;
        }
    }

    private void OnMouseDown()
    {
        playerSelected = true;
    }

    private void OnMouseUp()
    {
        playerSelected = false; 
    }
}
