using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	private Vector2 basePos;
	private float time = 0;

	private Text text;
	private GameObject input;
	private InputField field;

	public Level level;

	void Start () {
		basePos = transform.localPosition;
		text = GetComponent<Text>();
		input = GameObject.Find("InputField");
		field = input.GetComponent<InputField>();
		input.SetActive(false);
	}
	
	void Update () {
		time += Time.deltaTime;
		transform.localPosition = new Vector2(transform.localPosition.x, basePos.y + Mathf.Sin(Time.time * 5) * 4);
	
		if(time > 1.2f && text != null) {
			text.text = "Printer ready!";
			text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(text.color.a, 0, Time.deltaTime * 4));
			if(time > 2.5f) input.SetActive(true);
		}

		if(input.activeSelf && field.text.Length > 0 && Input.GetKeyDown(KeyCode.Return)) {
			level.printManager.Print(new PrintData(field.text));
			field.text = "";
		}
	}
}
