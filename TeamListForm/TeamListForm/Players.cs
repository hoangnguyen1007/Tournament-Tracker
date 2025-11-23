using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamListForm
{
    public class Player
    {
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int? TeamID { get; set; } // nullable nếu đội có thể null

        // Dùng để hiển thị đẹp trong DataGridView
        public override string ToString() => $"{PlayerName} - {Position} - Tuổi {Age}";
    }
}
