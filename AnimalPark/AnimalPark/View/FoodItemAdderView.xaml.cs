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
            ((FoodAdderViewModel) (this.DataContext)).CloseWindowHandler += (sender, args) => this.Close();
            ((FoodAdderViewModel) (this.DataContext)).MessageDelegate += s => MessageBox.Show(s);
        }
    }
}
