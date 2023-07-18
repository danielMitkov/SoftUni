using System;
namespace OnlineShop.Models.Products
{
    public abstract class Product:IProduct
    {
        private int id;
        public int Id
        {
            get { return id; }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Id can not be less or equal than 0.");
                }
                id = value;
            }
        }
        private string manufacturer;
        public string Manufacturer
        {
            get { return manufacturer; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Manufacturer can not be empty.");
                }
                manufacturer = value;
            }
        }
        private string model;
        public string Model
        {
            get { return model; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model can not be empty.");
                }
                model = value;
            }
        }
        private decimal price;
        public virtual decimal Price
        {
            get { return price; }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Price can not be less or equal than 0.");
                }
                price = value;
            }
        }
        private double overallPerformance;
        public virtual double OverallPerformance
        {
            get { return overallPerformance; }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Overall Performance can not be less or equal than 0.");
                }
                overallPerformance = value;
            }
        }
        public Product(int id,string manufacturer,string model,decimal price,double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }
        public override string ToString()
            => $"Overall Performance: {OverallPerformance}. Price: {Price} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id})";
    }
}
