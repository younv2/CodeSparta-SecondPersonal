using System.Text;

public class SellScene : BaseScene
{
    Dictionary<int, Action> menu = new()
    {
        { 0,() => SceneManager.Load(Global.ScenePath.MAIN_SCENE) },
    };
    public override void Display()
    {
        Character hero = Program.GetHero();
        while (true)
        {
            Console.Clear();
            Console.Write(GetStringBuilding());

            HandleMenu(menu, input => Shop.Sell(input, hero));
        }
    }
    public override string GetStringBuilding()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("상점 - 아이템 판매\r\n필요한 아이템을 얻을 수 있는 상점입니다.");
        sb.AppendLine($"[보유 골드]\n {Program.GetHero().Gold} G\n\n");
        sb.Append(Program.GetHero().ShowInventory(true, true));
        sb.AppendLine("0. 나가기\n\n");

        return sb.ToString();
    }
}