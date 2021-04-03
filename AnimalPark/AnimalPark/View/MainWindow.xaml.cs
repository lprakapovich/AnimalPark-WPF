using System;
using System.Windows;
using AnimalPark.View;
using AnimalPark.ViewModel;

namespace AnimalPark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _dataContext;
        public MainWindow()
        {
            InitializeComponent();
            _dataContext = (MainViewModel) this.DataContext;
            _dataContext.MessageDelegate += s => MessageBox.Show(s);

            _dataContext.FoodManagerViewModel.AddFoodItemDialog += OnOpenFoodItemDialog;
            _dataContext.FoodManagerViewModel.CloseDialog += (sender, args) => this.Close();
            _dataContext.FoodManagerViewModel.MessageDelegate += s => MessageBox.Show(s);
        }

        private void OnOpenFoodItemDialog(object sender, EventArgs e)
        {
            FoodItemAdderView foodAdderView = new FoodItemAdderView(_dataContext.FoodManagerViewModel.FoodAdderViewModel);
            foodAdderView.Show();
        }
    }
}
