public static class Global
{
    public static class ScenePath
    {
        public const string MAIN_SCENE = "main";
        public const string STATUS_SCENE = "status";
        public const string INVENTORY_SCENE = "inventory";
        public const string EQUIP_SCENE = "equip";
        public const string SHOP_SCENE = "shop";
        public const string BUY_SCENE = "buy";
        public const string SELL_SCENE = "sell";
        public const string REST_SCENE = "rest";
        public const string DUNGEON_SCENE = "dungeon";
    }
    public static class ErrorMsg
    {
        public const string WRONG_MSG = "잘못된 입력입니다.";
        public const string HAVENT_NUMBER_MSG = "없는 번호입니다.";
        public const string HAVENT_MONEY_MSG = " 돈이 부족합니다.";
        public const string HAVENT_ITEM_MSG = "해당 아이템은 존재하지 않습니다.";
        public const string CANT_EQUIP_MSG = "장착 가능한 아이템이 아닙니다.";
    }
    public static class InfoMsg
    {
        public const string EQUIPMENT_RELEASE_MSG = "장비가 해제되었습니다.";
        public const string REST_SUCCESSFUL_MSG = "휴식이 완료되었습니다.";
        public const string DUNGEON_FAIL_MSG = "던전에 실패하셨습니다. 현재 체력이 1/2로 감소합니다.";
        public const string DUNGEON_CLEAR_MSG = "던전을 클리하셨습니다. {0}G를 획득하셨습니다.";
    }
    public const float SELL_RATIO = 0.85f;
    public const float DUNGEON_FAIL_CHANCE = 0.40f;
    public const float DUNGEON_CLEAR_MINUS_MIN_HP = 20;
    public const float DUNGEON_CLEAR_MINUS_MAX_HP = 35;
    public const float DUNGEON_CLEAR_BONUS_GOLD_RATIO = 0.02f;

    public const int REST_PRICE = 500;
}
