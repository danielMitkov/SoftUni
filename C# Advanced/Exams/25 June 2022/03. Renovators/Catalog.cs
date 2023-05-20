using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name,int neededRenovators,string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public List<Renovator> Renovators { get; set; }
        public int Count { get { return Renovators.Count; } }
        public string AddRenovator(Renovator renovator)
        {
            if(Count >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if(renovator.Name == null
                || renovator.Name == string.Empty
                || renovator.Type == null
                || renovator.Type == string.Empty)
            {
                return "Invalid renovator's information.";
            }
            if(renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            return Renovators.RemoveAll(x => x.Name == name) > 0;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            return Renovators.RemoveAll(x => x.Type == type);
        }
        public Renovator HireRenovator(string name)
        {
            Renovator man = Renovators.SingleOrDefault(x => x.Name == name);
            if(man != null)
            {
                man.Hired = true;
            }
            return man;
        }
        public List<Renovator> PayRenovators(int days)
        {
            return Renovators.FindAll(x => x.Days >= days);
        }
        public string Report()
        {
            return $"Renovators available for Project {Project}:{Environment.NewLine}{string.Join(Environment.NewLine,Renovators.Where(x => !x.Hired))}";
        }
    }
}
