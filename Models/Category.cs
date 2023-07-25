using System.ComponentModel.DataAnnotations; //to use data annotation

namespace BulkyWebMVCProject.Models
{
    public class Category
    /*inside the category class will be creating multiple properties
    all the properties in the category class will basically be all the columns
    that we want in the category table */
    {
       [Key]
       public int Id { get; set; }
       /*'prop' creates a property automatically, 'Id' is defined as the integer property.
       This will be the primary key of the table
       To make the above property the primary key of the table we need to have
       something called the data annotation */
       
       [Required]
       /* When required is added to any property here when SQL script will be
       generated to create this table in database you will see that string 
       will have a not null setting that is why we have the required data annotation */ 
       public string Name { get; set; }
       public int DisplayOrder { get; set; }
    }
}