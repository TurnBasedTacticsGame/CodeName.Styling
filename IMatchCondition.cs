namespace CodeName.Core.UserInterface.Styling
{
    public interface IMatchCondition
    {
        public bool IsMatch(IStyleClassNode node);
    }
}
