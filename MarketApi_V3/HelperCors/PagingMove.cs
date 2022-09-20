namespace MARKET_API_V3.HelperCors
{
    public class PagingMove
    {

        private int rowCount = 10;
        private int rowCountMax = 15;

        public int RowCount { get => rowCount; set => rowCount = Math.Min(rowCountMax, value); }
        public int PageNumber { get; set; } = 1;
    }
}
