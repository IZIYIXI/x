using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class HandleLever : MonoBehaviour
{
    public RaillsRotation raillsRotation;
    public bool isForRails;

    private float rotMin;
    private float rotMax;

    void Start()
    {
        HingeJoint jnt = GetComponent<HingeJoint>();
        rotMin = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x + jnt.limits.min;
        rotMax = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x + jnt.limits.max;
    }

    void Update()
    {
        float rotCur = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x;

        if (rotCur < rotMin + 10f)
        {
            GetComponent<AudioSource>().Play(0);

            if (isForRails)
            {
                raillsRotation.railsTurn = true;
            }
        }

        if (rotCur > rotMax - 10f)
        {
            GetComponent<AudioSource>().Play(0);

            if (isForRails)
            {
                raillsRotation.railsTurn = false;
            }
        }
    }
}
