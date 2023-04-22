namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;
        private int mBacking;
        private int mmBacking;
        public Person()
        {
            name = string.Empty;
            age = 0;
        }
        public Person(string name,int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
    }
}