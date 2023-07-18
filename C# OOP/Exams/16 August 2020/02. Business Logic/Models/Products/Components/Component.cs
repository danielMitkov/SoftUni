namespace OnlineShop.Models.Products.Components
{
    public abstract class Component:Product, IComponent
    {
        private int generation;
        public int Generation
        {
            get { return generation; }
            private set { generation = value; }
        }
        protected Component(int id,string manufacturer,string model,decimal price,double overallPerformance,int generation)
            : base(id,manufacturer,model,price,overallPerformance)
        {
            Generation = generation;
        }
        public override string ToString() => base.ToString() + $" Generation: {Generation}";
    }
}
