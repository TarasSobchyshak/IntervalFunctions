using System.Windows.Input;

namespace IntervalFunctions.App.Models
{
    public class MenuItem
    {
        public string Text { get; set; }
        public ICommand Command { get; set; }
    }
}
