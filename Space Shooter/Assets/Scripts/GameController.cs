using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	
	public Vector3 spawnValues;

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GameObject PowerUp;
	public int PowerUpCounts;
	public float spawnWaitPU;
	public float startWaitPU;
	public float waveWaitPU;

	public GameObject PowerUp1;
	public int PowerUpCounts1;
	public float spawnWaitPU1;
	public float startWaitPU1;
	public float waveWaitPU1;

   public Text scoreText;
	public Text restartText;
	public Text gameOverText;
	public Text highScoreText;

	private bool gameOver;
	private bool restart;
 	private int score;

  /*  public Text timerText;
	public GameObject timerTextObj; */

   void Start ()
	{
	    gameOver = false;
		 restart= false;
	//	 timerText.text = "";
		 restartText.text = "";
		 gameOverText.text = "";
		 highScoreText.text = ""; 
	    score = 0;
       UpdateScore (); 
	//	 StartCoroutine (StartGame ());
       StartCoroutine (SpawnWaves ());
		 StartCoroutine (SpawnPowerUpWaves ());
		 StartCoroutine (SpawnPowerUpWaves1());
	}

   void Update ()
	{
      if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves()
	{
	   yield return new WaitForSeconds (startWait);
	   while (true)
	   {	
		  for(int i = 0; i < hazardCount; i++)
		  {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(hazard, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWait);
		  }
		   yield return new WaitForSeconds (waveWait);

			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
	   }
	}

	IEnumerator SpawnPowerUpWaves()
	{
	   yield return new WaitForSeconds (startWaitPU);
	   while (true)
	   {	
		  for(int i = 0; i < PowerUpCounts; i++)
		  {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(PowerUp, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWaitPU);
		   }
		   yield return new WaitForSeconds (waveWaitPU);

			if (gameOver)
			{
				break;
			}
	   }
	}

	IEnumerator SpawnPowerUpWaves1()
	{
	   yield return new WaitForSeconds (startWaitPU1);
	   while (true)
	   {	
		  for(int i = 0; i < PowerUpCounts1; i++)
		  {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(PowerUp1, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWaitPU1);
		   }
		   yield return new WaitForSeconds (waveWaitPU1);

			if (gameOver)
			{
				break;
			}
	   }
	}

  /*  IEnumerator StartGame(){
         
			int i = 3;
			while (i > 0){
				timerText.text = ""+i;
				yield return new WaitForSeconds(1);
				i = i - 1;
			}
			yield return new WaitForSeconds(1);
			timerTextObj.SetActive(false);
	} */

   public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score; 
	}

	public void GameOver(){
		gameOverText.text = "Game Over!";
		gameOver = true;

      if (!PlayerPrefs.HasKey("highScore")) {
			PlayerPrefs.SetInt ("highScore",score);
		}
		else
		{
			int currentHighScore = PlayerPrefs.GetInt ("highScore");
			if (score > currentHighScore){
				PlayerPrefs.SetInt ("highScore", score);
			}
		}

		highScoreText.text = "High Score :" + PlayerPrefs.GetInt("highScore");
		//PlayerPrefs.DeleteKey("HighScore");
	}
}
