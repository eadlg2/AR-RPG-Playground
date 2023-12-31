using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum Class { Goblin, Golem, Zombie, Spirit, Vampire, Dragon, None }

    public Class enemyClass;

    private int hp;
    private int atk;
    public int pdef;
    public int mdef;
    public int spe;

    public int turnHP;
    public int turnSpeed;

    public bool dead;

    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    private TextMeshPro speedText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetupEnemy()
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

        speedText = gameObject.GetComponentInChildren<TextMeshPro>();

        turnHP = hp;
        turnSpeed = spe;
        speedText.text = "Speed: " + turnSpeed.ToString();
        healthBar.maxValue = hp;
        healthText.text = turnHP.ToString() + "/" + hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = "Speed: " + turnSpeed.ToString();
        healthBar.value = turnHP;
        healthText.text = turnHP.ToString() + "/" + hp.ToString();
    }

    public void Attack()
    {
        while (turnSpeed >= 2)
        {
            int crit = Random.Range(0, 100);
            int playerNum = Random.Range(1, 2);

            GameObject playerObj = GameObject.Find("Player " + playerNum);
            Player player = playerObj.GetComponent<Player>();

            if (player.dead)
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

            if (crit <= 10)
            {
                player.turnHP -= 2 * attackVal;
            }
            else
            {
                player.turnHP -= attackVal;
            }

            if (player.turnHP <= 0) { player.dead = true; }

            turnSpeed -= 2;
        }
    }
}
