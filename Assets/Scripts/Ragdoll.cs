using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public Animator Animator;
    public Rigidbody[] Allrigidbodies;

    private void Awake()
    {
        for (int i = 0; i < Allrigidbodies.Length; i++)
        {
            Allrigidbodies[i].isKinematic = true;
        }
        //MakePhysical();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    MakePhysical();
        //}
    }

    public void MakePhysical()
    {
        Animator.enabled = false;
        for (int i = 0; i < Allrigidbodies.Length; i++)
        {
            Allrigidbodies[i].isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("other.tag " + other.tag);
        Debug.Log("other.transform.parent.tag " + other.transform.parent.tag);
        Debug.Log("other.transform.parent.gameObject.tag " + other.transform.parent.gameObject.tag);
        if (other.transform.parent.gameObject.tag == "Trolley")
        {
            MakePhysical();
        }
    }
}
