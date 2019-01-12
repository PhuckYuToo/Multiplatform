using UnityEngine;

public class DebugPrinter : IPrintable {
    public void Assign(Port port) { }

    public void Print(PrintData pd) {
        string fin = string.Empty;
        for (int i = 0; i < pd.GetData().Count; ++i) fin += (i < pd.GetData().Count - 1) ? (pd.GetData()[i] + ", ") : (pd.GetData()[i]);
        Debug.Log(fin);
    }
}