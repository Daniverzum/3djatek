using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanMove : MonoBehaviour
{
    public float speed = 40f;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 10){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }
}
