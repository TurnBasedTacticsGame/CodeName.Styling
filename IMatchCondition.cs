namespace CodeName.Styling
{
    public interface IMatchCondition
    {
        public bool IsMatch(IStyleClassNode node);
    }
}
