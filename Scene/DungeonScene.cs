using System.Text;


public class DungeonScene : BaseScene
{
    Dictionary<int, Action> menu = new()
    {
        { 0,() => SceneManager.Load(Global.ScenePath.MAIN_SCENE) },
    };
    public override void Display()
    {
        while (true)
        {
            Console.Clear();
            Console.Write(GetStringBuilding());

            HandleMenu(menu);
        }
    }

    public override string GetStringBuilding()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("던전입장");
        sb.AppendLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
        sb.AppendLine("");
        for (int i = 0; i < DataManager.Instance.DungeonData.Count; i++)
        {
            Dungeon? data = DataManager.Instance.DungeonData[i];
            sb.AppendLine($"{i+1}.{data.Name} | {data.LocallizeType(data.OptionType)} {data.OptionValue} 이상 권장");
        }
        sb.AppendLine("0.나가기\n");
        
        return sb.ToString();
    }
}

