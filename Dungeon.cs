public class Dungeon
{
    private string name;
    private OptionType optionType;
    private int optionValue;
    private int basicClearGold;

    public string Name {  get { return name; } }
    public OptionType OptionType { get { return optionType; } }
    public int OptionValue { get { return optionValue; } }
    public int BasicClearGold {  get { return basicClearGold; } }

    public Dungeon(string name, OptionType optionType, int optionValue, int basicClearGold)
    {
        this.name = name;
        this.optionType = optionType;
        this.optionValue = optionValue;
        this.basicClearGold = basicClearGold;
    }
    public string LocallizeType(OptionType optionType)
    {
        if (optionType == OptionType.ATTACK)
        {
            return "공격력";
        }
        else if (optionType == OptionType.DEFENSE)
        {
            return "방어력";
        }
        return "";
    }
    public void Join()
    {
        Console.Clear();
        Thread.Sleep(100);

        Character hero = Program.GetHero();
        if(hero.HP<=0)
        {
            BaseScene.SendInfoMsg("체력이 부족하여 던전에 입장하실 수 없습니다");
            return;
        }
        Random rand = new Random();
        double randValue = rand.NextDouble();
        int heroPower = 0;
        switch(optionType)
        {
            case OptionType.ATTACK:
                heroPower = hero.AttackPower;
                break;
            case OptionType.DEFENSE:
                heroPower = hero.Defense;
                break;

        }
        if (heroPower < optionValue)
        {
            if (randValue <= Global.DUNGEON_FAIL_CHANCE)
            {
                Fail();
            }
            else
            {
                Clear();
            }

        }
        else Clear();
    }
    public void Fail()
    {
        Character hero = Program.GetHero();
        hero.MinusHp(hero.HP/2);
        BaseScene.SendInfoMsg(Global.InfoMsg.DUNGEON_FAIL_MSG);
    }
    public void Clear()
    {
        Character hero = Program.GetHero();
        var temp = optionValue - hero.Defense;
        hero.MinusHp(new Random().Next((int)Global.DUNGEON_CLEAR_MINUS_MIN_HP+temp,
            (int)Global.DUNGEON_CLEAR_MINUS_MAX_HP+1+temp));
        int bonusGold = (int)((hero.AttackPower * Global.DUNGEON_CLEAR_BONUS_GOLD_RATIO) * BasicClearGold);
        int rewardGold = BasicClearGold + bonusGold;
        hero.AddGold(rewardGold);
        BaseScene.SendInfoMsg(string.Format(Global.InfoMsg.DUNGEON_CLEAR_MSG, rewardGold));
    }
}
