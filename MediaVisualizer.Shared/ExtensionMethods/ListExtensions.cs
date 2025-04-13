namespace MediaVisualizer.Shared.ExtensionMethods;

public static class ListExtensions
{
    public static T GetRandomItem<T>(this List<T> list) where T : class
    {
        if (list == null || list.Count == 0) return null;

        var random = new Random();
        var index = random.Next(0, list.Count);
        return list[index];
    }

    public static string GetRandomItem(this string[] list)
    {
        if (list == null || list.Length == 0) return null;

        var random = new Random();
        var index = random.Next(0, list.Length);
        return list[index];
    }
}