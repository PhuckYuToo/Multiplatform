using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Facade Pattern
public class PrintManager {

	private IPrintable printer = new IAdafruitPrinter();
	
	public void Print(PrintData pd) {
		if(printer.IsDone()) printer.Print(pd);
		else Debug.LogError("Print not done yet!");
	}
}
