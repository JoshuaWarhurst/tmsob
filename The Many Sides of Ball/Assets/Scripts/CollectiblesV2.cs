using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectiblesV2 : MonoBehaviour {

	public string areaName;

	[HideInInspector]
	public int hardCount;
	public int maxHC;

	[System.Serializable]
	public class TextUI
	{
		public Text areaNameText;
		public Text timer;

//		public Text hardName;
		public Text hardAmount;
//        public CanvasGroup hardPopupImage;
//        public Text hardPopupAmount;
	}

	private float time;
	private float minutes;
	private float seconds;
	private float totalGameTime;

	[HideInInspector]
    public COLLECTIBLE collectible;
//    private bool flashPickupUI = false;

	public TextUI textUI = new TextUI ();

	void Update()
	{
        //updates the timer always
		time += Time.deltaTime;

		minutes = time / 60; //divide the GUITime by 60 to get the minutes
		seconds = time % 60; //use the euclidean division for the seconds
	}

	public void SetPauseMenuText()
	{
		textUI.timer.text = "Time: " + string.Format ("{0:00} : {1:00}", minutes, seconds);
		textUI.areaNameText.text = areaName.ToString ();
		textUI.hardAmount.text = hardCount.ToString() + " / " + maxHC.ToString();

		if (hardCount == maxHC) 
		{
			textUI.hardAmount.color = Color.yellow;
//			textUI.hardName.color = Color.yellow;
		}
	}


        //makes the top-right UI pickup icon appear
/*	if (flashPickupUI)
        {
            switch (collectible)
            {
                case COLLECTIBLE.NONE:
                    break;
                case COLLECTIBLE.JOURNEY_PICKUP:
                    textUI.journeyPopupImage.alpha = textUI.journeyPopupImage.alpha - (Time.deltaTime / 2);
                    if (textUI.journeyPopupImage.alpha <= 0)
                    {
                        textUI.journeyPopupImage.alpha = 0;
                        flashPickupUI = false;
                        collectible = COLLECTIBLE.NONE;
                    }
                    break;
                case COLLECTIBLE.ODD_PICKUP:
                    textUI.oddPopupImage.alpha = textUI.oddPopupImage.alpha - (Time.deltaTime / 2);
                    if (textUI.oddPopupImage.alpha <= 0)
                    {
                        textUI.oddPopupImage.alpha = 0;
                        flashPickupUI = false;
                        collectible = COLLECTIBLE.NONE;
                    }
                    break;
                case COLLECTIBLE.SPEED_PICKUP:
                    textUI.speedPopupImage.alpha = textUI.speedPopupImage.alpha - (Time.deltaTime / 2);
                    if (textUI.speedPopupImage.alpha <= 0)
                    {
                        textUI.speedPopupImage.alpha = 0;
                        flashPickupUI = false;
                        collectible = COLLECTIBLE.NONE;
                    }
                    break;
                case COLLECTIBLE.HARD_PICKUP:
                    textUI.hardPopupImage.alpha = textUI.hardPopupImage.alpha - (Time.deltaTime / 2);
                    if (textUI.hardPopupImage.alpha <= 0)
                    {
                        textUI.hardPopupImage.alpha = 0;
                        flashPickupUI = false;
                        collectible = COLLECTIBLE.NONE;
                    }
                    break;
            }
        }
    }

    public void CollectionPopup()
    {
        SetPopupText();
        switch (collectible)
        {
            case COLLECTIBLE.NONE:
                break;
            case COLLECTIBLE.JOURNEY_PICKUP:
                textUI.journeyPopupImage.alpha = 1;
                break;
            case COLLECTIBLE.ODD_PICKUP:
                textUI.oddPopupImage.alpha = 1;
                break;
            case COLLECTIBLE.SPEED_PICKUP:
                textUI.speedPopupImage.alpha = 1;
                break;
            case COLLECTIBLE.HARD_PICKUP:
                textUI.hardPopupImage.alpha = 1;
                break;
        }
        flashPickupUI = true;
    }

    void SetPopupText()
    {
        textUI.journeyPopupAmount.text = journeyCount.ToString() + " / " + maxJC.ToString();
        textUI.oddPopupAmount.text = oddCount.ToString() + " / " + maxOC.ToString();
        textUI.speedPopupAmount.text = speedCount.ToString() + " / " + maxSC.ToString();
        textUI.hardPopupAmount.text = hardCount.ToString() + " / " + maxHC.ToString();
    }
*/

}