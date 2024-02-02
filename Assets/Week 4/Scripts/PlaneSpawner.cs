using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{

    public GameObject plane;
    public GameObject[] arrayofPlanes;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(1, 5);
        //arrayofPlanes = new GameObject[5];
       //for (int i = 0; i < arrayofPlanes; i++);             
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Vector3 randomSpawnPoint = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            Quaternion randomPlaneRotation = Quaternion.Euler (0,0,Random.Range(0,360));
            Instantiate(plane, randomSpawnPoint, randomPlaneRotation);
            timer = Random.Range(1, 5 * Time.deltaTime);
        }
    }
}
