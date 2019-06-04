using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carChangeSwitch : MonoBehaviour {

    public SpriteRenderer m_SpriteRenderer;
    [SerializeField, Tooltip("Cars to display")]
    public List<GameObject> cars = new List<GameObject>();
    public AudioSource clickSound;

    public static float timeLimit = 2f;
    private static float lastButtonPressed;

    // Use this for initialization
    void Start () {
        lastButtonPressed = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (!IsValidPress())
        {
            return;
        }
        clickSound.Play(0);
        m_SpriteRenderer.color = new Color(m_SpriteRenderer.color.r, m_SpriteRenderer.color.g, m_SpriteRenderer.color.b, .9f);
        if (cars[0].activeSelf)
        {
            cars[0].SetActive(false);
            cars[1].transform.position = cars[0].transform.position;
            cars[1].transform.rotation = cars[0].transform.rotation;
            cars[1].SetActive(true);
        } else
        {
            cars[1].SetActive(false);
            cars[0].transform.position = cars[1].transform.position;
            cars[0].transform.rotation = cars[1].transform.rotation;
            cars[0].SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        m_SpriteRenderer.color = new Color(m_SpriteRenderer.color.r, m_SpriteRenderer.color.g, m_SpriteRenderer.color.b, 0.2392157f);
    }

    public void changeCar()
    {
        if (cars[0].activeSelf)
        {
            cars[0].SetActive(false);
            cars[1].transform.position = cars[0].transform.position;
            cars[1].transform.rotation = cars[0].transform.rotation;
            cars[1].SetActive(true);
        }
        else
        {
            cars[1].SetActive(false);
            cars[0].transform.position = cars[1].transform.position;
            cars[0].transform.rotation = cars[1].transform.rotation;
            cars[0].SetActive(true);
        }
    }

    public static bool IsValidPress()
    {
        if ((Time.time - lastButtonPressed) > timeLimit)
        {
            lastButtonPressed = Time.time;
            return true;
        }
        return false;
    }
}
