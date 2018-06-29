using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour, ILookAtMe
{
    public Animator DoorAnimator;
    public AudioSource soundOpening;
    public AudioSource soundClosing;

    private bool Open;
    
    // Use this for initialization
    void Start()
    {
        Open = false;
        DoorAnimator = GetComponent<Animator>();//levanta el animador que esta linkeado al mismo objeto
    }

    // Update is called once per frame
    void Update()
    {
        //print("update loking at = " + GameManager.lookingAtName);
        //if (GameManager.lookingAtName.Equals("pad"))
        //{
            
        //    GameManager.message = "press E to interact";
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        Open = !Open;
        //        DoorAnimator.SetBool("Open", Open);

        //        if (Open) PlaySound(soundOpening);
        //        else PlaySound(soundClosing);
        //        print("open = " + Open);
        //    }
        //}
    }

    public void LookingAtMe()
    {
        print("name loking at = " + GameManager.lookingAtName);
        if (GameManager.lookingAtName.Equals("pad"))
        {
            GameManager.message = "Press E to interact";
            if (Input.GetKeyDown(KeyCode.E))
            {
                EInteract();
            }
        }
    }

    public void EInteract()
    {
        Open = !Open;
        DoorAnimator.SetBool("Open", Open);

        if (Open) PlaySound(soundOpening);
        else PlaySound(soundClosing);

        print("open = " + Open);

    }

    private void PlaySound(AudioSource sound)
    {
        sound.Play();
    }
}

