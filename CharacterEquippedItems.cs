using System.Text;

public class CharacterEquippedItems
{
    private Dictionary<EquipmentType, EquipmentItem> equippedItems = new Dictionary<EquipmentType, EquipmentItem>();
    private Dictionary<OptionType, int> optionValue = new Dictionary<OptionType, int>();
    public int GetOptionValue(OptionType optionType)
    {
        if (optionValue.ContainsKey(optionType))
            return optionValue[optionType];
        else return 0;
    }
    private void RefreshValue()
    {
        optionValue.Clear();

        if (!optionValue.ContainsKey(OptionType.ATTACK))
            optionValue.Add(OptionType.ATTACK, 0);
        if (!optionValue.ContainsKey(OptionType.DEFENSE))
            optionValue.Add(OptionType.DEFENSE, 0);

        foreach (var data in equippedItems.Values)
        {
            optionValue[data.Type] += data.TypeValue;
        }
    }
    public bool HaveItem(int num, out Item item)
    {
        item = null;
        try
        {
            var data = equippedItems.Values.ToList()[num - 1];
            if (data != null)
            {
                item = data;
                return true;
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            return false;
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
        return false;
    }
    public int GetCount()
    {
        return equippedItems.Count;
    }
    public string ShowList(bool isEquip, ref int count, bool isSell)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var data in equippedItems.Values)
        {
            count++;
            sb.Append($"- {(isEquip ? count : "")} [E]");
            sb.AppendLine(data.GetString(isSell, isSell));
        }
        sb.AppendLine();
        return sb.ToString();
    }
    public bool RemoveItem(EquipmentItem item)
    {
        if (equippedItems.ContainsKey(item.EquipmentType) && item == equippedItems[item.EquipmentType])
        {
            equippedItems.Remove(item.EquipmentType);
            BaseScene.SendInfoMsg(Global.InfoMsg.EQUIPMENT_RELEASE_MSG);
            RefreshValue();
            return true;
        }
        else
        {
            BaseScene.SendErrorMsg(Global.ErrorMsg.HAVENT_ITEM_MSG);
            return false;
        }
    }
    public bool EquipItem(EquipmentItem item, out Item replacedItem)
    {
        replacedItem = null;
        if (item == null)
            return false;
        //장착해제
        if (equippedItems.ContainsKey(item.EquipmentType) && item == equippedItems[item.EquipmentType])
        {
            equippedItems.Remove(item.EquipmentType);
            BaseScene.SendInfoMsg(Global.InfoMsg.EQUIPMENT_RELEASE_MSG);
            RefreshValue();
            return true;
        }
        //장착
        if (!equippedItems.ContainsKey(item.EquipmentType))
        {
            equippedItems.Add(item.EquipmentType, item);
            RefreshValue();
            return true;
        }
        //교환
        else
        {
            replacedItem = equippedItems[item.EquipmentType].Clone();
            equippedItems.Remove(item.EquipmentType);
            equippedItems.Add(item.EquipmentType, item);
            RefreshValue();
            return true;
        }
    }
}