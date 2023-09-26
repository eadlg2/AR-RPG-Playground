using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum Class { Goblin, Golem, Zombie, Spirit, Vampire, Dragon }

    [SerializeField]
    private Class enemyClass;

    public int hp;
    private int atk;
    public int pdef;
    public int mdef;
    private int spe;

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Attack()
    {

    }
}