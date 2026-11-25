using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics.Tracing;

namespace StudyGroupApp.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler ProperyChanged;
        protected virtual void onProperyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChangedEventArgs?
        }
    }
}
