using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPhysics : MonoBehaviour
{
    public Transform target;
    //private Rigidbody rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        //rb.MovePosition(target.transform.position);
        //rb.position = target.transform.position;
        transform.position = target.transform.position;
    }
}
