namespace Nubimetrics.Domain.Entities
{
    public class KeyValue:Entity<string>
    {
        public string Name { get; set; }

        public KeyValue():base(null)
        {

        }
    }
}
