using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.Networking.WinInet;

var uri = "https://dummy.internal";

var provider = new IProofOfPossessionCookieInfoManager();

unsafe
{
    var cookieInfoPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf<ProofOfPossessionCookieInfo>());
    uint cookieInfoCount = 0;

    fixed (char* pMessage = uri)
    {
        var uriPointer = new PCWSTR(pMessage);

        provider.GetCookieInfoForUri(uriPointer, &cookieInfoCount, (ProofOfPossessionCookieInfo**)cookieInfoPtr);
    }

    Marshal.FreeCoTaskMem(cookieInfoPtr);

    Console.WriteLine($"cookieInfoCount: {cookieInfoCount}");
}