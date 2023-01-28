namespace ConfigureYourOwnWardrobe
{
    public class Combination
    {
        private Combination()
        {
        }

        public static Combination Of(params Part[] parts) => new()
        {
            Parts = parts,
        };

        public IEnumerable<Part> Parts { get; set; }
    }
}