using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMVVM.Windows;
namespace EnterpriseMVVM.DesktopClient.ViewModels
{
    using System.ComponentModel.DataAnnotations;
   public class CustomerViewModel :ViewModel
    {
        private string customerName;
        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string CustomerName
        {
            get
            {
                return customerName;
            }
            set
            {
                customerName = value;
                NotifyPropertyChanged();
            }
        }


        #region Overrides of ViewModel
        
        protected override string OnValidate(string propertyName)
        {
            if(CustomerName != null && !CustomerName.Contains(" "))//&& CustomerName.Length < 4)
            {
                return "Customer name must include both first and last name";
            }
          

            return base.OnValidate(propertyName);
        }

        #endregion

    }
}
