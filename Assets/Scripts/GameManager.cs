using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currPlayer;
    public int currPhase;

    public GameObject phaseButtonPlayer1;
    public GameObject phaseButtonPlayer2;
    public GameObject player1TurnAnim;
    public GameObject movePhaseAnim;
    public GameObject navalPhaseAnim;
    public GameObject artilleryPhaseAnim;
    public GameObject player2TurnAnim;

    public List<GameObject> player1Units = new List<GameObject>();
    public List<GameObject> player2Units = new List<GameObject>();

    private Animator player1PhaseAnimator;
    private Animator player2PhaseAnimator;
    private Animator movePhaseAnimator;
    private Animator navalPhaseAnimator;
    private Animator artilleryPhaseAnimator;

    private void Start()
    {
        currPhase = 1;
        currPlayer = 1;
        Debug.Log("Player: " + currPlayer.ToString() + ", Phase: " + currPhase.ToString());

        // Get the Animator components
        player1PhaseAnimator = player1TurnAnim.GetComponent<Animator>();
        player2PhaseAnimator = player2TurnAnim.GetComponent<Animator>();
        movePhaseAnimator = movePhaseAnim.GetComponent<Animator>();
        navalPhaseAnimator = navalPhaseAnim.GetComponent<Animator>();
        artilleryPhaseAnimator = artilleryPhaseAnim.GetComponent<Animator>();

        player1TurnAnim.SetActive(false);
        player2TurnAnim.SetActive(false);
        movePhaseAnim.SetActive(false);
        navalPhaseAnim.SetActive(false);
        artilleryPhaseAnim.SetActive(false);

        player1PhaseAnimator.enabled = false;
        player2PhaseAnimator.enabled = false;
        movePhaseAnimator.enabled = false;
        navalPhaseAnimator.enabled = false;
        artilleryPhaseAnimator.enabled = false;

        //Instantiate(characterPrefab).GetComponent<CharacterInfo>();
        //PositionCharacterOnTile(overlayTile);

        foreach (GameObject unit in player1Units)
        {
            unit.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void Update()
    {
        if (player1Units.Count == 0)
        {
            SceneManager.LoadScene("GermVictory");
        }

        if (player2Units.Count == 0)
        {
            SceneManager.LoadScene("BritVictory");
        }
    }

    private void FixedUpdate()
    {
        if (currPlayer % 2 != 0)
        {
            PhaseAnim1();
        }
        if (currPlayer % 2 == 0)
        {
            PhaseAnim2();
        }
    }

    public void PhaseAnim1()
    {
        phaseButtonPlayer1.gameObject.SetActive(true);
        phaseButtonPlayer1.gameObject.GetComponent<Button>().interactable = true;
        phaseButtonPlayer2.gameObject.SetActive(false);
        phaseButtonPlayer2.gameObject.GetComponent<Button>().interactable = false;
        if (currPhase == 1)
        {
            
            // Player 1 Transition Animation
            //player1TurnAnim.SetActive(true);
            //player1PhaseAnimator.Play("BannerPanelOpacAnim");

            // Move Phase Transition Animation
            //movePhaseAnim.SetActive(true);
            //movePhaseAnimator.Play("BannerPanelOpacAnim");
        }
        else if (currPhase == 2)
        {
            // Naval Phase Transition Animation
            //player1TurnAnim.SetActive(false);
            //movePhaseAnim.SetActive(false);
            //navalPhaseAnim.SetActive(true);
            //navalPhaseAnimator.Play("BannerPanelOpacAnim");
        }
        else if (currPhase == 3)
        {
            // Artillery Phase Transition Animation
            //artilleryPhaseAnim.SetActive(true);
            //artilleryPhaseAnimator.Play("BannerPanelOpacAnim");
        }
    }

    public void PhaseAnim2()
    {
        phaseButtonPlayer2.gameObject.SetActive(true);
        phaseButtonPlayer2.gameObject.GetComponent<Button>().interactable = true;
        phaseButtonPlayer1.gameObject.SetActive(false);
        phaseButtonPlayer1.gameObject.GetComponent<Button>().interactable = false;
        if (currPhase == 1)
        {
            // Player 2 Transition Animation
            //player2TurnAnim.SetActive(true);
            //player1PhaseAnimator.Play("BannerPanelOpacAnim");

            // Move Phase Transition Animation
            //movePhaseAnim.SetActive(true);
            //movePhaseAnimator.Play("BannerPanelOpacAnim");
        }
        else if (currPhase == 2)
        {
            // Naval Phase Transition Animation
            //player2TurnAnim.SetActive(false);
            //movePhaseAnim.SetActive(false);
            //navalPhaseAnim.SetActive(true);
            //navalPhaseAnimator.Play("BannerPanelOpacAnim");
        }
        else if (currPhase == 3)
        {
            // Artillery Phase Transition Animation
            //artilleryPhaseAnim.SetActive(true);
            //artilleryPhaseAnimator.Play("BannerPanelOpacAnim");
        }
    }

    public void ClickTest()
    {
        Debug.Log("Click Confirmed");
    }

    public void EndPhase()
    {
        currPhase++;
        if (currPhase > 1)
        {
            currPhase = 1;
            currPlayer++;

            if (currPlayer > 2)
            {
                currPlayer = 1;
            }
        }
        Debug.Log("Player: " + currPlayer.ToString() + ", Phase: " + currPhase.ToString());
    }
}
