using UnityEngine;
using System.Collections;

public class ComputerA : MonoBehaviour {

    public AudioSource speachComputerA;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.lookingAtName.Equals("computerA"))
        {
            GameManager.message = "Press E to interact";
            if (Input.GetKeyDown(KeyCode.E))
            {
                Subtitle("Ryan :This is the Computer A", speachComputerA.clip.length);
                PlaySound(speachComputerA);
                GameManager.ComputerAChecked = true;
            }
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
