using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLever : MonoBehaviour
{
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
        Vector3 rotCur = gameObject.transform.localEulerAngles;
        if (rotCur.y > 260f)
        {
            SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
        }

        if ((rotCur.x < 271f) && (!GetComponent<AudioSource>().isPlaying))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
