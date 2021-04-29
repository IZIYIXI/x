using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class HandleLever : MonoBehaviour
{
    public RaillsRotation raillsRotation;

    private float rotMin;
    private float rotMax;

    void Start()
    {
        HingeJoint jnt = GetComponent<HingeJoint>();
        rotMin = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x + jnt.limits.min;
        rotMax = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x + jnt.limits.max;

        //Debug.Log("UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x " + UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x.ToString());
        //Debug.Log("jnt.limits.min " + jnt.limits.min.ToString());
        //Debug.Log("jnt.limits.max " + jnt.limits.max.ToString());
        //Debug.Log("rotMin " + rotMin.ToString());
        //Debug.Log("rotMax " + rotMax.ToString());
    }

    //public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    //{
    //    float rotCur = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x;

    //    //Debug.Log(rotCur.ToString());

    //    if (rotCur < rotMin + 10f)
    //    {
    //        raillsRotation.railsTurn = true;
    //        //Debug.Log("!!! Rails left !!!");
    //    }

    //    if (rotCur > rotMax - 10f)
    //    {
    //        raillsRotation.railsTurn = false;
    //        //Debug.Log("!!! Rails right !!!");
    //    }
    //}

    void Update()
    {
        float rotCur = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x;

        //Debug.Log(rotCur.ToString());

        if (rotCur < rotMin + 10f)
        {
            raillsRotation.railsTurn = true;
            //Debug.Log("!!! Rails left !!!");
        }

        if (rotCur > rotMax - 10f)
        {
            raillsRotation.railsTurn = false;
            //Debug.Log("!!! Rails right !!!");
        }
    }
}
