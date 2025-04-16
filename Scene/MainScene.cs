using System.Text;

public class MainScene : BaseScene
{
    Dictionary<int, Action> menu = new()
    {
        { 1,() => SceneManager.Load(Global.ScenePath.STATUS_SCENE) },
        { 2,() => SceneManager.Load(Global.ScenePath.INVENTORY_SCENE) },
        { 3,() => SceneManager.Load(Global.ScenePath.SHOP_SCENE) },
        { 4,() => SceneManager.Load(Global.ScenePath.DUNGEON_SCENE) },
        { 5,() => SceneManager.Load(Global.ScenePath.REST_SCENE) },
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

        sb.AppendLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
        sb.AppendLine("1. 상태 보기");
        sb.AppendLine("2. 인벤토리");
        sb.AppendLine("3. 상점");
        sb.AppendLine("4. 던전 입장");
        sb.AppendLine("5. 휴식하기\n");

        return sb.ToString();
    }
}