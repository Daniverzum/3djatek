using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Animator animator;
    CharacterController controller;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //transform.Translate(new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime);

        Vector3 dir = new Vector3(horizontal, 0, vertical);
        controller.SimpleMove(dir * speed);

        if(horizontal == 0 && vertical == 0)
        {
            animator.SetBool("Walk_b", false);
        } else
        {
            animator.SetBool("Walk_b", true);
            transform.forward = -dir;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        gm?.LoadNextLevel();
    }
}
