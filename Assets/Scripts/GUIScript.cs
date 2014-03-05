using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GUIScript : MonoBehaviour 
{
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

    //system info
    private List<float> frametimes;
    private int maxFrameTimes = 50;

    private int memoryUsage;

	void Start () 
	{
		playerHealth = MAX_PLAYER_HEALTH;

        frametimes = new List<float>();
	}

	void Update () 
	{
        frametimes.Add(Time.deltaTime);
        if (frametimes.Count > maxFrameTimes) frametimes.RemoveAt(0);

        memoryUsage = 0;

        Object[] objs = Resources.FindObjectsOfTypeAll<AudioClip>();

        foreach (Object o in objs)
        {
            memoryUsage += Profiler.GetRuntimeMemorySize(o);
        }

        memoryUsage /= 1024;
        memoryUsage /= 1024;
	}

	public void OnGUI()
	{
        switch(character)
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

        if (GUI.Button(new Rect(Screen.width - Screen.width / 4, 0, Screen.width / 4, Screen.height), "Switch Character"))
        {
            switch (character)
            {
                case PlayerCharacter.SPACENINJA:
                    character = PlayerCharacter.KNIGHT;
                    break;

                case PlayerCharacter.KNIGHT:
                    character = PlayerCharacter.SPACENINJA;
                    break;
            }
        }

        switch(character)
        {
            case PlayerCharacter.SPACENINJA:
            if(GUI.Button(new Rect(450, 0, 100, 50), "Throw Grenade"))
            {
                rbs.PlaySting("sting_guitar_");
            }
            break;

            case PlayerCharacter.KNIGHT:
            if (GUI.Button(new Rect(450, 0, 100, 50), "Rally Troops"))
            {
                rbs.PlaySting("sting_horn_");
            }
            break;
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

        GUI.Label(new Rect(Screen.width / 10, Screen.height - Screen.height / 10, 1000, 100), "Avg. Frame Time = " + frametimes.Average());
        GUI.Label(new Rect(Screen.width / 10, Screen.height - Screen.height / 40, 1000, 100), "Memory Used = " + memoryUsage + " MB");
    }
}
