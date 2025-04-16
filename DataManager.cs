public class DataManager
{
    private static DataManager singleton;

    private List<Item> itemData;
    private List<Dungeon> dungeonData;

    public List<Item> ItemData { get { return itemData; } }
    public List<Dungeon> DungeonData{ get { return dungeonData; } }

    public static DataManager Instance
    {
        get { 
        if(singleton == null)
            singleton = new DataManager();
        return singleton;
        }
    }
    public void LoadAllData()
    {
        LoadItemData();
        LoadDungeonData();
    }
    public void LoadItemData()
    {
        itemData = new List<Item>();

        itemData.Add(new EquipmentItem("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", OptionType.DEFENSE, 5, 1000, true,EquipmentType.ARMOR));
        itemData.Add(new EquipmentItem("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", OptionType.DEFENSE, 9, 2000, true, EquipmentType.ARMOR));
        itemData.Add(new EquipmentItem("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", OptionType.DEFENSE, 15, 3500, true, EquipmentType.ARMOR));
        itemData.Add(new EquipmentItem("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", OptionType.ATTACK, 2, 600, true, EquipmentType.WEAPON));
        itemData.Add(new EquipmentItem("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", OptionType.ATTACK, 5, 1500, true, EquipmentType.WEAPON));
        itemData.Add(new EquipmentItem("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", OptionType.ATTACK, 7, 3000, true, EquipmentType.WEAPON));
        itemData.Add(new EquipmentItem("낡은 장갑", "쉽게 볼 수 있는 낡은 장갑 입니다.", OptionType.ATTACK, 2, 600, true, EquipmentType.GLOVES));
        itemData.Add(new EquipmentItem("청동 장갑", "어디선가 사용됐던거 같은 장갑입니다.", OptionType.ATTACK, 5, 1500, true, EquipmentType.GLOVES));
        itemData.Add(new EquipmentItem("스파르타의 장갑", "스파르타의 전사들이 사용했다는 전설의 장갑입니다.", OptionType.ATTACK, 7, 3000, true, EquipmentType.GLOVES));
    }
    public void LoadDungeonData()
    {
        dungeonData = new List<Dungeon>();

        dungeonData.Add(new Dungeon("쉬운 던전", OptionType.DEFENSE, 5, 1000));
        dungeonData.Add(new Dungeon("보통 던전", OptionType.DEFENSE, 11, 1700));
        dungeonData.Add(new Dungeon("어려운 던전", OptionType.DEFENSE, 17, 2500));
    }

}