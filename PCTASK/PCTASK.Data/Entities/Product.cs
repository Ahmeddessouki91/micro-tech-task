using PCTASK.Data.Base;

namespace PCTASK.Data.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public double Price { get; set; }
    }
}