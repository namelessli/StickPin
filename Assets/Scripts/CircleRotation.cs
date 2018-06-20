using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotation : MonoBehaviour {

    public float speed = -60;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0,0,-speed * Time.deltaTime));
	}
}
