using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamListForm
{
    public class Team
    {
        public int ID { get; set; }           // cột ID trong DB
        public string TEAMNAME { get; set; } = "";  // cột TEAMNAME
        public string COACH { get; set; } = "";     // cột COACH
        // LOGOPATH bỏ qua
    }
}
