using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Networking.WinInet;
using Windows.Win32.System.Com;

var uri = "https://dummy.internal";

unsafe
{
    PInvoke.CoCreateInstance<IProofOfPossessionCookieInfoManager>(
        typeof(ProofOfPossessionCookieInfoManager).GUID,
        null,
        CLSCTX.CLSCTX_ALL,
        out var provider);
    
    ProofOfPossessionCookieInfo* cookieInfoPtr = null;
    provider->GetCookieInfoForUri(uri, out var cookieInfoCount, &cookieInfoPtr);
    provider->Release();
    Marshal.FreeCoTaskMem((nint)cookieInfoPtr);

    Console.WriteLine($"cookieInfoCount: {cookieInfoCount}");
}