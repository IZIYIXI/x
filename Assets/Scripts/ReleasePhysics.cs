using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ReleasePhysics : XRGrabInteractable
{
    public GameObject fakeHandle = null;

    //private List<UnityEngine.XR.InputDevice> controllers;

    //private bool isGrabbed = false;

    protected override void Awake()
    {
        base.Awake();

        //controllers = new List<UnityEngine.XR.InputDevice>();

        //UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.GameController, controllers);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        bool shouldDrop = true;

        List<XRNodeState> nodeStates = new List<XRNodeState>();
        InputTracking.GetNodeStates(nodeStates);

        foreach (XRNodeState state in nodeStates)
        {
            Vector3 pos = Vector3.zero;
            if (state.nodeType is XRNode.GameController)
            {
                Debug.Log("GameController");
                if (state.TryGetPosition(out pos))
                {
                    Debug.Log("TryGetPosition");
                    if (Vector3.Distance(pos, fakeHandle.transform.position) < 0.1f)
                    {
                        Debug.Log("Grabbed!");
                        shouldDrop = false;
                    }
                }
            }
        }

        //foreach (UnityEngine.XR.InputDevice device in controllers)
        //{
        //    UnityEngine.XR.InputTracking.GetNodeStates()

        //    Debug.Log(Vector3.Distance(device.position, fakeHandle.transform.position).ToString());
        //    Debug.Log((Vector3.Distance(device.position, fakeHandle.transform.position) < 0.1f).ToString());
        //    if (Vector3.Distance(device.position, fakeHandle.transform.position) < 0.1f)
        //    {
        //        shouldDrop = false;
        //    }
        //}

        //Debug.Log(Vector3.Distance(transform.position, fakeHandle.transform.position).ToString());
        //Debug.Log((Vector3.Distance(transform.position, fakeHandle.transform.position) > 0.1f).ToString());
        //Debug.Log((isGrabbed && (Vector3.Distance(transform.position, fakeHandle.transform.position) > 0.51)).ToString());

        //if (isGrabbed && (Vector3.Distance(transform.position, fakeHandle.transform.position) > 0.1f))
        //if (Vector3.Distance(transform.position, fakeHandle.transform.position) > 0.1f)
        if (shouldDrop)
        {
            Drop();
        }
    }

    //protected override void Grab()
    //{
    //    base.Grab();

    //    isGrabbed = true;
    //}

    //protected override void Drop()
    //{
    //    base.Drop();

    //    transform.position = fakeHandle.transform.position;
    //    transform.rotation = fakeHandle.transform.rotation;
    //    transform.localScale = Vector3.one;

    //    isGrabbed = false;

    //    Debug.Log("!!! Handle dropped !!!");
    //}
}
