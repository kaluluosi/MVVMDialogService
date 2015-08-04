using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GalaSoft.MvvmLight.Dialog
{
    public class DefaultDialogService : IDialogService
    {
        /// <summary>
        /// 自定义对话框工厂,viewmodel view 的映射关系
        /// key=ViewModel，value=View
        /// </summary>
        private static Dictionary<Type, Type> _customDialogFactory = new Dictionary<Type, Type>();

        /// <summary>
        /// 注册映射关系
        /// 问题：这样一来这个注册映射关系的操作就必须在程序运行前就做，有点蛋疼！
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <typeparam name="TView"></typeparam>
        public static void Register<TViewModel, TView>() {
            _customDialogFactory.Add(typeof(TViewModel), typeof(TView));
        }

        /// <summary>
        /// 打开模态对话框，等待关闭返回
        /// </summary>
        /// <param name="vm">通过vm实例来创建窗口</param>
        public bool? ShowDialog(DialogViewModelBase vm) {
            try
            {
	            Type vmType = vm.GetType();
	            Type winType = _customDialogFactory[vmType];
	            Window win = Activator.CreateInstance(winType) as Window;
	            win.DataContext = vm;
	            //监听vm的propertychanged来监听DialogRsult的变化
	            vm.PropertyChanged += vm_Model_DialogResultChanged;
	            return win.ShowDialog();
            }
            catch (System.Exception ex)
            {
                throw ;
            }
        }

        public bool? ShowDialog(ViewModelBase owner, DialogViewModelBase vm) {
            Type vmType = vm.GetType();
            Type winType = _customDialogFactory[vmType];
            Window win = Activator.CreateInstance(winType) as Window;
            win.DataContext = vm;
            //设置拥有这个对话框的窗口
            win.Owner = ViewManager.FindOwnerView(owner);
            //监听vm的propertychanged来监听DialogRsult的变化
            vm.PropertyChanged +=vm_Model_DialogResultChanged;
            return win.ShowDialog();
        }


        /// <summary>
        /// 打开非模态对话框，不等待关闭
        /// </summary>
        /// <param name="vm"></param>
        public void Show(DialogViewModelBase vm) {
            Type vmType = vm.GetType();
            Type winType = _customDialogFactory[vmType];
            Window win = Activator.CreateInstance(winType) as Window;
            win.DataContext = vm;
            //监听vm的propertychanged来监听DialogRsult的变化
            vm.PropertyChanged += vm_Normal_PropertyChanged;
            win.ShowDialog();
        }

        public void Show(ViewModelBase owner, DialogViewModelBase vm) {
            Type vmType = vm.GetType();
            Type winType = _customDialogFactory[vmType];
            Window win = Activator.CreateInstance(winType) as Window;
            win.DataContext = vm;
            win.Owner = ViewManager.FindOwnerView(owner);
            //监听vm的propertychanged来监听DialogRsult的变化
            vm.PropertyChanged += vm_Normal_PropertyChanged;
            win.ShowDialog();
        }

        private void vm_Normal_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {

            if(e.PropertyName == "DialogResult") {
                DialogViewModelBase dvm = sender as DialogViewModelBase;
                Window win = ViewManager.FindOwnerView(dvm);
                if(dvm.DialogResult != null) {
                    win.Close();
                }
            }

        }
       
        void vm_Model_DialogResultChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if(e.PropertyName == "DialogResult") {
                //当vm的dialogresult改变时，修改对应的view的dialogresult，实现关闭对话框
                DialogViewModelBase dvm = sender as DialogViewModelBase;
                Window win = ViewManager.FindOwnerView(dvm);
                win.DialogResult = dvm.DialogResult;
            }
        }

    }
}
