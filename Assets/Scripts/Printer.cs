public enum Port {
    COM1,
    COM2,
    COM3,
    COM4,
    COM5,
    COM6,
    COM7,
    COM11
}

public static class Printer {
    private static IPrintable printer;

    public static void Init() {
        printer = new DebugPrinter();
    }

	public static void Init(Port port) {
        printer = new AdafruitPrinter();
        printer.Assign(port);
	}
	
	public static void Print(PrintData pd) {
		printer.Print(pd);
	}
}