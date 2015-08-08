using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GalaSoft.MvvmLight.Dialog
{
    /// <summary>
    /// View管理类
    /// 通过在XAML里面定义附加属性将View注册保存到_views里
    /// </summary>
    public class ViewManager
    {

        /// <summary>
        /// 所有被注册过的view实例
        /// </summary>
        private static HashSet<Window> _views = new HashSet<Window>();


        public static bool GetRegister(DependencyObject obj) {
            return (bool)obj.GetValue(RegisterProperty);
        } 

        public static void SetRegister(DependencyObject obj, bool value) {
            obj.SetValue(RegisterProperty, value);
        }

        // Using a DependencyProperty as the backing store for Register.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegisterProperty =
            DependencyProperty.RegisterAttached("Register", typeof(bool), typeof(ViewManager), new PropertyMetadata(false,OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if((bool)e.NewValue == true) {
                Window win = d as Window;
                _views.Add(d as Window);
            }
        }


        public static Window FindOwnerView(ViewModelBase vm) {
            return _views.FirstOrDefault(win => ReferenceEquals(win.DataContext, vm));
        }
    }
}
