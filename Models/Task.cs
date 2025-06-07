using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; } = false;

        [Required(ErrorMessage = "Priority is required")]
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        // FIXED: Made UserId nullable to allow "no user selected" state
        [Display(Name = "Assigned User")]
        public int? UserId { get; set; }

        // Navigation property - can be null if no user assigned
        public User? User { get; set; }
    }

    public enum TaskPriority
    {
        [Display(Name = "Low Priority")]
        Low = 1,

        [Display(Name = "Medium Priority")]
        Medium = 2,

        [Display(Name = "High Priority")]
        High = 3,

        [Display(Name = "Critical Priority")]
        Critical = 4
    }
}