using System.Text;

public class ShopScene : BaseScene
{
    Dictionary<int, Action> menu = new()
    {
        { 1,() => SceneManager.Load(Global.ScenePath.BUY_SCENE) },
        { 2,() => SceneManager.Load(Global.ScenePath.SELL_SCENE) },
        { 0,() => SceneManager.Load(Global.ScenePath.MAIN_SCENE) },
    };
    public override void Display()
    {
        Character hero = Program.GetHero();
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

        sb.AppendLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.");
        sb.AppendLine($"[보유 골드]\n {Program.GetHero().Gold} G\n\n");
        sb.Append(Shop.ShowList());
        sb.AppendLine("1. 아이템 구매");
        sb.AppendLine("2. 아이템 판매");
        sb.AppendLine("0. 나가기\n\n");
        return sb.ToString();
    }
}