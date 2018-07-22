using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Players
{
    [Table("Players")]
    public partial class Player
    {
        [Key]
        [StringLength(20)]
        [Required]
        public string Nickname { get; set; }

        public int BestScore { get; set; }
    }
}
