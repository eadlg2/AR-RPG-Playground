using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ConfirmSelection : MonoBehaviour
{
    [SerializeField] private GameObject targetParent;
    [SerializeField] private GameObject otherTargets;
    [SerializeField] private GameObject current;
    [SerializeField] private GameObject final;

    public void Confirm()
    {
        targetParent.SetActive(false);
        otherTargets.SetActive(true);
        current.SetActive(false);
        final.SetActive(true);
    }
}
