using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
  public class Item
  {
    public int ItemId { get; set; }

    [Required(ErrorMessage = "The item's description can't be empty!")] // validation attribute for Description.
    public string Description { get; set; }

    // validation attribute for CategoryId
    [Range(1, int.MaxValue, ErrorMessage = "You must add your item to a category. Have you created a category yet?")]

    public int CategoryId { get; set; }
    public Category Category { get; set; }  // navigation property
    public List<ItemTag> JoinEntities { get; } // collection navigation property.
  }
}