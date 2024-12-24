using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty; // Provide a default value

        public string Description { get; set; } = string.Empty; // Provide a default value

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}
