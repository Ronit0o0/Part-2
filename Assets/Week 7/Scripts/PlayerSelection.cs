using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerSelection : MonoBehaviour
{
    bool playerSelected;
    SpriteRenderer spriteRenderer;
    public Color myColor;
    Rigidbody2D rb;
    public float speed = 1000;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer.color = myColor;
        Selected(false);
    }
    public  void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }

        public void Selected(bool playerSelected)
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
        public void Move(Vector2 direction)
        {
            rb.AddForce(direction * speed);
        }
    }

