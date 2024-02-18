using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SendMessage("ToGameScene", SendMessageOptions.DontRequireReceiver);
    }
}
