using MarketApi_V3.HelperCors;

namespace MARKET_API_V3.HelperCors
{
    public class PagingResponse<T>
    {
        public PagingResponse(IQueryable<T> Query, PagingMove ClientPaging )
        {
            Paging = new PagingDetails();

            Paging.TotalRows = Query.Count();

            Paging.TotalPages = (int)Math.Ceiling((double)Paging.TotalRows / ClientPaging.RowCount);
            Paging.CurPage = ClientPaging.PageNumber;
            Paging.HasNextPage = Paging.CurPage < Paging.TotalPages;
            Paging.HasPrevPage = Paging.CurPage > 1;

            Data = Query.Skip((ClientPaging.PageNumber - 1) *
                            ClientPaging.RowCount).Take(ClientPaging.RowCount).ToList();

           


        }
        public PagingDetails Paging { get; set; }
        public List<T> Data { get; set; }
       
    }
    public class PagingResponse2<T>
    {
        public PagingResponse2(IQueryable<T> Query, PagingMove ClientPaging, Statistique  statistique)
        {
            Paging = new PagingDetails();

            Paging.TotalRows = Query.Count();

            Paging.TotalPages = (int)Math.Ceiling((double)Paging.TotalRows / ClientPaging.RowCount);
            Paging.CurPage = ClientPaging.PageNumber;
            Paging.HasNextPage = Paging.CurPage < Paging.TotalPages;
            Paging.HasPrevPage = Paging.CurPage > 1;

            Data = Query.Skip((ClientPaging.PageNumber - 1) *
                            ClientPaging.RowCount).Take(ClientPaging.RowCount).ToList();

            statistique1 =  new Statistique();

            statistique1 = statistique;


        }
        public PagingDetails Paging { get; set; }
        public List<T> Data { get; set; }
        public Statistique statistique1 { get; set; }
    }
}
