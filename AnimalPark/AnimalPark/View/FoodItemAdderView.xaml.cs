using System;
using System.Windows;
using AnimalPark.ViewModel;

namespace AnimalPark.View
{
    /// <summary>
    /// Interaction logic for FoodItemAdderView.xaml
    /// </summary>
    public partial class FoodItemAdderView : Window
    {

        public FoodItemAdderView()
        {
            InitializeComponent();
        }

        public FoodItemAdderView(FoodAdderViewModel dataContext) : this()
        {
            this.DataContext = dataContext;

            ((FoodAdderViewModel) (this.DataContext)).CloseWindow += (sender, args) => this.Close();
        }
    }
}
