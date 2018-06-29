using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Ryan : MonoBehaviour
{
    public AudioSource Nothing;
	public AudioSource Investigate;

    public float activeDistance = 2;

    private string LookingAtNow;

    public Camera CameraRyan;
    
    GameObject GO;

    // Use this for initialization
    void Start()
    {
        Subtitle("Ryan : I should Check this two terminals",Investigate.clip.length);
        PlaySound(Investigate);
        LookingAtNow = "";
        //FPCRyan = GetComponent<FirstPersonController>();
        CameraRyan = GetComponentInChildren<Camera>();
        CameraRyan.enabled = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        Ray ray = CameraRyan.ScreenPointToRay(Input.mousePosition); 
                        
        if (Physics.Raycast(ray, out hitInfo, activeDistance))
        {
            GameManager.LookingAt = hitInfo.collider.transform.gameObject;
            GameManager.lookingAtName = hitInfo.collider.name;
            //Debug.Log("looking at = " + GameManager.lookingAtName);
            if (GameManager.lookingAtName != LookingAtNow)// lipieza
            {
                GameManager.message = "";
                LookingAtNow = GameManager.lookingAtName;
            }
        }
        else
        {
            //Debug.Log("not looking at = " + GameManager.lookingAtName);
            GameManager.message = "";
            GameManager.LookingAt = null;
        }

        try//TODO Revisar si esto esta bien
        {
            GO = hitInfo.transform.parent.gameObject;
            ILookAtMe x = (ILookAtMe)GO.GetComponent(typeof(ILookAtMe));
            x.LookingAtMe();
        }
        catch
        {

        }
    }

    private void Subtitle(string subtitle, float subtitletime)
    {
        GameManager.subtitle = subtitle;
        GameManager.subtitleTime = subtitletime+2;
        GameManager.executedTime = Time.time;
    }

    private void PlaySound(AudioSource sound)
    {
        sound.Play();
    }
}
