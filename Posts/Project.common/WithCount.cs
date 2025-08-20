namespace Project.common
{
    public class WithCount<T>
    {
        public int Count { get; set; }
        public List<T> Response { get; set; }
    }
}
