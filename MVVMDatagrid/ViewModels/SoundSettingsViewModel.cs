using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMAlarmClock
{
    public class SoundSettingsViewModel
    {
        private void SoundStream(UnmanagedMemoryStream stream)
        {
            MyViewModel viewModel = new MyViewModel();
            viewModel.sound.Stream = stream;

        }

    }
}
