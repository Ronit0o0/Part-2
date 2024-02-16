using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

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
    bool isDead = false;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        health = PlayerPrefs.GetFloat("healthBar",maxHealth);    
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        movement = desitination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        if (Input.GetMouseButtonDown(0) && !clickingOnself && !EventSystem.current.IsPointerOverGameObject())
        {
            desitination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }
    }
    private void OnMouseDown()
    {
        if (isDead) return;
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
        if (health == 0)
        {
            isDead = true;
            animator.SetTrigger("death");
        }
        else
        {
            isDead = false;
            animator.SetTrigger("takeDamage");
        }
        SetHealth();

    }

    void SetHealth()
    {
        PlayerPrefs.SetFloat("healthBar", health);
    }
}

