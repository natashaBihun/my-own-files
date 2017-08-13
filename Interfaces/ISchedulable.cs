namespace MapOfTheCity
{
    public interface ISchedulable
    {
        int OpenFrom { get; set; }
        int OpenTo { get; set; }
        bool IsOpen();
    }
}
