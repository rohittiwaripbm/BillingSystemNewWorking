using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

//selected item create a method to set cateogory and other fields; onsourcetrigger on selected item
namespace BillingSystemInWPF.ViewModels
{

    
    public class GenerateBillViewModel : BaseViewModel
    {

        Products p = new Products();
        Categories categories = new Categories();

        #region ICommands
        public ICommand _addBills { get; set; }
        public ICommand _sendBill { get; set; }
        #endregion


        #region Lists
        public ObservableCollection<CreateBillViewModel> CreateBill { get; set; } = new ObservableCollection<CreateBillViewModel>();

        public ObservableCollection<DemoProducts> ProductList { get; set; } = new ObservableCollection<DemoProducts>();
        #endregion
        #region Properties
        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set
            {
                _productId = value;
                OnPropertyChage(nameof(ProductId));
            }
        }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set 
            {
                _date = value; 
                OnPropertyChage(nameof(Date));
            }
        }

        private string _datetimeformat;

        public string DatetimeFormat
        {
            get { return _datetimeformat; }
            set 
            {
                _datetimeformat = value;
                OnPropertyChage(nameof(DatetimeFormat));
            }
        }



        private DemoProducts _selectedProduct;
        public DemoProducts SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                SetPropertyValue();
                OnPropertyChage(nameof(SelectedProduct)); }
        }

        private string _mobileNumber;

        public string MobileNumber
        {
            get { return _mobileNumber; }
            set
            {
                _mobileNumber = value;
                OnPropertyChage(nameof(MobileNumber));
            }
        }
       

        private string _customerName;

        public string CustomerName
        {
            get { return _customerName; }
            set 
            {
                _customerName = value;
                OnPropertyChage(nameof(CustomerName));
            }
        }


        private decimal? _grandTotal;

        public decimal? GrandTotal
        {
            get { return _grandTotal; }
            set 
            {
                _grandTotal = value; 
                OnPropertyChage(nameof(GrandTotal));
            }
        }

        private decimal? _total;

        public decimal? Total
        {
            get { return _total; }
            set 
            {
                _total = value;
                OnPropertyChage(nameof(Total));
            }
        }

        //decimal? ConstantTotal;
        private decimal? _constantTotal;

        public decimal? ConstantTotal
        {
            get { return _constantTotal; }
            set 
            {
                _constantTotal = value; 
                OnPropertyChage(nameof(ConstantTotal));
            }
        }

        private string _discount;

        public string Discount
        {
            get { return _discount; }
            set 
            { 
                _discount = value;
                GetDiscount();
                OnPropertyChage(nameof(Discount));
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChage(nameof(IsLoading));
            }
        }

        // Add Product fields...
        private string _addProductName;

        public string AddProductName
        {
            get { return _addProductName; }
            set 
            {
                _addProductName = value;
                OnPropertyChage(nameof(AddProductName));
            }
        }

        private string _addCategory;

        public string AddCategory
        {
            get { return _addCategory; }
            set 
            {
                _addCategory = value;
                OnPropertyChage(nameof(AddCategory));
            }
        }

        private decimal? _addProductPrice;

        public decimal? AddProductPrice
        {
            get { return _addProductPrice; }
            set 
            {
                _addProductPrice = value; 
                OnPropertyChage(nameof(AddProductPrice));   
            }
        }



        private int _addProductQuantity;

        public int AddProductQuantity
        {
            get { return _addProductQuantity; }
            set 
            { 
                _addProductQuantity = value;
                OnPropertyChage(nameof(AddProductQuantity));
            }
        }

        private int _addProductDiscount;

        public int AddProductDiscount
        {
            get { return _addProductDiscount; }
            set 
            { 
                _addProductDiscount = value;
                OnPropertyChage(nameof(AddProductDiscount));    
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
        MainViewModel _mainViewModel;

        #region Constructor
        public GenerateBillViewModel(MainViewModel mainViewModel)
        {
            
            this._mainViewModel = mainViewModel;
            GenerateBillButton = new RelayClassViewModel(GenerateBills);
            AddProductButton = new RelayClassViewModel(AddProducts);
            DisplayAllProductsButton = new RelayClassViewModel(DisplayProducts);
            DisplayAllCategoriesButton = new RelayClassViewModel(DisplayCategories);
            AddCategoryButton = new RelayClassViewModel(AddCategories);
            TotalBillsButton = new RelayClassViewModel(TotalBills);
            GrandTotal = 0;
            ConstantTotal = 0;
            Total = 0;
            Discount= "0";
            AddProductQuantity = 1;
            _addBills = new RelayClassViewModel(AddMethod);
            _sendBill = new RelayClassViewModel(SendBill);
            Date= DateTime.Now;
            DatetimeFormat = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            var products = p.DisplayAllProducts();
            foreach (var item in products)
            {
                ProductList.Add(new DemoProducts()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductInStore = item.ProductInStocks,
                    ProductPrice = item.ProductPrice,
                    CategoryId = item.CategoryId
                }); ;
            }
        }
        #endregion
        #region Methods
        public void AddMethod(object parameter)
        {
            CreateBillViewModel billList = new CreateBillViewModel();
            billList.Srno = CreateBill.Count() + 1;
            billList.ProductName = AddProductName;
            billList.CategoryName = AddCategory;
            billList.ProductPrice = AddProductPrice;
            billList.ProductQuantity = AddProductQuantity;
            billList.Discount= AddProductDiscount;
            billList.TotalPrice = AddProductPrice * AddProductQuantity;
            billList.TotalPrice = billList.TotalPrice - (billList.TotalPrice * AddProductDiscount) / 100;
            Total = (AddProductPrice * AddProductQuantity) +Total;
            ConstantTotal = billList.TotalPrice+ ConstantTotal;
            GrandTotal = ConstantTotal;
            GetDiscount();
            CreateBill.Add(billList);
            AddProductName = null;
            AddCategory = null;
            AddProductPrice = 0;
            AddProductQuantity = 1;
            AddProductDiscount = 0;
            SelectedProduct= null;
        }
        public void GetDiscount()
        {
            //GrandTotal
            decimal number;
            bool Check = decimal.TryParse(Discount, out number);
            decimal? DiscountPercentage = (ConstantTotal * number) / 100;
            GrandTotal = ConstantTotal - DiscountPercentage;
        }
        public void SendBill(object obj)
        {
            MobileNumber = "+91" + MobileNumber;
            SendBillToMobile(MobileNumber, CreateBill);
            CustomerName = null;
            MobileNumber= null;
            GrandTotal= 0;
            Total= 0;
            ConstantTotal= 0;
            Discount= "0";
            CreateBill.Clear();
        }
        private void SendBillToMobile(string mobileNumber, ObservableCollection<CreateBillViewModel> bills)
        {
            // Code to send the bill as an SMS message
            // Replace with the actual implementation using an SMS gateway provider

            // Example using the Twilio API

            string accountSid = "ACd1b4bc5cdf4c5f56e57358937c8fa7d3";
            string authToken = "61411f7c672bd33263d7fa71ebe2e685";
            string twilioPhoneNumber = "+12542744363";

            TwilioClient.Init(accountSid, authToken);

            string message = GenerateBillMessage(bills); // Generate the message content

            var smsMessage = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(twilioPhoneNumber),
                to: new Twilio.Types.PhoneNumber(mobileNumber)
            );

            Console.WriteLine(smsMessage.Sid); // Optional: You can check the message SID for reference
        }

        private string GenerateBillMessage(ObservableCollection<CreateBillViewModel> bills)
        {
            // Generate the message content based on the bill details of all items in the collection
            // Modify this method based on your desired format

            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.AppendLine("-");
            messageBuilder.AppendLine("Mr./Ms./Mrs. " + CustomerName);
            messageBuilder.AppendLine("Your Bill Details : ");
            foreach (var bill in bills)
            {
                messageBuilder.AppendLine($"Sr no: {bill.Srno}");
                messageBuilder.AppendLine($"Product Name: {bill.ProductName}");
                messageBuilder.AppendLine($"Category: {bill.CategoryName}");
                messageBuilder.AppendLine($"Price: {bill.ProductPrice}");
                messageBuilder.AppendLine($"Quantity: {bill.ProductQuantity}");
                messageBuilder.AppendLine($"Discount: {bill.Discount}");
                messageBuilder.AppendLine($"Total Price: {bill.TotalPrice}");
                messageBuilder.AppendLine(); // Add a new line between each item
            }
            messageBuilder.AppendLine("-------------------------------");
            messageBuilder.AppendLine($" Total: {Total}");
            messageBuilder.AppendLine($"Discount: {Discount}");

            messageBuilder.AppendLine($"Grand Total: {GrandTotal}");
            return messageBuilder.ToString();
        }
        public void SetPropertyValue()
        {
            if(SelectedProduct!=null)
            {
                AddProductName = SelectedProduct.ProductName;
                AddProductPrice = SelectedProduct.ProductPrice;
                var Categories = categories.DisplayAllCategories();
                foreach (var category in Categories)
                {
                    if(SelectedProduct.CategoryId == category.CategoryId)
                    {
                        AddCategory = category.CategoryName;
                        break;
                    }
                }
            }

        }
        #endregion
        #region Navigate to new page Methods
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
