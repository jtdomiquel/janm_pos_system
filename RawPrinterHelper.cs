using System;
using System.Runtime.InteropServices;

public class RawPrinterHelper
{
    [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true)]
    public static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

    [DllImport("winspool.Drv", SetLastError = true)]
    public static extern bool ClosePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", SetLastError = true, EntryPoint = "StartDocPrinterA")]
    public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In] ref DOCINFOA di);

    [DllImport("winspool.Drv", SetLastError = true)]
    public static extern bool EndDocPrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", SetLastError = true)]
    public static extern bool StartPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", SetLastError = true)]
    public static extern bool EndPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", SetLastError = true)]
    public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

    [StructLayout(LayoutKind.Sequential)]
    public struct DOCINFOA
    {
        [MarshalAs(UnmanagedType.LPStr)] public string pDocName;
        [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile;
        [MarshalAs(UnmanagedType.LPStr)] public string pDataType;
    }

    public static bool SendBytesToPrinter(string printerName, byte[] bytes, int count)
    {
        IntPtr hPrinter;
        DOCINFOA di = new DOCINFOA();
        di.pDocName = "OpenCashDrawer";
        di.pDataType = "RAW";

        if (OpenPrinter(printerName.Normalize(), out hPrinter, IntPtr.Zero))
        {
            if (StartDocPrinter(hPrinter, 1, ref di))
            {
                if (StartPagePrinter(hPrinter))
                {
                    IntPtr pUnmanagedBytes = Marshal.AllocCoTaskMem(count);
                    Marshal.Copy(bytes, 0, pUnmanagedBytes, count);
                    WritePrinter(hPrinter, pUnmanagedBytes, count, out _);
                    Marshal.FreeCoTaskMem(pUnmanagedBytes);
                    EndPagePrinter(hPrinter);
                    EndDocPrinter(hPrinter);
                }
            }
            ClosePrinter(hPrinter);
            return true;
        }
        return false;
    }
}
