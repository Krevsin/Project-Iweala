using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

	public static DialogueSystem Instance { get; set;}
	public string npcName;
	public GameObject dialoguePanel;
	public List<string> dialogueLines = new List<string> ();

	Button continueButton;
	Text dialogueText, nameText;
	int dialogueIndex;

	void Awake () {
		continueButton = dialoguePanel.transform.FindChild ("Continue").GetComponent<Button>();
		dialogueText = dialoguePanel.transform.FindChild ("Text").GetComponent<Text>();
		nameText = dialoguePanel.transform.FindChild ("Name").GetChild (0).GetComponent<Text> ();

		continueButton.onClick.AddListener (delegate { ContinueDialogue(); });

		dialoguePanel.SetActive (false);

		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		} 
		else {
			Instance = this;
		}
	
	}

	void Update(){
		if (Input.GetMouseButtonDown (0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ()) {
			dialoguePanel.SetActive (false);
			dialogueIndex = 0;
		}
	}

	
	public void AddNewDialogue(string[] lines, string npcName){
		dialogueLines = new List<string> (lines.Length);
		dialogueLines.AddRange (lines);

		this.npcName = npcName;

		CreateDialogue ();
	}

	public void CreateDialogue(){
		dialogueText.text = dialogueLines [dialogueIndex];
		nameText.text = npcName;
		dialoguePanel.SetActive (true);
	}


	public void ContinueDialogue(){
		
		if (dialogueIndex < dialogueLines.Count - 1) {
			dialogueIndex++;
			dialogueText.text = dialogueLines [dialogueIndex];
		} 
		else {
			dialoguePanel.SetActive (false);
			dialogueIndex = 0;
		}

	}

}
