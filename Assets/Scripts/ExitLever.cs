using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
        }

        if (rotCur > rotMax - 10f)
        {
            
        }
    }
}
