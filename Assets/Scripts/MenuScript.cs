using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour 
{
    public Texture2D knightTex;
    public Texture2D spaceNinjaTex;
    public GUISkin skin;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnGUI()
    {
        GUI.skin = skin;

        if (GUI.Button(new Rect(0, 0, Screen.width / 2, Screen.height / 2), "1A"))
        {
            Application.LoadLevel("SpaceNinjaStaticScene");
        }

        if (GUI.Button(new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height / 2), "1B"))
        {
            Application.LoadLevel("SpaceNinjaScene");
        }

        if (GUI.Button(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height / 2), "2A"))
        {
            Application.LoadLevel("KnightStaticScene");
        }

        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "2B"))
        {
            Application.LoadLevel("KnightScene");
        }
    }
}
