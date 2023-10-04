using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject entity;

    [SerializeField] private GameObject model;

    [SerializeField] private Player.Class newPlayerClass;
    [SerializeField] private Enemy.Class newEnemyClass;

    [SerializeField] private GameObject confirmButton;

    public void SelectClass()
    {
        if (newPlayerClass != Player.Class.None)
        {
            Player player = entity.GetComponent<Player>();
            player.playerClass = newPlayerClass;

            if (player.transform.childCount == 2)
            {
                Destroy(player.transform.GetChild(1).gameObject);
            }

            Instantiate(model, player.transform);

            confirmButton.SetActive(true);
            confirmButton.GetComponentInChildren<TextMeshProUGUI>().text = "Confirm " + newPlayerClass.ToString();
        }
        else if (newEnemyClass != Enemy.Class.None)
        {
            Enemy enemy = entity.GetComponent<Enemy>();
            enemy.enemyClass = newEnemyClass;

            if (enemy.transform.childCount == 2)
            {
                Destroy(enemy.transform.GetChild(1).gameObject);
            }

            Instantiate(model, enemy.transform);

            confirmButton.SetActive(true);
            confirmButton.GetComponentInChildren<TextMeshProUGUI>().text = "Confirm " + newEnemyClass.ToString();
        }
    }
}
