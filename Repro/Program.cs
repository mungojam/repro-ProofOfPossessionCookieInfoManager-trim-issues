using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.Networking.WinInet;

var uri = "https://dummy.internal";

var provider = (IProofOfPossessionCookieInfoManager)new ProofOfPossessionCookieInfoManager();

unsafe
{
    fixed (char* pMessage = uri)
    {
        var uriPointer = new PCWSTR(pMessage);
        ProofOfPossessionCookieInfo* cookieInfoPtr = null;
        provider.GetCookieInfoForUri(uriPointer, out var cookieInfoCount, &cookieInfoPtr);

        Marshal.FreeCoTaskMem((nint)cookieInfoPtr);

        Console.WriteLine($"cookieInfoCount: {cookieInfoCount}");
    }
}