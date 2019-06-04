using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSelect : MonoBehaviour {

    public SpriteRenderer m_SpriteRenderer;
    public GameObject[] paintPanels;
    public static float timeLimit = 1f;
    public AudioSource clickSound;

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
        clickSound.Play();
        m_SpriteRenderer.color = new Color(m_SpriteRenderer.color.r, m_SpriteRenderer.color.g, m_SpriteRenderer.color.b, .4f);
        paintPanels = GameObject.FindGameObjectsWithTag("paint");
        foreach (GameObject paintPanel in paintPanels)
        {
            paintPanel.GetComponent<Material>();
            paintPanel.GetComponent<Renderer>().material.color = new Color(m_SpriteRenderer.color.r, m_SpriteRenderer.color.g, m_SpriteRenderer.color.b, .9f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        m_SpriteRenderer.color = new Color(m_SpriteRenderer.color.r, m_SpriteRenderer.color.g, m_SpriteRenderer.color.b, 1f);
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
