using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	// Use this for initialization
	public float spawnWaveInterval = 0.8f;
	float timer = 0;
	float spawnEnemyTimer = 0;
	public GameObject [] spawners;
	public EnemyWave currentWave;

	void Start () {
		currentWave = createWave();
	}
	
	// Update is called once per frame
	void Update () {
		spawnEnemyTimer+=Time.deltaTime;
		if(spawnEnemyTimer>=currentWave.enemySpawnInterval)
		{
			if(currentWave.size>0)
			{
				GameObject enemyRef;
				if(GameMaster.difficultyPoints>5)
				{
					if(currentWave.size!=1)
					{
						enemyRef =Resources.Load<GameObject>("Enemies/Enemy1");
					}
					else enemyRef =Resources.Load<GameObject>("Enemies/Enemy2");
					
				}
				else enemyRef =Resources.Load<GameObject>("Enemies/Enemy1");
				
				
				Enemy enemy = Instantiate(enemyRef,spawners[currentWave.spawner].transform.position,Quaternion.identity).GetComponent<Enemy>();
				enemy.xAmplitude = currentWave.enemyXAmplitude;
				currentWave.size--;
			}
			else
			{
				currentWave = createWave();
			}
			spawnEnemyTimer=0;
		}
		// if(timer>=spawnWaveInterval)
		// {
		// 	GameObject enemy = Resources.Load<GameObject>("Enemies/Enemy1");
		// 	Instantiate(enemy,this.transform.position,Quaternion.identity);
		// 	timer=0;
		// }
		
	}

	EnemyWave createWave()
	{
		EnemyWave wave = new EnemyWave();
		wave.spawner = Random.Range(0,this.spawners.Length-1);
		wave.size = Random.Range(3,6);
		wave.enemyXAmplitude = Random.Range(1,3);
		wave.enemySpawnInterval = Random.Range(0.2f,.5f);
		return wave;
	}
}


public struct EnemyWave 
{
	public int size;
	public int spawner;
	public float enemySpawnInterval;
	public float enemyXAmplitude;
}
