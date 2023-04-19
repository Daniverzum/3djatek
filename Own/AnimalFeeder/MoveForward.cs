using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position. z > 20)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -4)
        {
            //GameManager.GameOver();
            Time.timeScale = 0;
        }
    }
}
