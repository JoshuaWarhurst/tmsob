using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    public Text agamebyText;
    public int level;

    int n;
    string script;

    void Awake()
    {
        n = Random.Range(0, 23);
        switch (n)
        {
            case 0:
                script = "a game by Joshua Warhurst";
                break;
            case 1:
                script = "a game by Joshua William Charles Warhurst";
                break;
            case 2:
                script = "a game by J.W.C. Warhurst";
                break;
            case 3:
                script = "a game by Bill Chuck";
                break;
            case 4:
                script = "a game by @joshua_warhurst";
                break;
            case 5:
                script = "an interactive piece of fiction by Joshua Warhurst";
                break;
            case 6:
                script = "something by somebody";
                break;
            case 7:
                script = "a game by someone who likes games";
                break;
            case 8:
                script = "a Joshua Warhurst game";
                break;
            case 9:
                script = "a piece of software by Joshua Warhurst";
                break;
            case 10:
                script = "a game, or perhaps an experience";
                break;
            case 11:
                script = "a collection of data by a collection of cells";
                break;
            case 12:
                script = "lots of atoms by lots of atoms";
                break;
            case 13:
                script = "a product by a producer";
                break;
            case 14:
                script = "\"Balls to the Wall\", an expressionist piece, by the beloved J.W.C. Warhurst";
                break;
            case 15:
                script = "has the game started yet?";
                break;
            case 16:
                script = "UPPERCASE LETTERS by lowercase letters";
                break;
            case 17:
                script = "Based on a true story about a person who left\n their home to venture out into the world but\n learned that everything they thought to be true \nwas wrong.";
                break;
            case 18:
                script = "a humble lie by a horrible truth";
                break;
            case 19:
                script = "a pretentious work of art by an insufferable artist";
                break;
            case 20:
                script = "A complete sentence with proper capitalization.";
                break;
            case 21:
                script = "a game by a newt who got better";
                break;
			case 22:
				script = "probably something an asshole made";
				break;
			case 23:
				script = "Josh made this";
				break;
        }
        agamebyText.text = script;
    }

    IEnumerator Start()
    {
        agamebyText.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(level);
    }

    void FadeIn()
    {
        agamebyText.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        agamebyText.CrossFadeAlpha(0.0f, 2.5f, false);
    }

}
