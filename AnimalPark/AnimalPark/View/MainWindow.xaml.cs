using System;
using System.Windows;
using AnimalPark.View;
using AnimalPark.ViewModel;
using Ookii.Dialogs.Wpf;
using static AnimalPark.Utils.FileExtensionHelper;

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

            _dataContext.DirectorySelector += OnDirectorySelected;
            _dataContext.FileSelector += OnFileSelected;
            _dataContext.AppReset += OnAppReset;
            _dataContext.AppExit += OnAppExit;

            _dataContext.FoodManagerViewModel.AddFoodItemDialog += OnOpenFoodItemDialog;
            _dataContext.FoodManagerViewModel.CloseDialog += (sender, args) => this.Close();
            _dataContext.FoodManagerViewModel.MessageDelegate += s => MessageBox.Show(s);
        }

        private void OnAppReset()
        {
            ShowDialog(_dataContext.ResetApplication, 
                "Are you sure you want to reset the application? All the unsaved data will be lost.",
                "App restart");
        }

        private void OnAppExit()
        {
            ShowDialog(TerminateApplication,
                "Are you sure you want to exit the application? All the unsaved data will be lost.",
                "Exit");
        }

        private void ShowDialog(Action action, string message, string title)
        {
            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    action?.Invoke();
                    break;
            }
        }

        private void OnDirectorySelected(FileExtensionMetaData metaData) 
        {
            VistaSaveFileDialog dialog = new VistaSaveFileDialog();
            dialog.DefaultExt = metaData.Extension;
            dialog.Filter = metaData.Filter;

            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                _dataContext.PathReceiver?.Invoke(dialog.FileName);
            }
        } 

        private void OnFileSelected(FileExtensionMetaData metaData)
        {
            VistaOpenFileDialog dialog = new VistaOpenFileDialog();
            dialog.Filter = metaData.Filter;

            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                _dataContext.PathReceiver?.Invoke(dialog.FileName);
            }
        }

        private void OnOpenFoodItemDialog(object sender, EventArgs e)
        {
            FoodItemAdderView foodAdderView = new FoodItemAdderView(_dataContext.FoodManagerViewModel.FoodAdderViewModel);
            foodAdderView.Show();
        }

        private void TerminateApplication()
        {
            this.Close();
        }
    }
}
