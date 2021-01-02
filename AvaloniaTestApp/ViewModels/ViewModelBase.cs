using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ReactiveUI;

namespace AvaloniaTestApp.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        protected void RaisePropertyChangedEvent(string propertyName)
        {
            try
            {
                var reactiveObject = this as IReactiveObject;
                if (reactiveObject != null)
                {
                    reactiveObject.RaisePropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
    }
}
