using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
	// Audio players components.
	public AudioSource bowShoot;
	public AudioSource fire;
	public AudioSource lifeUp;
	public AudioSource water;
	public AudioSource spells;
	public AudioSource monkey;
	public AudioSource key;
	public AudioSource buttonConf;
	public AudioSource Menu;
	public AudioSource history;
	public AudioSource MusicSourcePrincipal;
	public AudioSource level1Music;
	public AudioSource level2Music;
	public AudioSource level3Music;
	public AudioSource FightMusic;
	public AudioSource BossMusic;
	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;
	// Singleton instance.
	public static SoundManager Instance = null;
	
	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
	}
	// Play a single clip through the sound effects source.
	public void Play(int audio)
	{
		if (audio==1)bowShoot.Play();
		if (audio==2)fire.Play();
		if (audio==3)lifeUp.Play();
		if (audio==4)water.Play();
		if (audio==5)spells.Play();
		if (audio==6)monkey.Play();
		if (audio==7)key.Play();
		if (audio==8)buttonConf.Play();
	}
	// Play a single clip through the music source.

	public void PlayMenu(AudioClip clip)
	{
		Menu.clip = clip;
		MusicSourcePrincipal.Stop();
		level1Music.Stop();
		level2Music.Stop();
		level3Music.Stop();
	}
	public void History(AudioClip clip)
	{
		history.clip = clip;
		Menu.Stop();
		MusicSourcePrincipal.Stop();
		level1Music.Stop();
		level2Music.Stop();
		level3Music.Stop();
	}
	public void PlayMusicPrincipal(AudioClip clip)
	{
		MusicSourcePrincipal.clip = clip;
		MusicSourcePrincipal.Play();
		level1Music.Stop();
		level2Music.Stop();
		level3Music.Stop();
	}
	public void Playlevel1(AudioClip clip)
	{
		level1Music.clip = clip;
		level1Music.Play();
		level2Music.Stop();
		level3Music.Stop();
		MusicSourcePrincipal.Stop();
	}
	public void Playlevel2(AudioClip clip)
	{
		level2Music.clip = clip;
		level2Music.Play();
		level1Music.Stop();
		level3Music.Stop();
		MusicSourcePrincipal.Stop();
	}
	public void Playlevel3(AudioClip clip)
	{
		level3Music.clip = clip;
		level3Music.Play();
		level1Music.Stop();
		level2Music.Stop();
		MusicSourcePrincipal.Stop();
	}
	public void PlayFightMusic(AudioClip clip)
	{
		FightMusic.clip = clip;
		FightMusic.Play();
		level1Music.Stop();
		level2Music.Stop();
		level3Music.Stop();
		BossMusic.Stop();
	}
	public void BossFigth()
	{
		MusicSourcePrincipal.Stop();
		level1Music.Stop();
		level2Music.Stop();
		level3Music.Stop();
		BossMusic.Play();
	}
	public void backToStart()
	{
		BossMusic.Stop();
	}
	// Play a random clip from an array, and randomize the pitch slightly.
	
}