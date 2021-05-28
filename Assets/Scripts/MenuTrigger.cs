using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTrigger : MonoBehaviour
{
    public GameObject leftHandController;
    public GameObject rightHandController;
    public GameObject menu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trolley")
        {
            menu.SetActive(true);
            //leftHandController.GetComponent(XRInteractorLineVisual).SetActive(true);
            //rightHandController.GetComponent(XRInteractorLineVisual).SetActive(true);
        }
    }
}
