﻿using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    //public TranlationMover tranlationMover;
    //public RaillsRotation raillsRotation; //в самом Unity перетащил скрипт к которому (смотри в свойствах этого скрипта у направляющих рельсов)

    public Material selectMaterial = null;

    private Material originalMaterial = null;
    private MeshRenderer meshRenderer = null;
    private XRBaseInteractable interactable = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.onHoverEntered.AddListener(SetSelectMaterial);
        interactable.onHoverExited.AddListener(SetOriginalMaterial);
    }

    private void OnDestroy()
    {
        interactable.onHoverEntered.RemoveListener(SetSelectMaterial);
        interactable.onHoverExited.RemoveListener(SetOriginalMaterial);
    }

    private void SetSelectMaterial(XRBaseInteractor interactor)
    {
        meshRenderer.material = selectMaterial;
        //if (raillsRotation.railsTurn == false)
        //{
        //    raillsRotation.railsTurn = true;
        //}
        //else if (raillsRotation.railsTurn == true)
        //{
        //    raillsRotation.railsTurn = false;
        //}
    }

    private void SetOriginalMaterial(XRBaseInteractor interactor)
    {
        meshRenderer.material = originalMaterial;
    }
}
