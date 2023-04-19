using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public int maxCoins;
    int counter = 0;
    private void Start()
    {
        maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space)) {
            speed *= 5;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            speed /= 5;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("utkozes");
        //Destroy(other.gameObject);
        other.gameObject.SetActive(false);
        counter++;
        if(counter == maxCoins)
        {
            Debug.Log("nyertel");
            GetComponent<PlayerController>().enabled = false;

        }
    }

}
