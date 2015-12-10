using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Display : MonoBehaviour {
	public static GameObject cardDisplay;
	public static Image CardOverlay;
	public static Image currentImage;
	public static Text currentTitle;
	public static Text currentDescription;
	public static bool showCard;
	
	public void RefStart() {
		cardDisplay = GameController.control.cardDisplay;
		currentImage = cardDisplay.transform.GetChild(0).GetComponent<Image>();
		currentTitle = cardDisplay.transform.GetChild(1).GetComponent<Text>();
		currentDescription = cardDisplay.transform.GetChild(2).GetComponent<Text>();
	}
	
	public void SetActive(bool val) {
		cardDisplay.SetActive(val);
	}
		
	public void updateCard(Sprite currentSprite, string currentCardTitle, string currentCardDescription) {
		currentImage.sprite = currentSprite;
		currentTitle.text = currentCardTitle;
		currentDescription.text = currentCardDescription;
	}
}
