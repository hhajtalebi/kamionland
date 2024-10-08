using _0_Framework.Domain;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public double InitialPrice { get; private set; }
        public double UnitPrice { get; private set; }
        
        //رنگ
        public string Color { get; private set; }
        //سایز
        public string Size { get; private set; }
        //وزن
        public string Weight { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOpertion> OpertionList { get; private set; }
     
        public Inventory(long productId, double unitPrice, string color, string size, string weight, double initialPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Color = color;
            Size = size;
            Weight = weight;
            InStock = false;
            InitialPrice = initialPrice;
        }
        public void Edit(long productId, double unitPrice, string color, string size, string weight, double initialPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Color = color;
            Size = size;
            Weight = weight;
            InitialPrice= initialPrice;

        }

        public long CalculateCurrentCount()
        {
            var Plus = OpertionList.Where(x => x.Operation).Sum(x => x.Count);
            var Minus = OpertionList.Where(x => !x.Operation).Sum(x => x.Count);
            return Plus - Minus;
        }

        public void Increase(long count, long operatId, string descreption)
        {
            var currentcount = CalculateCurrentCount() + count;
            var operation = new InventoryOpertion(true, count, operatId, currentcount, descreption, 0, Id);
            OpertionList.Add(operation);
            InStock = currentcount > 0;
        }
        public void Reduce(long count, long operatId, string descreption,long orderid)
        {
            var currentcount = CalculateCurrentCount() - count;
            var operation = new InventoryOpertion(false, count, operatId, currentcount, descreption, orderid, Id);
            OpertionList.Add(operation);
            InStock = currentcount > 0;
        }

        public double Salesprofit()
        {
            return InitialPrice - UnitPrice;
        }
    }
}
