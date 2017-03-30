using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicMaster : MonoBehaviour {

    public static MusicMaster musicMaster;

    public AudioSource backgroundMusic;
    public AudioClip mainMenu;
    public AudioClip openingCS;
    public AudioClip level1;
    public AudioClip level2;
    public AudioClip level3;
    public AudioClip level4;
    public AudioClip level5;
    public AudioClip level6;

    private void Awake()
    {
        if (musicMaster == null)
        {
            DontDestroyOnLoad(gameObject);
            musicMaster = this;
        }
        else if (musicMaster != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "_Splash Screen")
            NoMusic();
        if (SceneManager.GetActiveScene().name == "L1_1")
            LoadLevel1();
        if (SceneManager.GetActiveScene().name == "L1_2")
            LoadLevel1();
        if (SceneManager.GetActiveScene().name == "L1_3")
            LoadLevel1();
    }


    private void NoMusic()
    {
        backgroundMusic.Stop();
    }

    private void LoadLevel1()
    {
        if (backgroundMusic.name == "Level1")
            return;
        else
            backgroundMusic.clip = level1;
        backgroundMusic.Play();
    }

}
