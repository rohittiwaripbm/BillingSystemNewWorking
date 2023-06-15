using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BillingSystemInWPF.ViewModels
{
    public class DemoProducts : BaseViewModel
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

		private int? _categoryId;

		public int? CategoryId
		{
			get { return _categoryId; }
			set 
			{ 
				_categoryId = value; 
				OnPropertyChage(nameof(CategoryId));
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

		private int? _productInStore;

		public int? ProductInStore
        {
			get { return _productInStore; }
			set 
			{
                _productInStore = value; 
				OnPropertyChage(nameof(ProductInStore));
			}
		}

		#endregion

		#region Icommand
		public ICommand EditButton { get; set; }
		public ICommand DeleteButton { get; set;}
        #endregion

    }
}
