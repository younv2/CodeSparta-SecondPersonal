using System.Text;

public class EquipScene : BaseScene
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

            HandleMenu(menu, input => hero.EquipItem(input));
        }
    }

    public override string GetStringBuilding()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n");
        sb.AppendLine("[보유 아이템]");
        sb.Append(Program.GetHero().ShowInventory(true));
        sb.AppendLine("0. 나가기\n\n");
        return sb.ToString();
    }
}