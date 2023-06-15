using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystemInWPF.ViewModels
{
    public class CreateBillViewModel : BaseViewModel
    {
		#region Properties

		


		private int _srno;

		public int Srno
		{
			get { return _srno; }
			set 
			{ 
				_srno = value;
				OnPropertyChage(nameof(Srno));
			}
		}

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


		private string _productName;

		public string ProductName
		{
			get { return _productName; }
			set 
			{

				_productName = value;
				OnPropertyChage(nameof(ProductName));
			}
		}

		private string _categoryName;

		public string CategoryName
		{
			get { return _categoryName; }
			set 
			{

				_categoryName = value;
				OnPropertyChage(nameof(CategoryName));
			}
		}

		private decimal? _productPrice;

		public decimal? ProductPrice
		{
			get { return _productPrice; }
			set 
			{ 
				_productPrice = value; 
				OnPropertyChage(nameof(ProductPrice));
			}
		}

		private int _productQuantity;

		public int ProductQuantity
		{
			get { return _productQuantity; }
			set 
			{
				_productQuantity = value;
				OnPropertyChage(nameof(ProductQuantity));
			}
		}
		private decimal _discount;

		public decimal Discount
		{
			get { return _discount; }
			set 
			{ 
				_discount = value;
				OnPropertyChage(nameof(Discount));
			}
		}

		private decimal? _totalPrice;

		public decimal? TotalPrice
		{
			get { return _totalPrice; }
			set 
			{
				_totalPrice = value; 
				OnPropertyChage(nameof(TotalPrice));
			}
		}

		public   ObservableCollection<DemoProducts> productList { get; set; } = new ObservableCollection<DemoProducts>();
        

        #endregion

        #region Constructor
        public CreateBillViewModel()
		{
		
			

        }
        #endregion
    }
}
