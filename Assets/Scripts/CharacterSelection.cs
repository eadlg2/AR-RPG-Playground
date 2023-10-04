using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject entity;

    [SerializeField] private Player.Class newPlayerClass;

    public void SelectClass()
    {
        Player player = entity.GetComponent<Player>();
        player.playerClass = newPlayerClass;
    }
}
