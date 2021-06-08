using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetXRRig : MonoBehaviour
{
    private Quaternion currRotationOffset;

    void Start()
    {
        Quaternion rotationOffset = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.Head);
        rotationOffset.x = 0.0f;
        rotationOffset.z = 0.0f;
        currRotationOffset = Quaternion.Inverse(rotationOffset);
        transform.rotation *= currRotationOffset;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
