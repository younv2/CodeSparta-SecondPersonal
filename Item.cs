using System;

public enum OptionType { ATTACK, DEFENSE}
public enum EquipmentType
{
    WEAPON, ARMOR, GLOVES
}
public abstract class Item
{
    private string id;
    private string name;
    private string description;
    private OptionType type;
    private int typeValue;
    private int buyPrice;
    private bool isSellShop;

    public string Id { get { return id; } }
    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public OptionType Type { get { return type; } }
    public int TypeValue { get { return typeValue; } }
    public int BuyPrice { get { return buyPrice; } }
    public bool IsSellShop { get { return isSellShop; } }
    public abstract Item Clone();
    public Item()
    {

    }
    public Item(Item item)
    {
        id = item.Id;
        name = item.name;
        description = item.description;
        type = item.type;
        typeValue = item.typeValue;
        buyPrice = item.buyPrice;
        isSellShop = item.isSellShop;
    }
    public Item(string name, string description, OptionType type, int typeValue, int buyPrice, bool isSellShop)
    {
        this.id = GenerateId();
        this.name = name;
        this.description = description;
        this.type = type;
        this.typeValue = typeValue;
        this.buyPrice = buyPrice;
        this.isSellShop = isSellShop;
    }
    public string GetString(bool showPrice = true, bool isSell = false)
    {
        return $"{name} | {LocallizeType(type)} +{typeValue} | {description} | {(showPrice ? $"{(isSell ? (int)(buyPrice * Global.SELL_RATIO) : buyPrice)} G" : "")}";
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
    private static string GenerateId()
    {
        // Guid 또는 해시 기반 생성 가능
        return Guid.NewGuid().ToString("N"); // 32자리 고유 ID (하이픈 없음)
    }


}
