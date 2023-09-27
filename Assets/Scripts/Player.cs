using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    enum Class { Paladin, Wizard, Cleric, Rogue, Bard, Barbarian}

    [SerializeField]
    private Class playerClass;

    private int hp;
    private int atk;
    public int def;
    public int spe;

    public int turnHP;
    public int turnSpeed;

    private char attackType;

    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    public TextMeshPro speedText;

    // Start is called before the first frame update
    void Start()
    {
        switch (playerClass)
        {
            case Class.Paladin:
                hp = 10; atk = 2;  def = 2; spe = 1; attackType = 'P'; break;
            case Class.Wizard: 
                hp = 7; atk = 3; def = 1; spe = 2; attackType = 'M'; break;
            case Class.Cleric:
                hp = 9; atk = 1; def = 2; spe = 1; attackType = 'M'; break;
            case Class.Rogue:
                hp = 7; atk = 2; def = 1; spe = 3; attackType = 'P'; break;
            case Class.Bard:
                hp = 8; atk = 2; def = 2; spe = 2; attackType = 'M'; break;
            case Class.Barbarian:
                hp = 8; atk = 3; def = 1; spe = 2; attackType = 'P'; break;
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
        if (turnSpeed >= 2)
        {
            GameObject enemyObj = GameObject.Find("Enemy");
            Enemy enemy = enemyObj.GetComponent<Enemy>();

            int attackVal = atk;

            if (attackType == 'P')
            {
                attackVal -= enemy.pdef;
            }
            else
            {
                attackVal -= enemy.mdef;
            }

            if (attackVal < 0) { attackVal = 0; }

            enemy.turnHP -= attackVal;

            turnSpeed -= 2;
        }
    }

    public void Support()
    {
        switch (playerClass)
        {
            case Class.Paladin:
                hp = 10; atk = 2; def = 2; spe = 1; attackType = 'P'; break;
            case Class.Wizard:
                hp = 7; atk = 3; def = 1; spe = 2; attackType = 'M'; break;
            case Class.Cleric:
                hp = 9; atk = 1; def = 2; spe = 1; attackType = 'M'; break;
            case Class.Rogue:
                hp = 7; atk = 2; def = 1; spe = 3; attackType = 'P'; break;
            case Class.Bard:
                hp = 8; atk = 2; def = 2; spe = 2; attackType = 'M'; break;
            case Class.Barbarian:
                hp = 8; atk = 3; def = 1; spe = 2; attackType = 'P'; break;
        }
    }
}
