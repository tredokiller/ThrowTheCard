using UnityEngine;

namespace Common
{
    public static class Randomizer
    {
        public static bool GetRandomBool()
        {
            return Random.Range(0, 2) == 0;
        }

        public static int GetRandomIndexFromArray(int arrayLength)
        {
            return Random.Range(0, arrayLength);
        }
        
    }
    
    
}
