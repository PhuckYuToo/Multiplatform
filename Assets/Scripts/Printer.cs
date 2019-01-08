using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Facade class
public class Printer : MonoBehaviour {
	private PrintData printableData = new PrintData(42);

	public enum Port {
		COM1,
		COM2,
		COM3,
		COM4,
		COM5,
		COM6,
		COM7
	}
	public Port port;

	/** Assigning of the specific printer */
	private IPrintable printer = new IAdafruitPrinter();

	public static IPrintable DEFAULT_PRINTER = new IDebugPrinter();

	void Awake () {
		if(!printer.Assign(port)) printer = DEFAULT_PRINTER;

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

	public void Print(PrintData pd) {
		if(printer.IsDone()) printer.Print(pd);
		else Debug.LogError("Print not done yet!");
	}
}
