using System.Text.Json;
using System.Text.RegularExpressions;

namespace Nubimetrics.DataAccess.Helpers
{
    internal class UpperCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            Regex rx = new Regex(@"([A-Z])");
            string result = rx.Replace(name, new MatchEvaluator(CapText));
            return result;
        }

        static string CapText(Match m)
        {
            string x = m.ToString();
            return m.Index == 0 ? char.ToLower(x[0]).ToString() : $"_{char.ToLower(x[0])}";
        }
    }
}
