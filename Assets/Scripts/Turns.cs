using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (players[0].turnSpeed > players[1].turnSpeed)
        {
            playerTurns = 1;
            button.onClick.AddListener(players[0].Attack);
            activePlayer = players[0];
        }
        else
        {
            playerTurns = 1;
            button.onClick.AddListener(players[1].Attack);
            activePlayer = players[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setActiveCharacter()
    {
        button.onClick.RemoveAllListeners();

        if (playerTurns == 2)
        {
            playerTurns = 0;
            enemy.Attack();
            setActiveCharacter();
        }
        else
        {
            if (playerTurns == 0) { enemy.turnSpeed += enemy.spe; players[0].turnSpeed += players[0].spe; players[1].turnSpeed += players[1].spe; }

            playerTurns += 1;

            if (activePlayer == players[0])
            {
                button.onClick.AddListener(players[1].Attack);
                activePlayer = players[1];
            }
            else
            {
                button.onClick.AddListener(players[0].Attack);
                activePlayer = players[0];
            }
        }

    }
}
