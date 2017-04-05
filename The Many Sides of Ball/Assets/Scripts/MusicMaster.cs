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
    public AudioClip level2a;
    public AudioClip level2b;
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
//        LoadLevelMusic();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
        LoadLevelMusic();
    }

    void LoadLevelMusic()
    {
        if (SceneManager.GetActiveScene().name == "_Splash Screen")
            NoMusic();
        if (SceneManager.GetActiveScene().name == "Opening 2")
            LoadLevel1();
        if (SceneManager.GetActiveScene().name == "L1_1")
            LoadLevel1();
        if (SceneManager.GetActiveScene().name == "L1_2")
            LoadLevel1();
        if (SceneManager.GetActiveScene().name == "L1_3")
            LoadLevel1();
        if (SceneManager.GetActiveScene().name == "L2_1")
            LoadLevel2a();
        if (SceneManager.GetActiveScene().name == "L2_2")
            LoadLevel2a();
        if (SceneManager.GetActiveScene().name == "L2_3")
            LoadLevel2b();
    }

    private void NoMusic()
    {
        backgroundMusic.Stop();
    }

    private void LoadLevel1()
    {
        if (backgroundMusic.clip != level1)
        {
            backgroundMusic.clip = level1;
            backgroundMusic.Play();
        }
        else
        {
            return;
        }
    }

    private void LoadLevel2a()
    {
        if (backgroundMusic.clip != level2a)
        {
            backgroundMusic.clip = level2a;
            backgroundMusic.Play();
        }
        else
        {
            return;
        }
    }

    private void LoadLevel2b()
    {
        if (backgroundMusic.clip != level2b)
        {
            backgroundMusic.clip = level2b;
            backgroundMusic.Play();
        }
        else
        {
            return;
        }
    }

}
