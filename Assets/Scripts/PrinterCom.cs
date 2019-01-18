using UnityEngine;
using CustomPrinter;

public class PrinterCom : MonoBehaviour {
    [SerializeField]
    private Port port;

    private void Awake() {
#if UNITY_EDITOR
        Printer.Init();
#elif UNITY_STANDALONE_WIN && !UNITY_EDITOR //this would be UNITY_PRINTER
        Printer.Init(port);
#endif
    }
}
