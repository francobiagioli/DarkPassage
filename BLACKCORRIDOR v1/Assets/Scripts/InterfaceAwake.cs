using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceAwake : MonoBehaviour {


	public Button btnPlay;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ClickPlay() {
		SceneManager.LoadScene("scnlevel1");
	}

	//TODO
	public void ClickLoad() {
		//SceneManager.LoadScene("");
	}
	//...
}
