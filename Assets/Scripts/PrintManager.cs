using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PrintManager {
	
	//The printer being used
	private IPrintable printer = new IDebugPrinter();
	
	public void Print(PrintData pd) {
		if(printer.IsDone()) printer.Print(pd);
		else Debug.LogError("Print not done yet!");
	}
}
