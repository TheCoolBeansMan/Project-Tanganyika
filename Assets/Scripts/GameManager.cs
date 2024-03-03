using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currPlayer;
    public int currPhase;

    public GameObject phaseButtonPlayer1;
    public GameObject phaseButtonPlayer2;

    public List<GameObject> player1Units = new List<GameObject>();
    public List<GameObject> player2Units = new List<GameObject>();

    private void Start()
    {
        currPhase = 1;
        currPlayer = 1;
        Debug.Log("Player: " + currPlayer.ToString() + ", Phase: " + currPhase.ToString());
    }

    private void FixedUpdate()
    {
        if (currPlayer % 2 != 0)
        {
            phaseButtonPlayer1.gameObject.SetActive(true);
            phaseButtonPlayer2.gameObject.SetActive(false);
            if (currPhase == 1)
            {
                //Player 1 Transition Animation
                //Move Phase Transition Animation

            }
            if (currPhase == 2)
            {
                //Naval Phase Transition Animation

            }
            if (currPhase == 3)
            {
                //Artillery Phase Transition Animation

            }
        }
        if (currPlayer % 2 == 0)
        {
            phaseButtonPlayer2.gameObject.SetActive(true);
            phaseButtonPlayer1.gameObject.SetActive(false);
            if (currPhase == 1)
            {
                //Player 2 Transition Animation
                //Move Phase Transition Animation

            }
            if (currPhase == 2)
            {
                //Naval Phase Transition Animation

            }
            if (currPhase == 3)
            {
                //Artillery Phase Transition Animation

            }
        }
    }

    public void EndPhase()
    {
        currPhase++;
        if (currPhase > 3)
        {
            currPhase = 1;
            currPlayer++;
        }
        Debug.Log("Player: " + currPlayer.ToString() + ", Phase: " + currPhase.ToString());
    }
}
