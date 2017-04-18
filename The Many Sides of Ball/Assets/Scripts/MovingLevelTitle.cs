using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingLevelTitle : MonoBehaviour {

    public string chapter_key;
    public string part_key;
    public string title_key;
    public TextMesh textMesh;

    float moveX = 0f;
    float moveY = 0f;
    float moveZ = -1f;

    public bool autoDisappear = false;
    public float disappearTime = 100f;
    private float textDisappear = 0f;

    GAME_TYPE gameType = GAME_TYPE.SIDE_VIEW;

    void Start()
    {
        TextMesh textMesh = GetComponent<TextMesh>();
        textDisappear = disappearTime;

        #region set Camera Type based on level
        if (SceneManager.GetActiveScene().name == "L1_1")
        {
            gameType = GAME_TYPE.SIDE_VIEW;
            chapter_key = "C1";
            part_key = "P1";
            title_key = "T11";
        }
        if (SceneManager.GetActiveScene().name == "L1_2")
        {
            gameType = GAME_TYPE.TOP_DOWN;
            chapter_key = "C1";
            part_key = "P2";
            title_key = "T12";
        }
        if (SceneManager.GetActiveScene().name == "L1_3")
        {
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
            chapter_key = "C1";
            part_key = "P3";
            title_key = "T13";
        }
        if (SceneManager.GetActiveScene().name == "L2_1")
        {
            gameType = GAME_TYPE.SIDE_VIEW;
            chapter_key = "C2";
            part_key = "P1";
            title_key = "T21";
        }
        if (SceneManager.GetActiveScene().name == "L2_2")
        {
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
            chapter_key = "C2";
            part_key = "P2";
            title_key = "T22";
        }
        if (SceneManager.GetActiveScene().name == "L2_3")
        {
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
            chapter_key = "C2";
            part_key = "P3";
            title_key = "T23";
        }
        if (SceneManager.GetActiveScene().name == "L3_1")
        {
            gameType = GAME_TYPE.TOP_DOWN;
            chapter_key = "C3";
            part_key = "P1";
            title_key = "T31";
        }
        if (SceneManager.GetActiveScene().name == "L3_2")
        {
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
            chapter_key = "C3";
            part_key = "P2";
            title_key = "T32";
        }
        if (SceneManager.GetActiveScene().name == "L3_3")
        {
            gameType = GAME_TYPE.SIDE_VIEW;
            chapter_key = "C3";
            part_key = "P3";
            title_key = "T33";
        }
        if (SceneManager.GetActiveScene().name == "L4_1")
        {
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
            chapter_key = "C4";
            part_key = "P1";
            title_key = "T41";
        }
        if (SceneManager.GetActiveScene().name == "L4_2")
        {
            gameType = GAME_TYPE.TOP_DOWN;
            chapter_key = "C4";
            part_key = "P2";
            title_key = "T42";
        }
        if (SceneManager.GetActiveScene().name == "L5_1")
        {
            gameType = GAME_TYPE.SIDE_VIEW;
            chapter_key = "C5";
            part_key = "P1";
            title_key = "T51";
        }
        if (SceneManager.GetActiveScene().name == "L5_2")
        {
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
            chapter_key = "C5";
            part_key = "P2";
            title_key = "T52";
        }
        if (SceneManager.GetActiveScene().name == "L5_3")
        {
            gameType = GAME_TYPE.SIDE_VIEW;
            chapter_key = "C5";
            part_key = "P4";
            title_key = "T53";
        }
        //no title card for 5_4, but putting it here anyways
        if (SceneManager.GetActiveScene().name == "L5_4")
        {
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
            chapter_key = "C5";
            part_key = "P4";
            title_key = "T54";
        }
        if (SceneManager.GetActiveScene().name == "L6_1")
        {
            gameType = GAME_TYPE.SIDE_VIEW;
            chapter_key = "C6";
            part_key = "P1";
            title_key = "T61";
        }
        if (SceneManager.GetActiveScene().name == "L6_2")
        {
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
            chapter_key = "C6";
            part_key = "P2";
            title_key = "T62";
        }
        //no title card for 6_3, but putting it here anyways
        if (SceneManager.GetActiveScene().name == "L6_3")
        {
            gameType = GAME_TYPE.SIDE_VIEW;
            chapter_key = "C6";
            part_key = "P3";
            title_key = "T63";
        }
        if (SceneManager.GetActiveScene().name == "L6_4")
        {
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
            chapter_key = "C6";
            part_key = "P3";
            title_key = "T63";
        }
        if (SceneManager.GetActiveScene().name == "Epilogue")
        {
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
            chapter_key = "C7";
            part_key = "P1";
            title_key = "T71";
        }

        //changes to object position and rotation dependant on level type
        if (gameType == GAME_TYPE.SIDE_VIEW)
        {
            transform.position = new Vector3(0, 5, 10);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (gameType == GAME_TYPE.TOP_DOWN)
        {
            moveZ = -3f;
            transform.position = new Vector3(0, 50, 10);
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        if (gameType == GAME_TYPE.THIRD_PERSON_FOLLOW)
        {
            transform.position = new Vector3(0, 0, 20);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        #endregion
    }

    void Update()
    {
        textMesh.text = LocalizationManager.instance.GetLocalizedValue(chapter_key) 
            + "\n" + LocalizationManager.instance.GetLocalizedValue(part_key) 
            + "\n" + LocalizationManager.instance.GetLocalizedValue(title_key);

        this.transform.Translate(Vector3.right * moveX * Time.deltaTime);
        this.transform.Translate(Vector3.up * moveY * Time.deltaTime);
        this.transform.Translate(Vector3.forward * moveZ * Time.deltaTime);

        if (autoDisappear)
        {
            disappearTime -= Time.deltaTime;
            moveY += Time.deltaTime;
            if (disappearTime <= 0)
            {
                Destroy(gameObject);
            }
            if (GetComponent<TextMesh>().fontSize > 0)
            {
                FontShrink();
            }
        }
    }

    IEnumerator FontShrink()
    {
        yield return new WaitForSeconds(1);
        GetComponent<TextMesh>().fontSize -= 1;
    }
}
