using UnityEngine;
using System.Collections;

public class ComputerB : MonoBehaviour{

    public AudioSource speachComputerB;

    // Use this for initialization
    void Start(){
       
    }

    // Update is called once per frame
    void Update(){
        if (GameManager.lookingAtName.Equals("computerB"))
        {
            GameManager.message = "Press E to interact";
            if (Input.GetKeyDown(KeyCode.E))
            {
                Subtitle("Ryan :This is the Computer B", speachComputerB.clip.length);
                PlaySound(speachComputerB);
                GameManager.ComputerBChecked = true;
            }
        }
    }

    private void PlaySound(AudioSource sound)//TODO sacar de aca y hacer una lcase de herencia
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
