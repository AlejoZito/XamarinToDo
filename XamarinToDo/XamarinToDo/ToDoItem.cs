using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXamarinForms.Data.Models
{
    public class ToDoItem
    {
        public string Text { get; set; }
        public eItemStatus Status { get; set; }
    }
    public enum eItemStatus
    {
        New = 1,
        Done,
        Cancelled
    }
}
