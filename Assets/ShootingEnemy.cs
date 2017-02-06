using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy {


	float timeBetweenAttacks = 2f;
	float attackTimer = 0;
	public Transform[] bulletSpawners;

	override protected void attack()
	{
		attackTimer+=Time.deltaTime;
		if(attackTimer>=timeBetweenAttacks)
		{
			spawnBullets();
			attackTimer=0;
		}
	}

	void spawnBullets()
	{
		print("Bullets!!");
		foreach(Transform spawner in bulletSpawners)
		{
			GameObject bulletRef = Resources.Load<GameObject>("Bullets/EnemyBullet1");
			Instantiate(bulletRef,spawner.position,Quaternion.identity);
		}
	}
}
