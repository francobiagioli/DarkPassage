using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interface : MonoBehaviour {


	public Text txtSubtitle;
	public Text txtHelp;
    public Text txtMessage;
    
    public float currentTime;
    
    // Use this for initialization
    void Start () {
		
		txtSubtitle.text = "";
		txtHelp.text = "";
    }
	
	// Update is called once per frame
	void Update () {
       
        UpdateSubtittle();

        UpdateMessage();

        txtHelp.text = GameManager.help;//retirar
	}

    

    private void UpdateSubtittle()
    {
        txtSubtitle.text = GameManager.subtitle;
        txtSubtitle.enabled = true;

        currentTime = Time.time;

        if (GameManager.subtitleTime != 0)
            txtSubtitle.enabled = true;
        else
            txtSubtitle.enabled = false;

        if (currentTime - GameManager.executedTime > GameManager.subtitleTime)
        {
            GameManager.executedTime = 0.0f;
            GameManager.subtitleTime = 0;
        }
    }

    private void UpdateMessage()
    {
        txtMessage.text = GameManager.message;
    }

}

