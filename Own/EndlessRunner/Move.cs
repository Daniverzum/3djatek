using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int points = 0;
    bool incoming = true;
    int speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < 0 && incoming)
        {
            incoming = false;
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PointGotten();
        }
        if (transform.position.x < -5)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        speed = 0;
    }
}
