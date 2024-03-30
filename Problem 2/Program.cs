namespace DesignPatterns
{
    class MainApp
    {
        static void Main()
        {
            // You have a designer tool called Tekla, where a user can click, move items and set message action. Here each action have redo and undo capablity. 
            // Implement the missing sections below...

            IUIObject obj = new UIObject();
            ITeklaDesignerTool tool = new TeklaDesignerTool(obj);
            tool.SetCommand(1);
            tool.RunAction();

            tool.SetCommand(2);
            tool.RunAction();
            tool.RunAction();
            tool.UndoLastAction();

            tool.SetCommand(3);
            tool.RunAction();
            tool.UndoLastAction();

            Console.ReadKey();
        }
    }
}

public interface ITeklaDesignerTool
{
    void RunAction();
    void SetCommand(int commandOption);
    void UndoLastAction();
}

public class TeklaDesignerTool : ITeklaDesignerTool
{
    private IActionCommand _action;

    Stack<IActionCommand> _actions = new Stack<IActionCommand>();
    private IUIObject _obj;
    ActionFactory actionFactory;
    public TeklaDesignerTool(IUIObject obj)
    {
        _obj = obj;
        actionFactory = new ActionFactory();
    }

    public void SetCommand(int commandOption)
    {
        _action = actionFactory.GetCommand(commandOption);
        
    }
    public void RunAction()
    {
        _action.Execute(_obj);
        _actions.Push(_action);
        Console.WriteLine("After applying action..");
        _obj.ShowCurrentState();
    }

    public void UndoLastAction()
    {
        _action = _actions.Pop();
        _action.UnExecute(_obj);

        Console.WriteLine("After Undoing..");
        _obj.ShowCurrentState();
    }

}

public interface IUIObject
{
    string ErrorMessage { get; set; } 
    int TotalClick { get; set; }
    int TotalMoveOperations { get; set; }
    public void ShowCurrentState();
}

public class UIObject : IUIObject
{
    public string ErrorMessage { get; set; }  = "No message";
    public int TotalClick { get; set; } = 0;
    public int TotalMoveOperations { get; set; } = 0;
    public void ShowCurrentState()
    {
        Console.WriteLine(" Total Click: " + TotalClick);
        Console.WriteLine(" Total Move Operations: " + TotalMoveOperations);
        Console.WriteLine(" Error Message: " + ErrorMessage);
    }
}

public class ActionFactory
{
    //Factory method
    public IActionCommand GetCommand(int commandOption)
    {
        switch (commandOption)
        {
            case 1:
                return new ClickCommand();
            case 2:
                return new MoveCommand();
            case 3:
                return new UpdateErrorMessageCommand();
            default:
                return new ClickCommand();
        }
        return null;
    }
}

public interface IActionCommand
{
    public void Execute(IUIObject obj);
    public void UnExecute(IUIObject obj);
}

public class ClickCommand : IActionCommand
{
    // Implement...
    public void Execute(IUIObject obj)
    {
        Console.WriteLine("Clicked");
        obj.TotalClick += 1;
    }

    public void UnExecute(IUIObject obj)
    {
        Console.WriteLine("Unclicked");
        obj.TotalClick -= 1;
    }
}

public class MoveCommand : IActionCommand
{
    // Implement.....
    public void Execute(IUIObject obj)
    {
        Console.WriteLine("Moved");
        obj.TotalMoveOperations += 1;
    }

    public void UnExecute(IUIObject obj)
    {
        Console.WriteLine("Unmoved");
        obj.TotalMoveOperations -= 1;
    }
}

public class UpdateErrorMessageCommand : IActionCommand
{
    // Implement.....
    public void Execute(IUIObject obj)
    {
        obj.ErrorMessage = "Error Message Updated";
        Console.WriteLine(obj.ErrorMessage);
    }

    public void UnExecute(IUIObject obj)
    {
        obj.ErrorMessage = "Error Message Removed";
        Console.WriteLine(obj.ErrorMessage);
    }
}
