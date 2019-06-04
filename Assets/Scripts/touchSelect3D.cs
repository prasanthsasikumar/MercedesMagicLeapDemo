using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchSelect3D : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().material.color = new Color(1f,0f,1f,1f);
        Debug.Log("heya");
    }

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Renderer>().material.color = new Color(1f, .5f, 1f, 1f);
        transform.localPosition.Set(0f,0f,0f);
    }
}
