using System.Text.Json;

namespace Nubimetrics.Infrastructure.Helpers
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object target)
        {
            return JsonSerializer.Serialize(target);
        }
    }
}
