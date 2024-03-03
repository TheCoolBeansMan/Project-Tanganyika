using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currPlayer;
    public int currPhase;

    public List<GameObject> player1Units = new List<GameObject>();
    public List<GameObject> player2Units = new List<GameObject>();

    private void Start()
    {
        currPhase = 1;
        currPlayer = 1;
    }

    private void FixedUpdate()
    {
        if (currPlayer % 2 != 0)
        {
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
    }
}
