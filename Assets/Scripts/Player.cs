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

    [SerializeField] private Player partner;

    private int hp;
    private int atk;
    public int def;
    public int spe;

    public int turnHP;
    public int turnAtk;
    public int turnDef;
    public int turnSpeed;

    private char attackType;

    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    private TextMeshPro speedText;

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
        turnAtk = atk;
        turnDef = def;
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
            int crit = Random.Range(0, 100);

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

            if (crit <= 10)
            {
                enemy.turnHP -= 2 * attackVal;
            }
            else
            {
                enemy.turnHP -= attackVal;
            }

            turnSpeed -= 2;
        }
    }

    public void Support(ref int support)
    {
        if (turnSpeed >= 2)
        {
            switch (playerClass)
            {
                case Class.Paladin:
                    ++turnDef;
                    ++partner.turnDef;

                    support = 0;

                    break;
                case Class.Wizard:
                    turnHP -= 2;
                    partner.turnHP -= 2;

                    turnAtk *= 2;

                    support = 1;

                    break;
                case Class.Cleric:
                    turnHP += 2;
                    partner.turnHP += 2;

                    break;
                case Class.Rogue:
                    turnSpeed += 2;
                    partner.turnSpeed += 2;

                    break;
                case Class.Bard:
                    ++turnAtk;
                    ++partner.turnAtk;

                    ++turnDef;
                    ++partner.turnDef;

                    ++turnSpeed;
                    ++partner.turnSpeed;

                    support = 2;

                    break;
                case Class.Barbarian:
                    turnDef -= 2;

                    turnAtk += 2;

                    support = 3;

                    break;
            }

            turnSpeed -= 2;
        }
    }
}
