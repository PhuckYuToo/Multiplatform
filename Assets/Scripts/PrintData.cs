using System.Collections;
using System.Collections.Generic;

public class PrintData {
	protected List<string> data = new List<string>();

    public PrintData() { }
	public PrintData(object input) { ParseData(input); }
	public void Append(object input) { ParseData(input); }
	public List<string> GetData() { return data; }

    private void ParseData(object input) {
        if (input.GetType() == typeof(float[])) {
            float[] it = input as float[];
            for (int i = 0; i < it.Length; ++i) data.Add(it[i].ToString());
            return;
        }
        if (input is IList) {
            IList it = input as IList;
            for (int i = 0; i < it.Count; ++i) data.Add(it[i].ToString());
            return;
        }
        data.Add(input.ToString());
    }

}
