using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour 
{

	
	public static int playerLives;
	static int score = 0;
	public GameObject player;

	public static int difficultyPoints=0;


	public int initialPlayerLives = 3;
	public Text playerLivesText;
	public Text scoreText;
	public Text gameOverText;

	public static void scoreUp(int points)
	{
		score+=points;
		instance.scoreText.text = score.ToString();
	}

	public static void updateLives()
	{
		playerLives--;
		instance.playerLivesText.text = playerLives.ToString();
		
	}


	public static void reset()
	{
		score=0;
		playerLives = instance.initialPlayerLives;
		instance.gameOverText.gameObject.SetActive(false);
		instance.playerLivesText.text = instance.initialPlayerLives.ToString();
		instance.scoreText.text = score.ToString();
		SoundMaster.playMusic(SoundMaster.database.levelMusic);
	}

	public static void gameOver()
	{
		instance.gameOverText.gameObject.SetActive(true);
		instance.player.SetActive(false);

	}

	//Singleton Stuff
	public static GameMaster instance = null;
	void Awake () 
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		reset();
	}
	
	void Update()
	{

	}
	
}
