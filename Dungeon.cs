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
    public bool JoinDungeon(int num, Character hero)
    {
        try
        {
            DataManager.Instance.DungeonData[num]?.Join(hero);
            return true;
        }
        catch(Exception e)
        {
            return false;
        }
    }
    public void Join(Character hero)
    {
        
    }
}
