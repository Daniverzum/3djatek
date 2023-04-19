using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    bool isGrounded = true;
    Animator animator;
    public GameObject gameManager;
    AudioSource audioSource;
    public AudioClip jumpsound;
    public ParticleSystem dirtEffect, crashEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= 2;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && animator.GetBool("Death_b") == false)
        {
            isGrounded = false;
            rb.AddForce(Vector3.up * 15, ForceMode.Impulse);
            animator.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jumpsound);
            dirtEffect.Stop();
        }
            
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            animator.SetBool("Death_b", true);
            gameManager.GetComponent<GameManager>().GameOver();
            GameObject.FindGameObjectWithTag("Obstacle").GetComponent<Move>().GameOver();
            dirtEffect.Stop();
            crashEffect.Play();
        }
        else isGrounded = true; if(animator.GetBool("Death_b") == false) dirtEffect.Play();
        
    }
}
