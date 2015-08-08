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
        public static void Register<TViewModel, TView>() where TViewModel : DialogViewModelBase {
            _customDialogFactory.Add(typeof(TViewModel), typeof(TView));
        }

        private Window CreatWindowByViewModel(DialogViewModelBase vm, ViewModelBase owner = null, bool setDataContext = false) {
            Type vmType = vm.GetType();
            Type winType = _customDialogFactory[vmType];
            Window win = Activator.CreateInstance(winType) as Window;
            //设置datacontext
            if(setDataContext == true)
                win.DataContext = vm;

            //设置owner
            if(owner != null) {
                win.Owner = ViewManager.FindOwnerView(owner);
            }

            //监听dialogresult
            vm.PropertyChanged += vm_Normal_PropertyChanged;

            return win;
        }

        private Window CreateWindowByViewModelType<TViewModel>(ViewModelBase owner=null) where TViewModel:DialogViewModelBase {
            Type vmType = typeof(TViewModel);
            Type winType = _customDialogFactory[vmType];
            Window win = Activator.CreateInstance(winType) as Window;

            if(owner != null)
                win.Owner = ViewManager.FindOwnerView(owner);

            return win;
        }

        /// <summary>
        /// 打开模态对话框，等待关闭返回
        /// </summary>
        /// <param name="vm">通过vm实例来创建窗口</param>
        public bool? ShowDialog(DialogViewModelBase vm) {
            Window win = CreatWindowByViewModel(vm, setDataContext: true);
            return win.ShowDialog();
        }

        public bool? ShowDialog(ViewModelBase owner, DialogViewModelBase vm) {
            Window win = CreatWindowByViewModel(vm, owner, true);
            return win.ShowDialog();
        }


        /// <summary>
        /// 打开非模态对话框，不等待关闭
        /// </summary>
        /// <param name="vm"></param>
        public void Show(DialogViewModelBase vm) {
            Window win = CreatWindowByViewModel(vm,setDataContext:true);
            win.Show();
        }

        public void Show(ViewModelBase owner, DialogViewModelBase vm) {
            Window win = CreatWindowByViewModel(vm, owner, setDataContext: true);
            win.Show();
        }

        private void vm_Normal_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if(e.PropertyName == "DialogResult") {
                DialogViewModelBase dvm = sender as DialogViewModelBase;
                Window win = ViewManager.FindOwnerView(dvm);
                if(dvm.DialogResult != null) {
                    win.DialogResult = dvm.DialogResult;
                    win.Close();
                }
            }
        }


        // 通过viewmodel类型打开但不为其设置datacontext
        
        /// <summary>
        /// 打开非模态对话框
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns>返回View中绑定的DataContext的ViewModel</returns>
        public TViewModel Show<TViewModel>() where TViewModel:DialogViewModelBase {
            Window win = CreateWindowByViewModelType<TViewModel>();
            win.Show();
            return win.DataContext as TViewModel;
        }

        public TViewModel ShowDialog<TViewModel>() where TViewModel : DialogViewModelBase {
            Window win = CreateWindowByViewModelType<TViewModel>();
            win.ShowDialog();
            return win.DataContext as TViewModel;
        }

        public TViewModel ShowDialog<TViewModel>(ViewModelBase owner) where TViewModel : DialogViewModelBase {
            Window win = CreateWindowByViewModelType<TViewModel>(owner);
            win.ShowDialog();
            return win.DataContext as TViewModel;
        }
    }
}
