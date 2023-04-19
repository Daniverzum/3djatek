using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    public int maxCoins;
    public int coins = 0;

    void Start() {
        maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    void Update() {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.up, horizontalInput * speed * 3 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)) {
            speed *= 5;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            speed /= 5;
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Collision");
        //Destroy(other.gameObject);
        other.gameObject.SetActive(false);
        coins++;
        if (coins == maxCoins) {
            Debug.Log("You win!");
            //speed = 0;
            GetComponent<PlayerController>().enabled = false;
        }
    }
}
