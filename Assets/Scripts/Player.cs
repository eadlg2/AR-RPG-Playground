using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum Class { Paladin, Wizard, Cleric, Rogue, Bard, Barbarian}

    [SerializeField]
    private Class playerClass;

    private int hp;
    private int def;
    private int spe;

    private char attackType;

    // Start is called before the first frame update
    void Start()
    {
        switch (playerClass)
        {
            case Class.Paladin:
                hp = 10; def = 2; spe = 1; attackType = 'P'; break;
            case Class.Wizard: 
                hp = 7; def = 1; spe = 2; attackType = 'M'; break;
            case Class.Cleric:
                hp = 9; def = 2; spe = 1; attackType = 'M'; break;
            case Class.Rogue:
                hp = 7; def = 1; spe = 3; attackType = 'P'; break;
            case Class.Bard:
                hp = 8; def = 2; spe = 2; attackType = 'M'; break;
            case Class.Barbarian:
                hp = 8; def = 1; spe = 2; attackType = 'P'; break;
        }

        Debug.Log("HP: " + hp);
        Debug.Log("Def: " + def);
        Debug.Log("Spe: " + spe);

        Debug.Log("Attack Type: " +  attackType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {

    }

    void Support()
    {

    }
}
