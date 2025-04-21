using System.Runtime.InteropServices;
using Windows.Win32.Networking.WinInet;

var uri = "https://dummy.internal";

var provider = new IProofOfPossessionCookieInfoManager();

unsafe
{
    ProofOfPossessionCookieInfo* cookieInfoPtr = null;
    provider.GetCookieInfoForUri(uri, out var cookieInfoCount, &cookieInfoPtr);

    Marshal.FreeCoTaskMem((nint)cookieInfoPtr);

    Console.WriteLine($"cookieInfoCount: {cookieInfoCount}");
}