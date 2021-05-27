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
    }

    public void MakePhysical()
    {
        if ((Animator != null) && (Allrigidbodies != null))
        {
            Animator.enabled = false;
            for (int i = 0; i < Allrigidbodies.Length; i++)
            {
                Allrigidbodies[i].isKinematic = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("other.tag " + other.tag);
        //Debug.Log("other.transform.parent.tag " + other.transform.parent.tag);
        //Debug.Log("other.transform.parent.gameObject.tag " + other.transform.parent.gameObject.tag);
        if (other.tag == "Trolley")
        {
            MakePhysical();
        }
    }
}
