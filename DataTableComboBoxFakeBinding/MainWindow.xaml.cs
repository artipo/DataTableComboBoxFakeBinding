using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using DataTableComboBoxFakeBinding.Annotations;

namespace DataTableComboBoxFakeBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public DataView DtView => _dt.DefaultView;

        private DataTable _dt;
        public DataTable Dt
        {
            get => _dt;
            set
            {
                _dt = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DtView));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            
            var dt = new DataTable();

            dt.Columns.Add("Number", typeof(int));
            dt.Columns.Add("ThiExactColumn", typeof(string));
            dt.Columns.Add("Boolean", typeof(string));
            
            dt.Rows.Add(25, "Indocin", false);
            dt.Rows.Add(50, "Enebrel", true);
            dt.Rows.Add(10, "Hydralazine", false);

            Dt = dt;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DataGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Cancel)
                return;
            
            OnPropertyChanged(nameof(Dt));
            OnPropertyChanged(nameof(DtView));
        }
    }
}