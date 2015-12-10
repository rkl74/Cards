using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardHoverDisplay : MonoBehaviour, IPointerEnterHandler{	
	public void OnPointerEnter(PointerEventData eventData) {
		if (eventData.pointerEnter.CompareTag("Card")) {
			Debug.Log("Entered: Card");
			GameObject hovered = eventData.pointerEnter.gameObject;
			Sprite currentImage = hovered.transform.GetChild(0).GetComponent<Image>().sprite;
			string currentCardTitle = hovered.transform.GetChild(1).GetComponent<Text>().text;
			string currentCardDescription = hovered.transform.GetChild(2).GetComponent<Text>().text;
			Display Enlarged = GameController.control.cardDisplay.GetComponent<Display>();
			if (!Display.showCard) {
				Display.showCard = true;
				Enlarged.RefStart();
			}
			Enlarged.SetActive(true);
			Enlarged.updateCard(currentImage, currentCardTitle, currentCardDescription);
		}
	}
}
