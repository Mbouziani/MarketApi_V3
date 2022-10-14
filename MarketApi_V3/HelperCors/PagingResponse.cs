using MarketApi_V3.HelperCors;

namespace MARKET_API_V3.HelperCors
{
    public class PagingResponse<T>
    {
        public PagingResponse(IQueryable<T> Query, PagingMove ClientPaging, List<long>? zonelist = null )
        {
            Paging = new PagingDetails();

            Paging.TotalRows = Query.Count();

            Paging.TotalPages = (int)Math.Ceiling((double)Paging.TotalRows / ClientPaging.RowCount);
            Paging.CurPage = ClientPaging.PageNumber;
            Paging.HasNextPage = Paging.CurPage < Paging.TotalPages;
            Paging.HasPrevPage = Paging.CurPage > 1;

            Data = Query.Skip((ClientPaging.PageNumber - 1) *
                            ClientPaging.RowCount).Take(ClientPaging.RowCount).ToList();

            ZoneNbrList = zonelist;
         







        }
        public PagingDetails Paging { get; set; }
        public List<T> Data { get; set; }
        public List<long>? ZoneNbrList { get; set; }
        
    }
    
}
