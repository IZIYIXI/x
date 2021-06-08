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
        //rotMin = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x + jnt.limits.min;
        rotMin = gameObject.transform.localRotation.eulerAngles.x + jnt.limits.min;
        //rotMax = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x + jnt.limits.max;
        rotMax = gameObject.transform.localRotation.eulerAngles.x + jnt.limits.max;
    }

    void Update()
    {
        //float rotCur = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x;
        Vector3 rotCur = gameObject.transform.localEulerAngles;
        Debug.Log(rotCur.x + " | " + rotCur.y + " | " + rotCur.z);
        //Debug.Log("--------");
        //Debug.Log(gameObject.transform.eulerAngles.x + " | " + gameObject.transform.eulerAngles.y + " | " + gameObject.transform.eulerAngles.z);
        //Debug.Log(gameObject.transform.localEulerAngles.x + " | " + gameObject.transform.localEulerAngles.y + " | " + gameObject.transform.localEulerAngles.z);
        //Debug.Log("--------");

        //if (rotCur < rotMin + 10f)
        if (rotCur.y < 100f)
        {
            raillsRotation.railsTurn = false;
        }

        if (rotCur.y > 260f)
        {
            raillsRotation.railsTurn = true;
        }

        if ((rotCur.x < 271f) && (!GetComponent<AudioSource>().isPlaying))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
