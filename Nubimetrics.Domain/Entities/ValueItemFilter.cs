namespace Nubimetrics.Domain.Entities
{
    public class ValueItemFilter :Entity<string>
    {
        public string Name { get; set; }
        public int Results { get; set; }

        public ValueItemFilter():base(null)
        {

        }
    }
}
