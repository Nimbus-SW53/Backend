﻿namespace Nimbus.Nimbus.Domain.Models;

public class Product
{   
    public int Id { get; set; }
    public string SoftwareName { get; set; }
    public decimal Price { get; set; }
     //public List<String>? UrlImages { get; set; }   
    public string Description { get; set; }
    
    public string UrlImagePreview{ get; set; }
    
    //public List<Review> Reviews { get; set; }
    
    public int CategoryId { get; set;} //FK
    public Category Category{ get; set;}
}