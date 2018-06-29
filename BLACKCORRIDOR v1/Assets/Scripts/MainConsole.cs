using UnityEngine;
using System.Collections;

public class MainConsole : MonoBehaviour {

    public AudioSource speachMainConsoleReady;
    public AudioSource speachMainConsoleUnready;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.lookingAtName.Equals("mainConsole"))
        {
            GameManager.message = "Press E to interact";
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameManager.ComputerAChecked && GameManager.ComputerBChecked)
                {
                    Subtitle("Ryan :Lets input todays log.", speachMainConsoleReady.clip.length);
                    PlaySound(speachMainConsoleReady);
                    GameManager.MainConsoleChecked = true;
                }
                else {
                    Subtitle("Ryan :I have not checked all the data i need for the daily report yet.", speachMainConsoleUnready.clip.length);
                    PlaySound(speachMainConsoleUnready);
                }
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
