using System.IO.Ports;
using UnityEngine;

public class AdafruitPrinter : IPrintable {
    private SerialPort stream;
    private const int baudRate = 19200;

    public void Assign(Port port) {
        string[] portNums = System.Text.RegularExpressions.Regex.Split(port.ToString(), @"\D+");
        stream = (int.Parse(portNums[1]) >= 10) ? new SerialPort("\\\\.\\" + port.ToString(), baudRate) :
                                                  new SerialPort(port.ToString(), baudRate);
        stream.ReadTimeout = 50;
        try { stream.Open(); }
        catch {  Debug.LogWarning("Couldn't find printer on port " + port.ToString() + ", assigning default Debug Printer instead!"); }
    }

    public void Print(PrintData pd) {
        foreach (string i in pd.GetData()) {
            stream.WriteLine(i);
            stream.BaseStream.Flush();
        }
    }
}