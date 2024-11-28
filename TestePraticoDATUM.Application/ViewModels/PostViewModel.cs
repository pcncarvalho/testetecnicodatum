using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePraticoDATUM.Application.ViewModels
{
    public class PostViewModel
    {
        public PostViewModel(int id, string title, string description, DateTime createdAt)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedAt = createdAt;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
