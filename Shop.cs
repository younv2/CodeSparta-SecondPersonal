
using System.Text;

public static class Shop
{
    public static List<Item> shopItems = DataManager.Instance.ItemData.FindAll(x => x.IsSellShop).ToList();
    public static string ShowList(bool isBuy = false)
    {
        StringBuilder sb = new StringBuilder();
        int count = 0;
        foreach (var data in DataManager.Instance.ItemData.FindAll(x => x.IsSellShop))
        {
            count++;
            sb.Append($"- {(isBuy ? count : "")} ");
            sb.AppendLine(data.GetString());
        }
        sb.AppendLine();
        return sb.ToString();
    }
    
    public static bool Buy(int num, Character hero)
    {
        try
        {
            var data = shopItems[num - 1];
            if (data != null)
            {
                return hero.BuyItem(data);
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            BaseScene.SendErrorMsg(Global.ErrorMsg.HAVENT_NUMBER_MSG);
            return false;
        }
        catch (IndexOutOfRangeException)
        {
            BaseScene.SendErrorMsg(Global.ErrorMsg.HAVENT_NUMBER_MSG);
            return false;
        }
        return false;
    }
    public static bool Sell(int num, Character hero)
    {
        return hero.SellItem(num);
    }
}
