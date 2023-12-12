namespace Commen.Interface;

public interface ISolve<out TReturn>
{
    public TReturn Solve();
}