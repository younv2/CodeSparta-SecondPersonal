public abstract class BaseScene
{
    public abstract void Display();
    public abstract string GetStringBuilding();
    protected void HandleMenu(Dictionary<int, Action> menuActions, Action<int>? fallbackAction = null)
    {
        while (true)
        {
            var input = Read();
            if (int.TryParse(input, out int temp))
            {
                if (menuActions.TryGetValue(temp, out var action))
                {
                    action.Invoke();
                    break;
                }
                else if(fallbackAction != null)
                {
                    fallbackAction.Invoke(temp);
                    break;
                }
                else
                    SendErrorMsg(Global.ErrorMsg.WRONG_MSG);
            }
            else
                SendErrorMsg(Global.ErrorMsg.WRONG_MSG);
        }
    }

    public static string Read()
    {
        Console.Write("원하시는 행동을 입력해주세요.\n>> ");
        return Console.ReadLine();
    }
    public static void SendInfoMsg(string msg)
    {
        Console.WriteLine(msg);
        Thread.Sleep(500);
    }
    public static void SendErrorMsg(string msg)
    {
        Console.WriteLine(msg);
        Thread.Sleep(500);
    }
}


