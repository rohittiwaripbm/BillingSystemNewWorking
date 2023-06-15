using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BillingSystemInWPF.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {


        Products p = new Products();
        Categories categories = new Categories();
        #region InsideButtons
        public ICommand QuantitySearch { get; set; }   

        public ICommand SearchNameButton { get; set; }

        public ICommand PrintCommand { get; set; }

        public ICommand SaveCommmand { get; set; }

        #endregion

        #region Properties

        public int _productId { get; set; }
        public string _productName { get; set; }
        public int? _categoryId { get; set; }
        public string _categoryName { get; set; }
        public int? _productInStore { get; set; }
        public decimal? _productPrice { get; set; }

        public int _srno { get; set; }
        public ICommand _deleteButton { get; set; }

        MainViewModel _mainViewModel;
        public ObservableCollection<DemoProducts> _productList1 { get; set; }
        
        public ObservableCollection<DemoProducts> _productsList2 { get; set; } = new ObservableCollection<DemoProducts>();

        private int _totalProducts;

        public int TotalProducts
        {
            get { return _totalProducts; }
            set
            {
                _totalProducts = value;
                OnPropertyChage(nameof(TotalProducts));
            }
        }

        private string _productQuantity;

        public string ProductQuantity
        {
            get { return _productQuantity; }
            set 
            {

                if (string.IsNullOrEmpty(value) || Regex.IsMatch(value, @"^[0-9]+$"))
                {
                    _productQuantity = value;

                    OnPropertyChage(nameof(ProductQuantity));
                }
            }
        }

        private string _searcName;

        public string SearchName
        {
            get { return _searcName; }
            set 
            { 
                _searcName = value;
                OnPropertyChage(nameof(SearchName));
            }
        }


        private string _editVisibility;

        public string EditVisibility
        {
            get { return _editVisibility; }
            set {
                _editVisibility = value; 
                OnPropertyChage(nameof(EditVisibility));
            }
        }

        private string _searchVisibility;

        public string SearchVisibility
        {
            get { return _searchVisibility; }
            set 
            {
                _searchVisibility = value; 
                OnPropertyChage(nameof(SearchVisibility));
            }
        }

        //Edit Properties

        private string _editProductName;

        public string EditProductName
        {
            get { return _editProductName; }
            set 
            {
                _editProductName = value;
                OnPropertyChage(nameof(EditProductName));
            }
        }

        private decimal? _editProductPrice;

        public decimal? EditProductPrice
        {
            get { return _editProductPrice; }
            set 
            { 
                _editProductPrice = value; 
                OnPropertyChage(nameof(EditProductPrice));  
            }
        }

        private string _editProductCategory;

        public string EditProductCategory
        {
            get { return _editProductCategory; }
            set 
            {
                _editProductCategory = value;
                OnPropertyChage(nameof(EditProductCategory));
            }
        }
        private int? _editProductStock;

        public int? EditProductStock
        {
            get { return _editProductStock; }
            set 
            {
                _editProductStock = value;
                OnPropertyChage(nameof(EditProductStock));
               
            }
        }




        #endregion

        #region Buttons
        public ICommand GenerateBillButton { get; set; } 
        public ICommand AddProductButton { get; set; }
        public ICommand DisplayAllProductsButton { get; set; }    
        public ICommand DisplayAllCategoriesButton { get; set; }  
        public ICommand AddCategoryButton { get; set; }
        public ICommand ProductQuantityButton { get; set; }
        public ICommand TotalBillsButton { get; set; }

        #endregion


        #region Constructor
        public ProductViewModel(MainViewModel mainViewModel)
        {
            QuantitySearch = new RelayClassViewModel(ProductQuantitySearchMethod);
            SearchNameButton = new RelayClassViewModel(SearchNameMethod);
            PrintCommand = new RelayClassViewModel(PrintMethod);
            SaveCommmand = new RelayClassViewModel(SaveMethod);
            this._mainViewModel = mainViewModel;
            EditVisibility = "Collapsed";
            SearchVisibility = "Visible";
            GenerateBillButton = new RelayClassViewModel(GenerateBills);
            AddProductButton = new RelayClassViewModel(AddProducts);
            DisplayAllProductsButton = new RelayClassViewModel(DisplayProducts);
            DisplayAllCategoriesButton = new RelayClassViewModel(DisplayCategories);
            AddCategoryButton = new RelayClassViewModel(AddCategories);
            TotalBillsButton = new RelayClassViewModel(TotalBills);


            DemoProductCategoryList list = new DemoProductCategoryList();
            list.AddCategoriesProducts();

            GetProducts();
        }




        #endregion

        #region Methods
        
        
        public void ProductQuantitySearchMethod(object parameter)
        {
            int number;
            if(string.IsNullOrEmpty(ProductQuantity))
            {
                GetProducts();
            }
            else
            {
                bool CheckNumber = int.TryParse(ProductQuantity, out number);

                GetProducts(number);
            }
            
               
           

        }


        public void SaveMethod(object obj)
        {
            EditVisibility = "Collapsed";
            SearchVisibility = "Visible";
        }
        public void EditMethod(object obj)
        {
            SearchVisibility = "Collapsed";
            EditVisibility = "Visible";

            DemoProducts products = obj as DemoProducts;
            EditProductName = products.ProductName;
            EditProductPrice = products.ProductPrice;
            EditProductCategory = products.CategoryName;
            EditProductStock = products.ProductInStore;

        }

        public void DeleteMethod(object obj)
        {
            DemoProducts products = obj as DemoProducts;
            MessageBoxResult result = MessageBox.Show("Do you want to delete\n "
                + products.ProductName+" ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Check the user's choice
            if (result == MessageBoxResult.Yes)
            {
                // User clicked Yes
                // Perform the desired action

                _productsList2.Remove((DemoProducts)obj);
                OnPropertyChage(nameof(_productsList2));
            }
            else if (result == MessageBoxResult.No)
            {
                // User clicked No
                // Perform a different action or close the dialog
            }
            
        }

        //Get products by Name
        public void GetProducts(string SearchName)
        {

            _productsList2.Clear();
            var Productlist = p.DisplayAllProducts();
            var Categorylist = categories.DisplayAllCategories();

            foreach (var item in Productlist)
            {
                if (item.ProductName.ToLower().Contains(SearchName.ToLower()))
                {
                    _productId = item.ProductId;
                    _productName = item.ProductName;
                    _categoryId = item.CategoryId;
                    _productInStore = item.ProductInStocks;
                    _productPrice = item.ProductPrice;
                    _srno = _productsList2.Count() + 1;

                    foreach (var item1 in Categorylist)
                    {
                        if (item.CategoryId == item1.CategoryId)
                        {
                            _categoryName = item1.CategoryName;
                        }
                    }

                    DemoProducts p = new DemoProducts();
                    p.Srno = _srno;
                    p.ProductId = _productId;
                    p.CategoryName = _categoryName;
                    p.ProductPrice = _productPrice;
                    p.ProductInStore = _productInStore;
                    p.ProductName = _productName;
                    p.EditButton = new RelayClassViewModel(EditMethod);
                    p.DeleteButton = new RelayClassViewModel(DeleteMethod);
                    var _productList1 = _categoryId;
                    p.CategoryName = _categoryName;
                    p.Srno = _srno;
                    _productsList2.Add(p);
                }

            }

            TotalProducts = _productsList2.Count();
            OnPropertyChage(nameof(TotalProducts));

            OnPropertyChage(nameof(_productsList2));

        }

        //Get Products by numbers
        public void GetProducts(int number)
        {
            _productsList2.Clear();
            var Productlist = p.DisplayAllProducts();
            var Categorylist = categories.DisplayAllCategories();

            foreach (var item in Productlist)
            {
                if (item.ProductInStocks <= number)
                {
                    _productId = item.ProductId;
                    _productName = item.ProductName;
                    _categoryId = item.CategoryId;
                    _productInStore = item.ProductInStocks;
                    _productPrice = item.ProductPrice;
                    _srno = _productsList2.Count() + 1;

                    foreach (var item1 in Categorylist)
                    {
                        if (item.CategoryId == item1.CategoryId)
                        {
                            _categoryName = item1.CategoryName;
                        }
                    }

                    DemoProducts p = new DemoProducts();
                    p.Srno = _srno;
                    p.ProductId = _productId;
                    p.CategoryName = _categoryName;
                    p.ProductPrice = _productPrice;
                    p.ProductInStore = _productInStore;
                    p.ProductName = _productName;
                    p.EditButton = new RelayClassViewModel(EditMethod);
                    p.DeleteButton = new RelayClassViewModel(DeleteMethod);
                    var _productList1 = _categoryId;
                    p.CategoryName = _categoryName;
                    p.Srno = _srno;
                    _productsList2.Add(p);
                }

            }

            TotalProducts = _productsList2.Count();
            OnPropertyChage(nameof(TotalProducts));

            OnPropertyChage(nameof(_productsList2));
        }

        //Get Products
        public void GetProducts()
        {
            _productsList2.Clear();
            var Productlist = p.DisplayAllProducts();
            var Categorylist = categories.DisplayAllCategories();

            foreach (var item in Productlist)
            {
                    _productId = item.ProductId;
                    _productName = item.ProductName;
                    _categoryId = item.CategoryId;
                    _productInStore = item.ProductInStocks;
                    _productPrice = item.ProductPrice;
                    _srno = _productsList2.Count() + 1;

                    foreach (var item1 in Categorylist)
                    {
                        if (item.CategoryId == item1.CategoryId)
                        {
                            _categoryName = item1.CategoryName;
                        }
                    }

                    DemoProducts p = new DemoProducts();
                    p.Srno = _srno;
                    p.ProductId = _productId;
                    p.CategoryName = _categoryName;
                    p.ProductPrice = _productPrice;
                    p.ProductInStore = _productInStore;
                    p.ProductName = _productName;
                p.EditButton = new RelayClassViewModel(EditMethod);
                    p.DeleteButton = new RelayClassViewModel(DeleteMethod);
                    var _productList1 = _categoryId;
                    p.CategoryName = _categoryName;
                    p.Srno = _srno;
                    _productsList2.Add(p);
                

            }

            TotalProducts = _productsList2.Count();
            OnPropertyChage(nameof(TotalProducts));

            OnPropertyChage(nameof(_productsList2));
        }

        public void PrintMethod(object parameter)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual((Visual)parameter, "Print Job");
            }


        }
        public void SearchNameMethod(object parameter)
        {
            //SearchName

            if(string.IsNullOrEmpty(SearchName))
            {
                GetProducts();
            }
            else
            {
                GetProducts(SearchName);
            }
        }

        //Methods for Diffrent Views
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


//var p = _productList.Select(x => new DemoProducts()
//{
//    ProductId = x.ProductId,
//    ProductName = x.ProductName,
//    CategoryId = x.CategoryId,
//    CategoryName = _productList.Where(py => py.CategoryId == x.CategoryId)
//                   .Select(py => py.CategoryName)
//                   .FirstOrDefault(),
//    ProductPrice = x.ProductPrice,
//    ProductInStore = x.ProductInStore,
//});

//var newList = new List<DemoProducts>();
//newList.AddRange(_productList);
//newList.AddRange(p);
//_productList = newList;
