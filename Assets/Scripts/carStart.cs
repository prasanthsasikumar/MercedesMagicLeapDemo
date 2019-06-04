using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carStart : MonoBehaviour {

    public AudioSource carAudio;
    public float timeLimit = 2f;

    private static float lastButtonPressed;
    // Use this for initialization
    void Start () {
        lastButtonPressed = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "touchPoints")
        {
            Debug.Log("Invalid");
            return;
        }
        if (IsValidPress())
        {
            Debug.Log("Car Starting");
            carAudio.Play(0);
        }
    }

    public bool IsValidPress()
    {
        if ((Time.time - lastButtonPressed) > timeLimit)
        {
            lastButtonPressed = Time.time;
            return true;
        }
        return false;
    }
}
