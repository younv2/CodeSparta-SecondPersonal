public class Program
{
    static Character hero;

    public static void Main(string[] args)
    {
        DataManager.Instance.LoadAllData();
        hero = new Character("Chad",ClassType.WARRIOR);

        RegisterAllScene();

        SceneManager.Load(Global.ScenePath.MAIN_SCENE);
    }

    public static void RegisterAllScene()
    {
        SceneManager.Register<MainScene>(Global.ScenePath.MAIN_SCENE);
        SceneManager.Register<BuyScene>(Global.ScenePath.BUY_SCENE);
        SceneManager.Register<EquipScene>(Global.ScenePath.EQUIP_SCENE);
        SceneManager.Register<InventoryScene>(Global.ScenePath.INVENTORY_SCENE);
        SceneManager.Register<RestScene>(Global.ScenePath.REST_SCENE);
        SceneManager.Register<SellScene>(Global.ScenePath.SELL_SCENE);
        SceneManager.Register<ShopScene>(Global.ScenePath.SHOP_SCENE);
        SceneManager.Register<StatusScene>(Global.ScenePath.STATUS_SCENE);
        SceneManager.Register<DungeonScene>(Global.ScenePath.DUNGEON_SCENE);
    }
    public static Character GetHero()
    {
        return hero;
    }
}

