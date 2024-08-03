namespace WebApplication9.Models
{
    public class product
    {
        public int ProductId { get; set; }        
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Description { get; set; }
      
        public int QuantityInStock  { get; set; }

        

       
        public virtual int? departmentId { get; set; }
        public virtual Department? department { get; set; }

    }
}
