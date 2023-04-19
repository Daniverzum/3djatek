using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject food;
    void Update()
    {
        if(Input.GetKey(KeyCode.D) && transform.position.x < 19)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -19)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(food, transform.position + new Vector3(0,2,0), food.transform.rotation);
        }
    }
}
