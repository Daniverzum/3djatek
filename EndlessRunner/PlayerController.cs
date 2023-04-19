using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    bool isGrounded = true;
    Animator animator;
    public GameObject gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= 3f;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && animator.GetBool("Death_b") == false)
        {
            rb.AddForce(Vector3.up * 15, ForceMode.Impulse);
            isGrounded = false;
            animator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("utkozes");
            animator.SetBool("Death_b", true);
            gameManager.GetComponent<GameManager>().GameOver();
        }
        else
        {
            isGrounded = true;
        }
    }
}
