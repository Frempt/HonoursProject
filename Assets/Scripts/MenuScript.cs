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

        if (GUI.Button(new Rect(0, 0, Screen.width / 2, Screen.height), "Cyber Ninja"))
        {
            Application.LoadLevel("SpaceNinjaScene");
        }

        if (GUI.Button(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), "Knight"))
        {
            Application.LoadLevel("KnightScene");
        }
    }
}
