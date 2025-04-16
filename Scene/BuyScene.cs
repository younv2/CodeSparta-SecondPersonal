using System.Text;

public class BuyScene : BaseScene
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
            
            HandleMenu(menu, input => Shop.Buy(input, hero));
        }
    }

    public override string GetStringBuilding()
    {
        StringBuilder sb= new StringBuilder();

        sb.AppendLine("상점 - 아이템 구매\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
        sb.AppendLine($"[보유 골드]\n {Program.GetHero().Gold} G\n\n");
        sb.Append(Shop.ShowList(true));
        sb.AppendLine("0. 나가기\n\n");

        return sb.ToString();
    }
}