using System.Text.Json;

namespace Nubimetrics.Infrastructure.Helpers
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object target)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            return JsonSerializer.Serialize(target, options);
        }
    }
}
