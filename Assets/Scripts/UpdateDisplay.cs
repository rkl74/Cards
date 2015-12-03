using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateDisplay : MonoBehaviour {	

	public GameObject display;
	public Image CardOverlay;
	public Image currentImage;
	public Text currentTitle;
	public Text currentDescription;
	public bool showCard = false;
	
	void Start() {
		currentImage = display.transform.GetChild(0).GetComponent<Image>();
		currentTitle = display.transform.GetChild(1).GetComponent<Text>();
		currentDescription = display.transform.GetChild(2).GetComponent<Text>();
		Debug.Log(currentTitle.text);
		Debug.Log(currentDescription.text);
	}
	
	 public void SetActive() {
		display.SetActive(true);
		showCard = true;
	}
	
	public void updateCard() {
		currentImage.sprite = CardHoverDisplay.currentImage.sprite;
		currentTitle.text = CardHoverDisplay.currentCardTitle.text;
		currentDescription.text = CardHoverDisplay.currentCardDescription.text;		
	}
}
