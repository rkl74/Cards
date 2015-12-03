using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardHoverDisplay : MonoBehaviour, IPointerEnterHandler{

	public static GameObject display;
	public static Image currentImage;
	public static Text currentCardTitle;
	public static Text currentCardDescription;
	
	void Start() {
		display = GameObject.Find("Layout");
	}
	
	public void OnPointerEnter(PointerEventData eventData) {
		if (eventData.pointerEnter.CompareTag("Card")) {
			Debug.Log("Entered: Card");
			GameObject hovered = eventData.pointerEnter.gameObject;
			currentImage = hovered.transform.GetChild(0).GetComponent<Image>();
			currentCardTitle = hovered.transform.GetChild(1).GetComponent<Text>();
			currentCardDescription = hovered.transform.GetChild(2).GetComponent<Text>();
			Debug.Log("Current Card: " + currentCardTitle.text);
			Debug.Log("Description: " + currentCardDescription.text);
			display.GetComponent<UpdateDisplay>().SetActive();
			display.GetComponent<UpdateDisplay>().updateCard();
		}
	}
}
