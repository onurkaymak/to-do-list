namespace ToDoList.Models
{
  public class ItemTag // Because ItemTag is joining two separate models into one, we call this a join entity. 
  {
    public int ItemTagId { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; } // reference navigation property
    public int TagId { get; set; }
    public Tag Tag { get; set; } // reference navigation property
  }
}