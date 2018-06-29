using UnityEngine;
using System.Collections;

public class PuzzleBoxInputScript : MonoBehaviour, ILookAtMe {

    public Animator puzzleInputAnimator;

    public Light ligthpuzz;

    public GameObject oInpA;
    public GameObject oInpB;
    public GameObject oInpC;
    public GameObject oInpD;

    public Material matGreen;
    public Material matRed;

    public AudioSource soundOpening;
    public AudioSource soundClosing;

    private bool puzzleboxInputOpen;
    private bool puzzleboxInputSolved;

    private bool inpA;
    private bool inpB;
    private bool inpC;
    private bool inpD;

    // Use this for initialization
    void Start () {
        puzzleboxInputOpen = false;
        puzzleboxInputSolved = false;
        puzzleInputAnimator = gameObject.GetComponent<Animator>();//levanta el animador que esta linkeado al mismo objeto
        inpA = true;
        inpB = true;
        inpC = true;
        inpD = true;
    }
	
	// Update is called once per frame
	void Update () {
       

    }

    public bool SwitchPress(GameObject switc, bool state)
    {
        state = !state;
        if (state)
        {
            switc.GetComponent<Renderer>().material = matGreen;
        }
        else
        {
            switc.GetComponent<Renderer>().material = matRed;
        }
        print("state = " + state.ToString());
        
        return state;
    }

    public void LookingAtMe()
    {
        if (!puzzleboxInputSolved && (GameManager.Step==2))
        {


            GameManager.message = "Press E to interact";
            if (Input.GetKeyDown(KeyCode.E))
            {
                EInteract();
            }

            switch (GameManager.lookingAtName)
            {
                case "inpA":
                    if (Input.GetMouseButtonDown(0))
                    {
                        inpA = SwitchPress(oInpA, inpA);
                        refreshEcuation();
                    }
                    break;
                case "inpB":
                    if (Input.GetMouseButtonDown(0))
                    {
                        inpB = SwitchPress(oInpB, inpB);
                        refreshEcuation();
                    }
                    break;
                case "inpC":
                    if (Input.GetMouseButtonDown(0))
                    {
                        inpC = SwitchPress(oInpC, inpC);
                        refreshEcuation();
                    }
                    break;
                case "inpD":
                    if (Input.GetMouseButtonDown(0))
                    {
                        inpD = SwitchPress(oInpD, inpD);
                        refreshEcuation();
                    }
                    break;
            }
        }
    }

    public void refreshEcuation()
    {
        bool result = ((!(inpA && inpB)) && (!inpC) && (inpC || inpD));
        print("result = " + result);
        if (result)
        {
            ligthpuzz.color = Color.green;
            EInteract();
            puzzleboxInputSolved = true;
        }        

    }

    public void EInteract()
    {
        //print(puzzleInputAnimator.name);
        puzzleboxInputOpen = !puzzleboxInputOpen;
        puzzleInputAnimator.SetBool("Open", puzzleboxInputOpen);
        if (puzzleboxInputOpen) PlaySound(soundClosing);
        else PlaySound(soundOpening);

    }

    private void PlaySound(AudioSource sound)//TODO sacara a un metodo generico de donde extiendan los scripts
    {
        sound. Play();
    }
}
