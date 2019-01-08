using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public interface IPrintable {
	void Print(PrintData pd);
	bool IsDone();
	bool Assign(Printer.Port port);
}

public class IDebugPrinter : IPrintable {
	public bool Assign(Printer.Port port) {return true;}

	public void Print(PrintData pd) {
		string fin = "";
		for(int i = 0; i < pd.GetData().Count; ++i) fin += (i < pd.GetData().Count - 1) ? (pd.GetData()[i] + ", ") : (pd.GetData()[i]);
		Debug.Log(fin); 
	}

	public bool IsDone() {
		return true;
	}
}

public class IAdafruitPrinter : IPrintable {
	private SerialPort stream;

	public  bool Assign(Printer.Port port) {
		bool succes = false;
		stream = new SerialPort(port.ToString(), 19200);
		stream.ReadTimeout = 50;
		try {
			stream.Open();
			succes = true;
		} catch(System.IO.IOException) {
			Debug.LogWarning("Couldn't find printer on port " + port.ToString() + ", assigning default Debug Printer instead!");
			succes = false;
		}
		return succes;
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
