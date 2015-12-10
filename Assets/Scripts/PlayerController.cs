using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public MyQueue<GameObject> Deck;
	public GameObject Hand;
	public GameObject Graveyard;
	public GameObject ChatWindow;
	public enum DisplayState { Chat, Graveyard }
	public DisplayState CurrentState = DisplayState.Chat;
	public int minDeckSize;
	
	public void startGame() {
		GameObject decklist = GameController.control.DeckSpace;
		if (decklist.transform.childCount < minDeckSize) {
			Debug.Log("Minimum deck size not met!");
			return;
		}
		Deck = new MyQueue<GameObject>(decklist.transform.childCount);
		for (int i = 0; i < decklist.transform.childCount; i++) {
			Deck.Enqueue(decklist.transform.GetChild(i).gameObject);
		}
		Debug.Log("Deck created.");
		GameController.control.DeckSpace.SetActive(false);
		GameController.control.Board.SetActive(true);
	}
	
	public void draw(int num) {
		for (int i = 0; i < num; i++) {
			if (Deck.count > 0) {
				Deck.Dequeue().transform.SetParent(Hand.transform);
				Debug.Log("Added a card to hand");
			}
			else {
				Debug.Log("Deck size is 0. Cannot draw.");
			}
		}
	}

	// Durstenfeld shuffle (based on Fisher-Yates)
	public void shuffle() {
		for (int i = Deck.count-1; i >= 0; i--) {
			int randomNum = Random.Range(0,i);
			GameObject temp = Deck[i];
			Deck[i] = Deck[randomNum];
			Deck[randomNum] = temp;
		}
	}
	
	public void toggleGraveyard() {
		if (CurrentState == DisplayState.Chat) {
			toggleChat();
		}
		GameObject gy = GameController.control.Graveyard;
		if (gy.activeInHierarchy) {
			gy.SetActive(false);
		}
		else {
			gy.SetActive(true);
			CurrentState = DisplayState.Graveyard;
		}
	}
	
	public void toggleChat() {
		if (CurrentState == DisplayState.Graveyard) {
			toggleGraveyard();
		}
		GameObject chat = GameController.control.Chat;
		if (chat.activeInHierarchy) {
			chat.SetActive(false);
		}
		else {
			chat.SetActive(true);
			CurrentState = DisplayState.Chat;
		}
	}
}

public class MyQueue<T> {
	T[] list;
	int front;
	int end;
	public int count;
	int length;
	
	public MyQueue(int size) {
		list = new T[size];
		front = 0;
		count = 0;
		length = size;
	}
	
	public MyQueue(T[] copy) {
		list = copy;
		front = 0;
		count = copy.Length;
		length = copy.Length;
	}
	
	int correctIndex(int i) {
		int adjusted = i + front;
		adjusted %= length;
		return adjusted;
	}
	
	public T this[int i]{
		get {
			if (i >= length || i < 0) {
				return default(T);
			}
			return list[correctIndex(i)];
		}
		set {
			if (!(i >= length || i < 0)) {
				list[correctIndex(i)] = value;
			}
		}
	}
	
	public void Enqueue(T obj) {
		list[front] = obj;
		count++;
		front++;
		front %= length;
	}
	
	public T Dequeue() {
		if (count > 0) {
			T temp = list[front];
			list[front] = default(T);
			front++;
			front %= length;
			return temp;
		}
		else {
			T empty = default(T);
			return empty;
		}
	}
}