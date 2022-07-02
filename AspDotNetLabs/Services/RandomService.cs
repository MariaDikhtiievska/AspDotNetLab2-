namespace AspDotNetLabs.Services
{
    public class RandomService
    {
        private readonly Random random;
        private readonly int value;

        public RandomService()
        {
            random = new Random();
            value = random.Next(0, 1000000);
        }
        public int Value
        {
            get { return value; }
        }

    }
}
