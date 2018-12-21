using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PrintData {
	protected List<String> data = new List<String>();

	public PrintData(System.Object input) {
		ParseData(input);
	}

	private void ParseData(System.Object input) {
		//Arrays
		if(input.GetType() == typeof(Single[])) {
			Single[] it = input as Single[];
			for(int i = 0; i < it.Length; ++i) data.Add(it[i].ToString());
			return;
		}
		//Lists
		if(input is IList) {
			IList it = input as IList;
			for(int i = 0; i < it.Count; ++i) data.Add(it[i].ToString());
			return;
		}
		data.Add(input.ToString());
	}

	public void Append(System.Object input) {
		ParseData(input);
	}

	public List<string> GetData() {
		return data;
	}
}
