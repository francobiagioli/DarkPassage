using UnityEngine;
using System.Collections;

public class crossMovement : MonoBehaviour {

    public Rect position;

    // Use this for initialization
    void Start(){
    }

	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 34);
       

    }

   
}
