using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public float Speed = 5;
    Animator animator;
    Rigidbody2D rb;

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
        
    }


    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePos, Speed * Time.deltaTime);

    }
    
       
    }


    
  

