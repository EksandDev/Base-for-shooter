public interface IInPool
{
    public bool IsActive { get; set; }

    public void Deactivate();
}