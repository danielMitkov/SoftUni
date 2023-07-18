namespace OnlineShop.Models.Products.Peripherals
{
    public abstract class Peripheral:Product, IPeripheral
    {
        private string connectionType;
        public string ConnectionType
        {
            get { return connectionType; }
            private set { connectionType = value; }
        }
        protected Peripheral(int id,string manufacturer,string model,decimal price,double overallPerformance,string connectionType) 
            : base(id,manufacturer,model,price,overallPerformance)
        {
            ConnectionType = connectionType;
        }
        public override string ToString() => base.ToString() + $" Connection Type: {ConnectionType}";
    }
}
