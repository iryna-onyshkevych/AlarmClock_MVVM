using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDatagrid
{
    public class WindowService : IWindowService
    {
       
   
        public int minutes;
        public void CreateWindow()
        {
            SnoozeWindow printPreview = new SnoozeWindow
            {
                DataContext = new SnoozeViewModel()
            };

            printPreview.ShowDialog();
        }
        public void CloseWindow()
        {
        }
    }
}
