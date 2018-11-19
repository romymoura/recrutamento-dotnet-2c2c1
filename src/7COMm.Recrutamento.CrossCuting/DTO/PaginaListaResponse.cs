namespace _7COMm.Recrutamento.CrossCuting.DTO
{
    public class PaginaListaResponse
    {
        public string[] ListaPaginada { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
    }
}
