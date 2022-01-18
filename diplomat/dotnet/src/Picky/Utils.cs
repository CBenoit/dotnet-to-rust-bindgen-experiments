using System.Text;

namespace Devolutions.Picky;

public static class Utils
{
    public static byte[] StringToUtf8(string s)
    {
        int size = Encoding.UTF8.GetByteCount(s);
        byte[] buf = new byte[size];
        Encoding.UTF8.GetBytes(s, 0, s.Length, buf, 0);
        return buf;
    }

    public static string Utf8ToString(byte[] utf8)
    {
        char[] chars = new char[utf8.Length];
        Encoding.UTF8.GetChars(utf8, 0, utf8.Length, chars, 0);
        return new string(chars);
    }
}
