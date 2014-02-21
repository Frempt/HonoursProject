using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIScript : MonoBehaviour 
{
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

	void Start () 
	{
		playerHealth = MAX_PLAYER_HEALTH;
	}

	void Update () 
	{
		
	}

	public void OnGUI()
	{
        windowRect = GUI.Window(0, windowRect, DoWindow, GUIContent.none);
	}

    public void DoWindow(int id)
    {
        //buttons
        if (GUI.Button(new Rect(0, 0, 100, 50), "Switch Weapon"))
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

        if (GUI.Button(new Rect(150, 0, 100, 50), "Start/Stop Moving"))
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

        if (GUI.Button(new Rect(300, 0, 100, 50), "Spawn Enemy") && enemyHealth.Count < MAX_ENEMIES)
        {
            float newHealth = MAX_ENEMY_HEALTH;
            enemyHealth.Add(newHealth);
        }

        if(GUI.Button(new Rect(450, 0, 100, 50), "Throw Grenade"))
        {
            rbs.PlaySting("sting_guitar_");
        }

        //sliders
        GUI.Label(new Rect(20, 100, 150, 100), "Player Health : " + playerHealth);
        playerHealth = GUI.HorizontalSlider(new Rect(150, 100, 100, 10), playerHealth, 0.0f, MAX_PLAYER_HEALTH);

        for (int i = 0; i < enemyHealth.Count; i++)
        {
            GUI.Label(new Rect(20, 200 + (100 * i), 150, 100), "Enemy " + i + " Health : " + enemyHealth[i]);
            enemyHealth[i] = GUI.HorizontalSlider(new Rect(150, 200 + (100 * i), 100, 10), enemyHealth[i], 0.0f, MAX_ENEMY_HEALTH);

            if (enemyHealth[i] <= 0.0f)
            {
                enemyHealth.Remove(enemyHealth[i]);
            }
        }
    }
}
