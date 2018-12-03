using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAdafruitPrinter : IPrintable {
	public void Print(PrintData pd) {
		Debug.Log("Bavianenvoer");
	}

	public bool IsDone() {
		return true;
	}
}
