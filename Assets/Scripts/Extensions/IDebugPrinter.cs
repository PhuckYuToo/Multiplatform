using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDebugPrinter : IPrintable {
	public void Print(PrintData pd) {
		string fin = "";
		for(int i = 0; i < pd.GetData().Count; ++i) fin += (i < pd.GetData().Count - 1) ? (pd.GetData()[i] + ", ") : (pd.GetData()[i]);
		Debug.Log(fin); 
	}

	public bool IsDone() {
		return Random.Range(0f, 1f) < 0.5f;
	}
}
