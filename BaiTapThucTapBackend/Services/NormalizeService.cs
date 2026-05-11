using System.Text.RegularExpressions;

namespace BaiTapThucTapBackend.Services
{
    public class NormalizeService
    {
        public string Normalize(string text)
        {
            return Regex.Replace(text.Trim(), @"\s+", " ");
        }
    }
}
