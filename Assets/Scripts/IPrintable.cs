using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPrintable {
	void Print(PrintData pd);
	bool IsDone();
}
