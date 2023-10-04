using System;

namespace ProvaPub.Services
{
    public class RandomService
    {
        public int GetRandom()
        {
            int seed = Guid.NewGuid().GetHashCode();
            return new Random(seed).Next(100);
        }
    }
}
