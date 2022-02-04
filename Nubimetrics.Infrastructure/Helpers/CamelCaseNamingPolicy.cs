using System.Text.Json;
using System.Text.RegularExpressions;

namespace Nubimetrics.Infrastructure.Helpers
{
    internal class CamelCaseNamingPolicy : JsonNamingPolicy
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
            //If is the first latter just trasform to upper case if not adds underscore and transform to uppercase
            return m.Index == 0 ? char.ToLower(x[0]).ToString() : $"_{char.ToLower(x[0])}";
        }
    }
}
