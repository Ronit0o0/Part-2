using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Vector2 desitination;
    Vector2 movement;
    public float speed = 3f;
    Rigidbody2D rb;
    Animator animator;
    bool clickingOnself = false;
    public float health;
    public float maxHealth = 5;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    private void FixedUpdate()
    {
        movement = desitination - (Vector2)transform.position;

        if(movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !clickingOnself)
        {
            desitination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);
    }
    private void OnMouseDown()
    {
        clickingOnself = true;
        animator.SetTrigger("takeDamage"); 

    }

    private void OnMouseUp()
    {
        clickingOnself = false;
        SendMessage("TakeDamage", 1);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if(health == 0)
        {
            //die?
            animator.SetTrigger("death");
        }
        else
        {
            animator.SetTrigger("takeDamage");
        }
        
    }
}
