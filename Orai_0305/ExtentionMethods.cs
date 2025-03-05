namespace Orai_0305
{
    internal static class ExtentionMethods
    {
        public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
        {
            foreach (T item in values)
            {
                action(item);
            }
        }
    }
}
