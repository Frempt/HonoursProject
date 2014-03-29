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
            if (Input.mousePosition.y <= Screen.height / 2)
            {
                Application.LoadLevel("SpaceNinjaScene");
            }
            else
            {
                Application.LoadLevel("SpaceNinjaStaticScene");
            }
        }

        if (GUI.Button(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), knightTex, "label"))
        {
            if (Input.mousePosition.y <= Screen.height / 2)
            {
                Application.LoadLevel("KnightScene");
            }
            else
            {
                Application.LoadLevel("KnightStaticScene");
            }
        }
    }
}
