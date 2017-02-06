using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName="SoundDatabase", menuName="Sound Database")]
public class SoundDatabase : ScriptableObject
{
    public AudioClip levelMusic;

	//SFX
	//Player
	public AudioClip playerDeath;
	//Bullets
	public AudioClip shootBullet1;
	//Minions

	public AudioClip minionDeath;

}