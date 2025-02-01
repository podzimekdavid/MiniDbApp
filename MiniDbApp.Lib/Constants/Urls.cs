namespace MiniDbApp.Lib.Constants;

public class Urls
{
    public class Api
    {
        public class V1
        {
            public class Customer
            {
                public const string BY_ID = "/api/v1/customer/byid";
                public const string LIST = "/api/v1/customer/list";
                public const string CREATE = "/api/v1/customer/create";
                public const string UPDATE = "/api/v1/customer/update";
            }
            
            public class Product
            {
                public const string BY_ID = "/api/v1/product/byid";
                public const string LIST = "/api/v1/product/list";
                public const string CREATE = "/api/v1/product/create";
                public const string UPDATE = "/api/v1/product/update";
            }
            
            public class Order
            {
                public const string BY_ID = "/api/v1/order/byid";
                public const string LIST = "/api/v1/order/list";
                public const string CUSTOMER_LIST = "/api/v1/order/bycustomer/list";
                public const string CREATE = "/api/v1/order/create";
                
                public const string ITEM_LIST = "/api/v1/order/items/lsit";
                public const string ADD_ITEM = "/api/v1/order/items/add";
                public const string UPDATE_ITEM = "/api/v1/order/items/update";
                public const string REMOVE_ITEM = "/api/v1/order/items/remove";
                
            }
        }
    }
}
