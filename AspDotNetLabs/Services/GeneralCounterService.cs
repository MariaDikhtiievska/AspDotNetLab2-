namespace AspDotNetLabs.Services
{
    public class GeneralCounterService
    {
        public int Count { get; private set; }

        public GeneralCounterService()
        {
            Count = 0;
        }

        public void Increment()
        {
            Count++;
        }
    }
}
