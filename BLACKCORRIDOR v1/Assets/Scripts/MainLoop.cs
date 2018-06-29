using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class MainLoop: MonoBehaviour {


    //private bool playing = true;

    //public Light bridgeLamp1;
   // public Light bridgeLamp2;
    //public Light bridgeLamp3;
    //public Light bridgeLamp4;

    public FirstPersonController Ryan;
        
    // Use this for initialization
    void Start () {
        GameManager.ryan = Ryan.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        GameManager.ryan = Ryan.transform.position;

        GameManager.help = "Looking at =" + GameManager.lookingAtName + " / Ryan = " + Ryan.transform.position+ " /RyanRot = " + Ryan.transform.localRotation + "/ timesub = " + GameManager.subtitleTime;

        if (GameManager.ComputerAChecked && GameManager.ComputerBChecked && GameManager.MainConsoleChecked && (GameManager.Step==1))
        {
            GameManager.Step = 2;
            //bridgeLamp1.color = Color.red;//TODO meter en un proceso y llamarlo emergencia
            //bridgeLamp1.intensity = 1;
           // bridgeLamp2.color = Color.red;
            //bridgeLamp2.intensity = 1;
            //bridgeLamp3.color = Color.red;
           // bridgeLamp3.intensity = 1;
            //bridgeLamp4.color = Color.red;
            //bridgeLamp4.intensity = 1;
            //todo apagar la luz

        }
        

    }
      
    int Near (List<GameObject> objects, FirstPersonController ryan, float dist)//returns the index of the object you are near
	{//TODO Ray cast
        int index = 0;
        foreach (GameObject obj in objects)
        {
            if (distance(ryan, obj) < dist)
            {
                return index;
            }
            index++;
        }
        return -1;
	}

    float distance(FirstPersonController a , GameObject b)
    {
        float x = a.transform.position.x - b.transform.position.x;
        float y = a.transform.position.y - b.transform.position.y;
        float z = a.transform.position.z - b.transform.position.z;
        return Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2) + Mathf.Pow(z, 2));
    }

}