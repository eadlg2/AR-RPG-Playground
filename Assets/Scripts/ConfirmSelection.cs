using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ConfirmSelection : MonoBehaviour
{
    [SerializeField] private GameObject targetParent;
    [SerializeField] private Player player;
    [SerializeField] private GameObject otherTargets;
    [SerializeField] private GameObject current;
    [SerializeField] private GameObject final;

    public void Confirm()
    {
        ImageTargetBehaviour[] targets = targetParent.GetComponentsInChildren<ImageTargetBehaviour>();

        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].transform != player.transform.parent)
            {
                targets[i].enabled = false;
            }
        }

        otherTargets.SetActive(true);
        current.SetActive(false);
        final.SetActive(true);
    }
}
