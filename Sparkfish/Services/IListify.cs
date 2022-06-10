namespace Sparkfish.Services
{
    public interface IListify : IList<int>
    {
        Listify Create(int begin, int end);
    }
}
