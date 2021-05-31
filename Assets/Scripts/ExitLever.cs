using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLever : MonoBehaviour
{
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
            Application.LoadLevel("Main_Menu");
        }

        if (rotCur > rotMax - 10f)
        {
            
        }
    }
}
