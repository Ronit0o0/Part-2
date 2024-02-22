using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static PlayerSelection playerSelected { get; private set; }
    public Slider chargeSlider;
    float charge;
    public float maxCharge = 1;
    Vector2 direction;
   
    public static void SetSelectedPlayer(PlayerSelection player)
    {
        if (playerSelected != null)
        {
            playerSelected.Selected(false);
        }
        playerSelected = player;
        playerSelected.Selected(true);
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            playerSelected.Move(direction);
            direction = Vector2.zero;
            charge = 0;
            chargeSlider.value = charge;
        }
    }
    private void Update()
    {
        if (playerSelected == null) return;

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            charge = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            charge = Mathf.Clamp(charge, 0, maxCharge);
            chargeSlider .value = charge;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)playerSelected.transform.position).normalized * charge;
        }
    }
}
