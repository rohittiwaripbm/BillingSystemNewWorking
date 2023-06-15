using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BillingSystemInWPF.ViewModels
{
    public class DisplayAllCategoriesViewModel : BaseViewModel
    {
        #region Buttons
        public ICommand GenerateBillButton { get; set; }
        public ICommand AddProductButton { get; set; }
        public ICommand DisplayAllProductsButton { get; set; }
        public ICommand DisplayAllCategoriesButton { get; set; }
        public ICommand AddCategoryButton { get; set; }
        public ICommand ProductQuantityButton { get; set; }
        public ICommand TotalBillsButton { get; set; }

        #endregion
        MainViewModel _mainViewModel;
        #region Constructor
        public DisplayAllCategoriesViewModel(MainViewModel mainViewModel) 
        {
            this._mainViewModel = mainViewModel;

            GenerateBillButton = new RelayClassViewModel(GenerateBills);
            AddProductButton = new RelayClassViewModel(AddProducts);
            DisplayAllProductsButton = new RelayClassViewModel(DisplayProducts);
            DisplayAllCategoriesButton = new RelayClassViewModel(DisplayCategories);
            AddCategoryButton = new RelayClassViewModel(AddCategories);
            TotalBillsButton = new RelayClassViewModel(TotalBills);
        }
        #endregion

        #region Methods
        private void GenerateBills(object obj)
        {
            _mainViewModel.CurrentView = new GenerateBillViewModel(_mainViewModel);

        }
        public void AddProducts(object parameter)
        {
            _mainViewModel.CurrentView = new AddProductViewModel(_mainViewModel);
        }
        public void DisplayProducts(object parameter)
        {
            _mainViewModel.CurrentView = new ProductViewModel(_mainViewModel);
        }

        public void DisplayCategories(object parameter)
        {
            _mainViewModel.CurrentView = new DisplayAllCategoriesViewModel(_mainViewModel);
        }

        public void AddCategories(object parameter)
        {
            _mainViewModel.CurrentView = new AddCategoriesViewModel(_mainViewModel);
        }

        public void TotalBills(object parameter)
        {
            _mainViewModel.CurrentView = new TotalBillsViewModel(_mainViewModel);
        }
        #endregion
    }
}
