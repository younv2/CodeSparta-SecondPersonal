public class EquipmentItem : Item
{
    private EquipmentType equipmentType;

    public EquipmentType EquipmentType { get { return equipmentType; } }
    public EquipmentItem(EquipmentItem item) : base(item)
    {
        this.equipmentType = item.equipmentType;
    }
    public EquipmentItem(string name, string description, OptionType type, int typeValue, int buyPrice, bool isSellShop, EquipmentType equipmentType) :
        base(name, description, type, typeValue, buyPrice, isSellShop)
    {
        this.equipmentType = equipmentType;
    }

    public override Item Clone()
    {
        return new EquipmentItem(this);
    }
}