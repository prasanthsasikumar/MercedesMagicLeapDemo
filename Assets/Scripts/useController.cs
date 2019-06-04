using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class useController : MonoBehaviour {

    public GameObject car;
	// Use this for initialization
	void Start () {
        MLInput.OnControllerButtonDown += OnButtonDown;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnButtonDown(byte controllerId, MLInputControllerButton button)
    { if (button == MLInputControllerButton.Bumper)
            {
            car.SetActive(true);
            }
            else if (button == MLInputControllerButton.HomeTap)
            {
               
            }
    
        
    }

    public void helloWorld()
    {
        Debug.Log("Hello World");
    }
}
