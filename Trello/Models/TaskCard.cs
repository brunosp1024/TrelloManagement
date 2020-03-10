using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trello.Models
{
    public class TaskCard
    {

        [Key]
        public int CardId { get; set; }

        public string Name { get; set; }

        public int ListId { get; set; }

    }
}
