using System.Text;

public class RestScene : BaseScene
{
    Dictionary<int, Action> menu = new()
    {
        { 1,() => Program.GetHero().Rest() },
        { 0,() => SceneManager.Load(Global.ScenePath.MAIN_SCENE) },
    };
    public override void Display()
    {
        var hero = Program.GetHero();
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

        sb.AppendLine($"휴식하기\n{Global.REST_PRICE} G를 내면 체력을 회복할 수 있습니다.");
        sb.AppendLine($" [보유 골드]\n {Program.GetHero().Gold} G\n");
        sb.AppendLine("1. 휴식하기");
        sb.AppendLine("0. 나가기\n\n");

        return sb.ToString();
    }
}