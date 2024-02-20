
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public AnimationCurve curve;
    public Transform targetPos;
    public float speed = 1.0f;
    

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos.position, speed * Time.deltaTime);
    }

   
}



