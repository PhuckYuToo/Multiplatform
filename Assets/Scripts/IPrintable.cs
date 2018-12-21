using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public interface IPrintable {
	void Print(PrintData pd);
	bool IsDone();
}

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

public class IAdafruitPrinter : IPrintable {
	private SerialPort stream;

	public IAdafruitPrinter() {
		stream = new SerialPort("COM3", 19200);
		stream.ReadTimeout = 50;
		stream.Open();
	}

	public void Print(PrintData pd) {
		foreach(string i in pd.GetData()) {
			stream.WriteLine(i);
			stream.BaseStream.Flush();
		}
	}

	public bool IsDone() {
		return true;
	}
}
