using MvvmLight1.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight1.View.PaneTemplate
{
    public class PanelTemplateRigster
    {

        public PanelTemplateRigster() {
            _relations.CollectionChanged += _relations_CollectionChanged;
        }

        static void _relations_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            foreach(Relation relation in e.NewItems) {
                PanelTemplateManager.Register(relation.ViewModelType, relation.ViewType);
            }
        }

        private  ObservableCollection<Relation> _relations = new ObservableCollection<Relation>();

        public  ObservableCollection<Relation> Relations {
            get { return _relations; }
            set { _relations = value; }
        }

    }

}