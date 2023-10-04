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
    private int maxPlayerTurns;

    private int p1SupportVal = 0;
    private int p1SupportCount = 0;

    private int p2SupportVal = 0;
    private int p2SupportCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerTurns = 0;
        maxPlayerTurns = 2;
        SelectPlayer(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActiveCharacter()
    {
        attackButton.onClick.RemoveAllListeners();
        supportButton.onClick.RemoveAllListeners();

        if (playerTurns == maxPlayerTurns)
        {
            turnText.text = "Enemy's Turn";
            playerTurns = 0;
            enemy.Attack();
            SetActiveCharacter();
        }
        else
        {
            SelectPlayer();
        }
    }

    public void SelectPlayer(bool start = false)
    {
        if (!start && playerTurns == 0)
        {
            enemy.turnSpeed += enemy.spe;
            players[0].turnSpeed += players[0].spe;
            players[1].turnSpeed += players[1].spe;
        }

        bool select = false;

        if (players[0].dead)
        {
            select = false;
            maxPlayerTurns = 1;
        }
        else if (players[1].dead)
        {
            select = true;
            maxPlayerTurns = 1;
        }
        else if (playerTurns == 0)
        {
            select = players[0].turnSpeed >= players[1].turnSpeed;
        }
        else
        {
            select = activePlayer == players[1];
        }

        if (select)
        {
            attackButton.onClick.AddListener(players[0].Attack);
            supportButton.onClick.AddListener(P1Support);
            activePlayer = players[0];
            turnText.text = "Player 1's Turn";
            RevertSupport(0);
            p1SupportCount = 0;
        }
        else
        {
            attackButton.onClick.AddListener(players[1].Attack);
            supportButton.onClick.AddListener(P2Support);
            activePlayer = players[1];
            turnText.text = "Player 2's Turn";
            RevertSupport(1);
            p2SupportCount = 0;
        }

        ++playerTurns;
    }

    public void P1Support()
    {
        players[0].Support(ref p1SupportVal, ref p1SupportCount);
    }

    public void P2Support()
    {
        players[1].Support(ref p2SupportVal, ref p2SupportCount);
    }

    public void RevertSupport(int player)
    {
        switch (p1SupportVal)
        {
            case 0:
                break;
            case 1:
                for (int i = 0; i < p1SupportCount; ++i)
                {
                    --players[player].turnDef;
                }

                break;
            case 2:
                if (p1SupportCount == 0 && player == 0)
                {
                    players[player].turnAtk = players[player].atk;

                    break;
                }

                if (player == 0)
                {
                    for (int i = 0; i < p1SupportCount; ++i)
                    {
                        players[player].turnAtk *= 2;
                    }

                    p1SupportCount = 0;
                }

                break;
            case 3:
                for (int i = 0; i < p1SupportCount; ++i)
                {
                    players[player].turnSpeed += 2;
                }

                break;
            case 4:
                for (int i = 0; i < p1SupportCount; ++i)
                {
                    --players[player].turnAtk;
                    --players[player].turnDef;
                }

                break;
            case 5:
                if (p1SupportCount == 0 && player == 0)
                {
                    players[player].turnAtk = players[player].atk;
                    players[player].turnDef = players[player].def;

                    break;
                }

                if (player == 0)
                {
                    for (int i = 0; i < p1SupportCount; ++i)
                    {
                        players[player].turnAtk *= 2;
                        players[player].turnDef -= 2;
                    }

                    p1SupportCount = 0;
                }

                break;
        }

        switch (p2SupportVal)
        {
            case 0:
                break;
            case 1:
                for (int i = 0; i < p2SupportCount; ++i)
                {
                    --players[player].turnDef;
                }

                break;
            case 2:
                if (p2SupportCount == 0 && player == 1)
                {
                    players[player].turnAtk = players[player].atk;

                    break;
                }

                if (player == 1)
                {
                    for (int i = 0; i < p2SupportCount; ++i)
                    {
                        players[player].turnAtk *= 2;
                    }

                    p2SupportCount = 0;
                }

                break;
            case 3:
                for (int i = 0; i < p2SupportCount; ++i)
                {
                    players[player].turnSpeed += 2;
                }

                break;
            case 4:
                for (int i = 0; i < p2SupportCount; ++i)
                {
                    --players[player].turnAtk;
                    --players[player].turnDef;
                }

                break;
            case 5:
                if (p2SupportCount == 0 && player == 1)
                {
                    players[player].turnAtk = players[player].atk;
                    players[player].turnDef = players[player].def;

                    break;
                }

                if (player == 1)
                {
                    for (int i = 0; i < p2SupportCount; ++i)
                    {
                        players[player].turnAtk *= 2;
                        players[player].turnDef -= 2;
                    }

                    p2SupportCount = 0;
                }

                break;
        }
    }
}
