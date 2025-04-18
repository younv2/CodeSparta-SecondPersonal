
using System.Text;

public enum ClassType
{
    WARRIOR, ARCHER
}

public class Character
{
    private string name;
    private int level;
    private ClassType type;
    private int attackPower;
    private int defense;
    private int hp;
    private int maxHp;
    private int gold;
    private Inventory inventory;
    private CharacterEquippedItems EquipedItems;

    public string Name {  get { return name; } }
    public int Level { get { return level; } }
    public ClassType Type { get { return type; } }
    public int AttackPower { get { return attackPower + EquipedItems.GetOptionValue(OptionType.ATTACK); } }
    public int Defense { get { return defense + EquipedItems.GetOptionValue(OptionType.DEFENSE); } }
    public int HP { get { return hp;  } }
    public int MaxHp {  get { return maxHp; } }
    public int Gold { get { return gold; } }

    public Character(string name, ClassType type)
    {
        this.name = name;
        this.level = 1;
        this.attackPower = 10;
        this.defense = 5;
        this.maxHp = 100;
        this.hp = maxHp;
        this.gold = 15000;
        this.type = type;
        this.inventory = new Inventory();
        this.EquipedItems = new CharacterEquippedItems();
    }
    public bool BuyItem(Item item)
    {
        if(item.BuyPrice > gold)
        {
            BaseScene.SendErrorMsg(Global.ErrorMsg.HAVENT_MONEY_MSG);
            return false;
        }
        else
        {
            gold-= item.BuyPrice;
            inventory.AddItem(item);
            return true;
        }
    }
    public void AddGold(int gold)
    {
        this.gold += gold;
    }
    public void MinusHp(int minus)
    {
        hp = int.Clamp(hp-minus, 0, hp);
    }
    public bool SellItem(int num)
    {
        if (EquipedItems.HaveItem(num, out Item equipedItem))
        {
            gold += (int)(equipedItem.BuyPrice * Global.SELL_RATIO);
            EquipedItems.RemoveItem(equipedItem as EquipmentItem);
            return true;
        }
        else if (inventory.HaveItem(num - EquipedItems.GetCount(), out Item item))
        {
            gold += (int)(item.BuyPrice * Global.SELL_RATIO);
            inventory.RemoveItem(item);
            return true;
        }
        else
        {
            BaseScene.SendErrorMsg(Global.ErrorMsg.HAVENT_ITEM_MSG);
            return false;
        }
        
    }
    public bool EquipItem(int num)
    {
        if (EquipedItems.HaveItem(num, out Item equipedItem))
        {
            if (equipedItem is EquipmentItem equipItem)
            {
                Item temp = null;
                if (EquipedItems.EquipItem(equipItem,out temp))
                    inventory.AddItem(equipItem);
                return true;
            }
            else
                return false;
        }
        else if (inventory.HaveItem(num - EquipedItems.GetCount(), out Item item))
        {
            if(item is EquipmentItem equipItem)
            {
                Item temp = null;
                if(EquipedItems.EquipItem(equipItem,out temp))
                {
                    inventory.RemoveItem(item);
                    if(temp != null)
                        inventory.AddItem(temp);
                }
                return true;
            }
            else
            {
                BaseScene.SendErrorMsg(Global.ErrorMsg.CANT_EQUIP_MSG);
                return false;
            }
        }
        else
        {
            BaseScene.SendErrorMsg(Global.ErrorMsg.HAVENT_ITEM_MSG);
            return false;
        }
    }
    public string ShowInventory(bool isEquip = false, bool isSell = false)
    {
        StringBuilder sb = new StringBuilder();
        int count = 0; 
        sb.Append(EquipedItems.ShowList(isEquip,ref count,isSell));
        sb.Append(inventory.ShowList(isEquip,ref count,isSell));

        return sb.ToString();
    }

    public bool Rest()
    {
        if (Global.REST_PRICE > gold)
        {
            BaseScene.SendErrorMsg(Global.ErrorMsg.HAVENT_MONEY_MSG);
            return false;
        }
        else
        {
            gold -= Global.REST_PRICE;
            hp = maxHp;
            BaseScene.SendErrorMsg(Global.InfoMsg.REST_SUCCESSFUL_MSG);
            return true;
        }
    }
}
