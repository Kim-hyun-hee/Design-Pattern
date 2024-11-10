namespace DesignPatterns.Command
{
    public interface ICommand
    {
        bool Excute();
        void Undo();
    }
}
