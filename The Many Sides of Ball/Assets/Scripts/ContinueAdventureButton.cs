using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ContinueAdventureButton : MonoBehaviour {

	public void Continue()
	{
		GameControl.control.Load ();
		GameControl.control.IsSceneBeingLoaded = true;

		int whichScene = GameControl.control.SceneID;

		SceneManager.LoadScene (whichScene);
	}
}
