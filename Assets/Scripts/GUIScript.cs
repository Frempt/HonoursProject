using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GUIScript : MonoBehaviour 
{
    public GUISkin skin;

    public enum PlayerCharacter
    {
        SPACENINJA = 0,
        KNIGHT = 1
    };

    public PlayerCharacter character = PlayerCharacter.SPACENINJA;

	public enum SelectedWeapon
	{
		SWORD = 0,
		SHOTGUN = 1
	};

	public SelectedWeapon weapon = SelectedWeapon.SWORD;

	public enum PlayerState
	{
		IDLE = 0,
		MOVING = 1
	};
	
	public PlayerState playerState = PlayerState.IDLE;

	public const float MAX_PLAYER_HEALTH = 100.0f;
    public const float MAX_ENEMY_HEALTH = 40.0f;
    public const int MAX_ENEMIES = 5;

	public float playerHealth;

	public List<float> enemyHealth = new List<float>();

    public RuleBaseScript rbs;

    private Rect windowRect = new Rect(0, 0, Screen.width, Screen.height);

    public Texture2D knightTex;
    public Texture2D spaceNinjaTex;

    public bool drawGUI;

	void Start () 
	{
		playerHealth = MAX_PLAYER_HEALTH;
	}

	void Update () 
	{
	}

	public void OnGUI()
	{
        GUI.skin = skin;

        if (drawGUI)
        {
            switch (character)
            {
                case PlayerCharacter.KNIGHT:
                    GUI.Label(new Rect(0, 0, Screen.width, Screen.height), knightTex);
                    break;

                case PlayerCharacter.SPACENINJA:
                    GUI.Label(new Rect(0, 0, Screen.width, Screen.height), spaceNinjaTex);
                    break;
            }

            windowRect = GUI.Window(0, windowRect, DoWindow, GUIContent.none);
        }
	}

    public void DoWindow(int id)
    {
        //buttons
        if (GUI.Button(new Rect(0, 0, Screen.width/10, Screen.height/10), "Switch Weapon"))
        {
            if (weapon == SelectedWeapon.SHOTGUN)
            {
                weapon = SelectedWeapon.SWORD;
            }
            else
            {
                weapon = SelectedWeapon.SHOTGUN;
            }
        }

        string moveState = "Start/Stop Moving";

        if (playerState == PlayerState.IDLE)
        {
            moveState = "Start Moving";
        }
        else
        {
            moveState = "Stop Moving";
        }

        if (GUI.Button(new Rect(Screen.width/9, 0, Screen.width / 10, Screen.height / 10), moveState))
        {
            if (playerState == PlayerState.IDLE)
            {
                playerState = PlayerState.MOVING;
            }
            else
            {
                playerState = PlayerState.IDLE;
            }
        }

        if (GUI.Button(new Rect(Screen.width/4, 0, Screen.width / 10, Screen.height / 10), "Spawn Enemy") && enemyHealth.Count < MAX_ENEMIES)
        {
            float newHealth = MAX_ENEMY_HEALTH;
            enemyHealth.Add(newHealth);
        }

        switch(character)
        {
            case PlayerCharacter.SPACENINJA:
            if (GUI.Button(new Rect(Screen.width/2, 0, Screen.width / 10, Screen.height / 10), "Throw Grenade"))
            {
                if(rbs != null) rbs.PlaySting("sting_guitar_");
            }
            break;

            case PlayerCharacter.KNIGHT:
            if (GUI.Button(new Rect(Screen.width / 2, 0, Screen.width / 10, Screen.height / 10), "Rally Troops"))
            {
                if (rbs != null)  rbs.PlaySting("sting_horn_");
            }
            break;
        }

        if (GUI.Button(new Rect(Screen.width - Screen.width / 10, 0, Screen.width / 10, Screen.height / 10), "Back to Menu"))
        {
            Application.LoadLevel("MenuScene");
        }

        //sliders
        GUI.Label(new Rect(Screen.width/100, Screen.height/10, 150, 100), "Player Health : " + playerHealth);
        playerHealth = GUI.HorizontalSlider(new Rect(Screen.width/10, 100, 100, 10), playerHealth, 0.0f, MAX_PLAYER_HEALTH);

        for (int i = 0; i < enemyHealth.Count; i++)
        {
            GUI.Label(new Rect(Screen.width / 100, 200 + (100 * i), 150, 100), "Enemy " + i + " Health : " + enemyHealth[i]);
            enemyHealth[i] = GUI.HorizontalSlider(new Rect(Screen.width / 10, 200 + (100 * i), 100, 10), enemyHealth[i], 0.0f, MAX_ENEMY_HEALTH);

            if (!Input.GetMouseButton(0) && enemyHealth[i] <= 0.0f)
            {
                enemyHealth.Remove(enemyHealth[i]);
            }
        }
    }
}
