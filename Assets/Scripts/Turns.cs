using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Turns : MonoBehaviour
{
    [SerializeField] private List<Player> players;
    [SerializeField] private Enemy enemy;

    [SerializeField] private Button button;

    private Player activePlayer;
    private int playerTurns;

    // Start is called before the first frame update
    void Start()
    {
        if (players[0].spe > players[1].spe)
        {
            button.clicked += (players[0].Attack);
            activePlayer = players[0];
        }
        else
        {
            button.clicked += players[1].Attack;
            activePlayer = players[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setActiveCharacter()
    {
        if (playerTurns == 2)
        {
            playerTurns = 0;
            button.clicked += enemy.Attack;
        }
        else
        {
            playerTurns += 1;

            if (activePlayer == players[0])
            {
                button.clicked += players[1].Attack;
                activePlayer = players[1];
            }
            else
            {
                button.clicked += players[0].Attack;
                activePlayer = players[0];
            }
        }

    }
}
