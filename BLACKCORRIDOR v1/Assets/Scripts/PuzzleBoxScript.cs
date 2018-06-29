using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleBoxScript : MonoBehaviour
{
    public Animator puzzleAnimator;
    public AudioSource SpeachThisAgain;
    public AudioSource SpeachLetsSee;
    public AudioSource doorOpen;
    public Light emergencyLigth;

    public Material green;
    public Material red;

    public GameObject compAB;
    public GameObject compCD;
    public GameObject compABCD;

    public GameObject resultAB;
    public GameObject resultCD;
    public GameObject resultABCD;

    public Material matAND;
    public Material matOR;
    
    private int inpA = 1;
    private int inpB = 1;
    private int inpC = 0;
    private int inpD = 1;
    private int inpAB = 0;
    private int inpCD = 0;
    private int exit = 0;

    string statAB = "--";
    string statCD = "--";
    string statABCD = "--";

    private bool puzzleboxOpen;

    private bool puzzleboxSolved;

    // Use this for initialization
    void Start()
    {
        puzzleboxOpen = false;
        puzzleboxSolved = false;
        puzzleAnimator = gameObject.GetComponent<Animator>();//levanta el animador que esta linkeado al mismo objeto
        emergencyLigth.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.lookingAtName.Equals("doorTop") && (!puzzleboxSolved))
        {
            GameManager.message = "Press E to interact";
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!puzzleboxOpen)
                {
                    Subtitle("Ryan :This again?! I can not even dream on going stasis if the systems keep rebooting like this", SpeachThisAgain.clip.length);
                    PlaySound(SpeachThisAgain);
                    PlaySound(doorOpen);
                    puzzleboxOpen = !puzzleboxOpen;
                    puzzleAnimator.SetBool("Open", puzzleboxOpen);//el parametro del animador entre comillas
                }
                else if (puzzleboxOpen)
                {
                    Subtitle("Ryan :Lets see what happened now", SpeachLetsSee.clip.length);
                    PlaySound(SpeachLetsSee);//TODO cambiar la camara para que este cerca del puzle limitada en mov
                }
            }

        }

        if (Input.GetMouseButtonDown(0))//TODO simplificar esto que es un bodrio
        {
            if (GameManager.lookingAtName.Equals("compAB"))
            {
                statAB= updatebutton(compAB);
                Debug.Log(statAB);
                
            }
            else if (GameManager.lookingAtName.Equals("compCD"))
            {
                statCD = updatebutton(compCD);
                Debug.Log(statCD);
                
            }
            else if (GameManager.lookingAtName.Equals("compABCD"))
            {
                Debug.Log("3");
                statABCD = updatebutton(compABCD);
               
            }

            inpAB = UpdateComp(inpA, inpB, statAB);
            inpCD = UpdateComp(inpC, inpD, statCD);
            exit = UpdateComp(inpAB, inpCD, statABCD);
            //print("State AB=" + inpAB);
            UpdateState(inpAB, resultAB);
            //print("State CD=" + inpCD);
            UpdateState(inpCD, resultCD);
            //print("State exit=" + exit);
            UpdateState(exit, resultABCD);

            if (exit >= 1)
            {
                puzzleboxSolved = true;
            }

        }

        if (puzzleboxOpen && puzzleboxSolved)
        {
            puzzleboxOpen = !puzzleboxOpen;
            puzzleAnimator.SetBool("Open", puzzleboxOpen);//el parametro del animador entre comillas
            PlaySound(doorOpen);
            emergencyLigth.color = Color.green;
        }
    }

    private int UpdateComp(int a, int b, string comp)
    {
        if (comp.Equals("AND"))
        {
            return a * b;
        }
        else if (comp.Equals("OR"))
        {
            return a + b;
        }
        else
        {
            return 0;
        }
    }

    private void UpdateState(int state, GameObject result)
    {

        if (state >= 1)
        {
            result.GetComponent<Renderer>().material = green;
        }
        else
        {
            result.GetComponent<Renderer>().material = red;
        }
    } 

    private string updatebutton(GameObject comp)
    {
        // If material is not AND
        if (!comp.GetComponent<Renderer>().material.mainTexture.name.Equals(matAND.mainTexture.name))
        {
            comp.GetComponent<Renderer>().material = matAND;
            return "AND";
        }
        else
        {
            comp.GetComponent<Renderer>().material = matOR;
            return "OR";
        }
    }

    private void PlaySound(AudioSource sound)
    {
        sound.Play();
    }

    private void Subtitle(string subtitle, float subtitletime)
    {
        GameManager.subtitle = subtitle;
        GameManager.subtitleTime = subtitletime + 2;
        GameManager.executedTime = Time.time;
    }
}

