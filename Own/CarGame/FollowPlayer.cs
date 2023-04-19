using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject camera2;
    Vector3 offset;
    Vector3 offset2;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        offset2 = camera2.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.V) == false) {
            transform.position = player.transform.position + offset;
            //transform.rotation = (20, 0, 0);
        }
        if (Input.GetKey(KeyCode.V)) {
            transform.position = player.transform.position + offset2;
            //transform.rotation = (20, -180, 0);
        }
    }
}
