using System.Text;

public class StatusScene : BaseScene
{
    Dictionary<int, Action> menu = new()
    {
        {0,() => SceneManager.Load(Global.ScenePath.MAIN_SCENE)}
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
        var hero = Program.GetHero();
        sb.AppendLine("상태 보기\n캐릭터의 정보가 표시됩니다.\n");
        sb.AppendLine($"Lv. {hero.Level.ToString("D2")}");
        sb.AppendLine($"{hero.Name} ( {hero.Type} )");
        sb.AppendLine($"공격력 : {hero.AttackPower}");
        sb.AppendLine($"방어력 : {hero.Defense}");
        sb.AppendLine($"체 력 : {hero.HP}");
        sb.AppendLine($"Gold : {hero.Gold} G\n");

        sb.AppendLine("0. 나가기\n\n");

        return sb.ToString();
    }
}