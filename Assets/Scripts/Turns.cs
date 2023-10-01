using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Turns : MonoBehaviour
{
    [SerializeField] private List<Player> players;
    [SerializeField] private Enemy enemy;

    [SerializeField] private Button attackButton;
    [SerializeField] private Button supportButton;

    [SerializeField] private TextMeshProUGUI turnText;

    private Player activePlayer;
    private int playerTurns;

    private int p1SupportVal;
    private int p2SupportVal;

    // Start is called before the first frame update
    void Start()
    {
        if (players[0].turnSpeed >= players[1].turnSpeed)
        {
            playerTurns = 1;
            attackButton.onClick.AddListener(players[0].Attack);
            supportButton.onClick.AddListener(P1Support);
            activePlayer = players[0];
            turnText.text = "Player 1's Turn";
        }
        else
        {
            playerTurns = 1;
            attackButton.onClick.AddListener(players[1].Attack);
            supportButton.onClick.AddListener(P2Support);
            activePlayer = players[1];
            turnText.text = "Player 2's Turn";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActiveCharacter()
    {
        attackButton.onClick.RemoveAllListeners();
        supportButton.onClick.RemoveAllListeners();

        if (playerTurns == 2)
        {
            turnText.text = "Enemy's Turn";
            playerTurns = 0;
            enemy.Attack();
            SetActiveCharacter();
        }
        else if (playerTurns == 0)
        {
            enemy.turnSpeed += enemy.spe;
            players[0].turnSpeed += players[0].spe;
            players[1].turnSpeed += players[1].spe;

            playerTurns += 1;

            if (players[0].turnSpeed >= players[1].turnSpeed)
            {
                playerTurns = 1;
                attackButton.onClick.AddListener(players[0].Attack);
                supportButton.onClick.AddListener(P1Support);
                activePlayer = players[0];
                turnText.text = "Player 1's Turn";
            }
            else
            {
                playerTurns = 1;
                attackButton.onClick.AddListener(players[1].Attack);
                supportButton.onClick.AddListener(P2Support);
                activePlayer = players[1];
                turnText.text = "Player 2's Turn";
            }
        }
        else
        {
            playerTurns += 1;

            if (activePlayer == players[0])
            {
                attackButton.onClick.AddListener(players[1].Attack);
                supportButton.onClick.AddListener(P2Support);
                activePlayer = players[1];
                turnText.text = "Player 2's Turn";
            }
            else
            {
                attackButton.onClick.AddListener(players[0].Attack);
                supportButton.onClick.AddListener(P1Support);
                activePlayer = players[0];
                turnText.text = "Player 1's Turn";
            }
        }
    }

    public void P1Support()
    {
        players[0].Support(ref p1SupportVal);
    }

    public void P2Support()
    {
        players[1].Support(ref p2SupportVal);
    }
}
