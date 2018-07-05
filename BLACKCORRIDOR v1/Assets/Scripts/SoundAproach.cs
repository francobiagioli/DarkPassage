using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAproach : MonoBehaviour {

    public AudioSource terminal;
    
    public GameObject ter1;
    public GameObject ter2;
    public GameObject ter3;
    //********************************
    //TODO que los sonidos esten con ryan un solo clip para el pasillo con random gas hiss y que cuando se aproxime a alguna de las terminales se aumente el sonido , asi solo tengo un clip de audio y un update
    //********************************


    // Use this for initialization
    void Start () {
        float xThis = this.transform.position.x;
        float yThis = this.transform.position.y;
        float zThis = this.transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        
        var time = DateTime.Now.Millisecond;

        //if ((time%500==0)) {
        //    playSound(airScape);
        //}
               
        GameObject[] values = { ter1, ter2, ter3 };


        if (Closer(values, GameManager.ryan) != null)
        {

            //print("posx =" + this.transform.position.x);
            //print("posy =" + this.transform.position.y);
            //print("posz =" + this.transform.position.z);

            //print("posx =" + this.transform.position.x + "/posy =" + this.transform.position.y + "/posz =" + this.transform.position.z);

            this.transform.position.Set((Closer(values, GameManager.ryan).transform.position.x), (Closer(values, GameManager.ryan).transform.position.y), (Closer(values, GameManager.ryan).transform.position.z));
            print("posx =" + (Closer(values, GameManager.ryan).transform.position.x) + "/posy =" + (Closer(values, GameManager.ryan).transform.position.y) + "/posz =" + (Closer(values, GameManager.ryan).transform.position.z));
            print("2 ;   posx =" + this.transform.position.x + "/posy =" + this.transform.position.y + "/posz =" + this.transform.position.z);
            terminal.volume = 1 / (1 + (10 * distance(Closer(values, GameManager.ryan).transform.position, GameManager.ryan)));
        }
        else
        {
            terminal.volume = 0;
        }

       //if()

        //print("distance to A =" + time + "/distance to B =" + distB + "/distance to C =" + distC + " /clip volume = " + terminal.volume);
        //print("2 ;   posx =" + this.transform.position.x + "/posy =" + this.transform.position.y + "/posz =" + this.transform.position.z);

        ////print("ditance to sound fount ="+dist+" /clip volume = "+clip.volume);
        //if (dist < 10)
        //{
        //    terminal.volume = 1 / (1 + (50 * dist));
        //}
        //else terminal.volume = 0;
    }

    GameObject Closer(GameObject[] values, Vector3 point)//returns the closest element in a range from an array of objects
    {
        var distA = distance(values[0].transform.position, GameManager.ryan);
        var distB = distance(values[1].transform.position, GameManager.ryan);
        var distC = distance(values[2].transform.position, GameManager.ryan);

        float[] valuesDist = { distA, distB, distC };

        if (valuesDist.Min() < 10)
        {
            if (valuesDist.Min() == distA) return values[0];
            else if (valuesDist.Min() == distB) return values[1];
            else return values[2];
        }
        else return null;
                
    }
    
    float distance(Vector3 a, Vector3 b)
    {
        float x = a.x - b.x;
        float y = a.y - b.y;
        float z = a.z - b.z;
        return Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2) + Mathf.Pow(z, 2));
    }

    void playSound(AudioSource sound)
    {
        sound.Play();
    }

}
