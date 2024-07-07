namespace OnlineShop.Db
{
    public static class Constants
    {
        public static string Login => "karsanov@mail.ru";
        public static int PageSize => 12;
        public static int PaginationButtonsCount => 10;
        public static string ImageLink => "/images/DefaultImg.jpg";
        public const string AdministratorRoleName = "Administrator";
        public const string UserRoleName = "User";
        public const string ProductsRedisKey = "products";
    }
}
