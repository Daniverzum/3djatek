using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 15;
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
