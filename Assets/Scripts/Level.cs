using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
	public int[][] level;

	public PrintManager printManager;

	private PrintData printableData = new PrintData(42);

	void Awake () {
		printManager = new PrintManager();

		printableData.Append("Wessel");
		for(int i = 0; i < 5; i++) printableData.Append(i * 6023);
		printableData.Append(new float[]{0.5f, -1.11f, 6.32f});
	
		List<char> edwin = new List<char>();
		edwin.Add('c');
		edwin.Add('+');
		edwin.Add('+');
		edwin.Add(' ');
		edwin.Add(':');
		edwin.Add('D');
		printableData.Append(edwin);
	}
	
	void Update () {
		//if(Input.GetKeyUp(KeyCode.Space)) printManager.Print(printableData);
	}
}
