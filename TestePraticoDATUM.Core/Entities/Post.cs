using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePraticoDATUM.Core.Enums;

namespace TestePraticoDATUM.Core.Entities
{
    public class Post(string title, string description, int idUser) : BaseEntity
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public int IdUser { get; private set; } = idUser;
        public User User { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public PostStatusEnum Status { get; private set; }

        public void Update(string title, string description, int idUser)
        {
            Title = title;
            Description = description;
            IdUser = idUser;
        }

        public void Delete()
        {
            if (Status == PostStatusEnum.Created)
            {
                Status = PostStatusEnum.Deleted;
            }
        }
    }
}