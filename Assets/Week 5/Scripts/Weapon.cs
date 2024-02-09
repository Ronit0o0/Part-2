using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    Vector2 direction = new Vector2(3, 0);
    public Rigidbody2D rb;
    Animator animator;
    public float health;
    public float maxHealth = 5;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,Random.Range(5,10));
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * Time.deltaTime);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }  
}
