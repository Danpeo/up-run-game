using Random = UnityEngine.Random;

namespace Utils
{
    public static class RandomExtension
    {
        public static bool RandomBool()
        {
            var randomIntValue = Random.Range(0, 2);

            return randomIntValue == 1;
        }
    }
}
