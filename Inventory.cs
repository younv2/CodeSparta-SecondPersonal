using System.Text;

public class Inventory
{
    private List<Item> items = new List<Item>();

    public string ShowList(bool isEquip,ref int count, bool isSell)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var data in items)
        {
            count++;
            sb.Append($"-{(isEquip ? count : "")} ");
            sb.AppendLine(data.GetString(isSell,isSell));
        }
        sb.AppendLine();
        return sb.ToString();
    }

    public void AddItem(Item item)
    {
        items.Add(item.Clone());
    }

    public bool HaveItem(int num,out Item item)
    {
        item = null;
        try
        {
            var data = items[num - 1];
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
    public void RemoveItem(Item item) 
    { 
        items.Remove(item);
    }


}
