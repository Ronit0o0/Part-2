using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;

    private void Start()
    {
        
    }


    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.name == "Temporary enemy")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
    
  

