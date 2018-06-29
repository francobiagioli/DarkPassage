using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureOnOff : MonoBehaviour {

    public int delay = 2;
	public Material matOn;
    public Material matOff;

    // Update is called once per frame
    void Update () {
        if (Mathf.RoundToInt(Time.time) % delay == 0)
            GetComponent<Renderer>().material = matOff;
        else
            GetComponent<Renderer>().material = matOn;
    }
}
