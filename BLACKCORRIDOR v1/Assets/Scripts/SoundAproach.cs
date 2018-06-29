using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAproach : MonoBehaviour {

    public AudioSource clip;

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

        var dist = distance(GameManager.ryan, this.transform.position);
        //print("ditance to sound fount ="+dist+" /clip volume = "+clip.volume);
        if (dist < 10)
        {
            clip.volume = 1 / (1 + (50 * dist));
        }
        else clip.volume = 0;
    }

    float distance(Vector3 a, Vector3 b)
    {
        float x = a.x - b.x;
        float y = a.y - b.y;
        float z = a.z - b.z;
        return Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2) + Mathf.Pow(z, 2));
    }

}
