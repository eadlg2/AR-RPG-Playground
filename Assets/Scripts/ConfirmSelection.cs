using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ConfirmSelection : MonoBehaviour
{
    [SerializeField] private GameObject targetParent;
    [SerializeField] private GameObject otherTargets;
    [SerializeField] private GameObject current;
    [SerializeField] private GameObject next;

    public void Confirm()
    {
        targetParent.SetActive(false);

        if (otherTargets != null)
        {
            otherTargets.SetActive(true);
        }

        current.SetActive(false);

        if (next != null)
        {
            next.SetActive(true);
        }
    }
}
