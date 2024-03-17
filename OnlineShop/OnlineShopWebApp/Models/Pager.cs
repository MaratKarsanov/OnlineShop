namespace OnlineShopWebApp.Models
{
    public class Pager
    {
        public int ItemsCount { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int PagesCount { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        public Pager()
        {

        }

        public Pager(int itemsCount, int currentPage)
        {
            var pagesCount = (int)Math.Ceiling((decimal)itemsCount / Constants.PageSize);

            var startPage = currentPage - 5;
            var endPage = currentPage + 4;

            if (startPage <= 0)
            {
                startPage = 1;
                endPage = 10;
            }

            if (endPage > pagesCount)
            {
                endPage = pagesCount;
                if (endPage > Constants.PageSize)
                    startPage = currentPage - 9;
            }

            ItemsCount = itemsCount;
            CurrentPage = currentPage;
            PageSize = Constants.PageSize;
            PagesCount = pagesCount;
            StartPage = startPage;
            EndPage = endPage;
        }
    }
}
