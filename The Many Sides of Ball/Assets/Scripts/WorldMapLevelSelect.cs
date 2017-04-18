using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldMapLevelSelect : MonoBehaviour {

    public string levelName;
    public string area_key;
    public string part_key;
    public GameObject levelDisplayUI;
    public Text levelNameText;

    private void Start()
    {
        levelDisplayUI.SetActive(false);
    }

    private void SetLevelText()
    {
        if (part_key != "none")
        {
            levelNameText.text = LocalizationManager.instance.GetLocalizedValue(area_key)
             + "\n" + LocalizationManager.instance.GetLocalizedValue(part_key);
            Debug.Log("Has part");
        }
        else
        {
            levelNameText.text = LocalizationManager.instance.GetLocalizedValue(area_key);
            Debug.Log("Doesn't have part");
        }
    }

    public void LoadScene()
    {
        if (Input.GetButtonDown("Fire1"))
            SceneManager.LoadScene(levelName);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            SetLevelText();
            LoadScene();
            levelDisplayUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            levelDisplayUI.SetActive(false);
        }
    }
}
