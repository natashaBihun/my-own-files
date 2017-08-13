namespace MapOfTheCity
{
    public interface IRatingable
    {
        float Rating { get; set; }
        void Vote(float mark);
    }
}
