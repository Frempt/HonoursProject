using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour 
{
    public Texture2D knightTex;
    public Texture2D spaceNinjaTex;

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
        if (GUI.Button(new Rect(0, 0, Screen.width / 2, Screen.height), spaceNinjaTex, "label"))
        {
            Application.LoadLevel("SpaceNinjaScene");
        }

        if (GUI.Button(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), knightTex, "label"))
        {
            Application.LoadLevel("KnightScene");
        }
    }
}
