public static class SceneManager
{
    private static Dictionary<string, BaseScene> sceneDic = new();

    public static void Register<T>(string name) where T : BaseScene, new()
    {
        if (!sceneDic.ContainsKey(name))
            sceneDic[name] = new T(); // Register 시점에 한 번 생성
    }

    public static void Load(string name)
    {
        if (sceneDic.TryGetValue(name, out var scene))
        {
            scene.Display();
        }
        else
        {
            Console.WriteLine($"{name}씬 Register 필요");
        }
    }
}