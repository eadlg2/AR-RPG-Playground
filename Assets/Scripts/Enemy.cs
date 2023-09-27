using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    enum Class { Goblin, Golem, Zombie, Spirit, Vampire, Dragon }

    [SerializeField]
    private Class enemyClass;

    public int hp;
    private int atk;
    public int pdef;
    public int mdef;
    public int spe;

    public int turnHP;
    public int turnSpeed;

    [SerializeField] private Slider healthBar;
    [SerializeField] private Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        switch (enemyClass)
        {
            case Class.Goblin:
                hp = 10; atk = 1; pdef = 1; mdef = 1; spe = 3; break;
            case Class.Golem:
                hp = 25; atk = 3; pdef = 4; mdef = 1; spe = 1; break;
            case Class.Zombie:
                hp = 10; atk = 2; pdef = 2; mdef = 2; spe = 1; break;
            case Class.Spirit:
                hp = 15; atk = 2; pdef = 2; mdef = 3; spe = 2; break;
            case Class.Vampire:
                hp = 20; atk = 3; pdef = 3; mdef = 3; spe = 3; break;
            case Class.Dragon:
                hp = 30; atk = 4; pdef = 3; mdef = 3; spe = 2; break;
        }

        turnHP = hp;
        turnSpeed = spe;
        healthBar.maxValue = hp;
        healthText.text = turnHP.ToString() + "/" + hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = hp;
        healthText.text = turnHP.ToString() + "/" + hp.ToString();
    }

    public void Attack()
    {
        if (turnSpeed >= 2)
        {
            System.Random rnd = new System.Random();
            int playerNum = rnd.Next(1, 3);

            GameObject playerObj = GameObject.Find("Player " + playerNum);
            Player player = playerObj.GetComponent<Player>();

            if (player.hp <= 0)
            {
                if (playerNum == 1)
                {
                    playerObj = GameObject.Find("Player " + 2);
                    player = playerObj.GetComponent<Player>();
                }
                else
                {
                    playerObj = GameObject.Find("Player " + 1);
                    player = playerObj.GetComponent<Player>();
                }
            }

            int attackVal = atk - player.def;

            if (attackVal < 0) { attackVal = 0; }

            player.turnHP -= attackVal;

            turnSpeed -= 2;
        }
    }
}
