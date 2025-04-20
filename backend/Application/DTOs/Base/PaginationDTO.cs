namespace Application.DTOs
{
    public class PaginationDTO<T>
    {
        public IEnumerable<T> Records { get; set; }
        public int Total { get; set; }

        public PaginationDTO(IEnumerable<T> records, int total)
        {
            Records = records;
            Total = total;
        }
    }
}