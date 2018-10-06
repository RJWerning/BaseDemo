using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BaseDemo.Models;

namespace BaseDemo.ViewModels {
    public class CustomerVm {
        public string Id { get; set; }

        [Required]
        [DisplayName("Enter Customer Name")]
        [StringLength(20, ErrorMessage = "Customer Name length too long")]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public CustomerVm() {
        }

        public CustomerVm(Customer sender) {
            Id = sender.Id;
            Name = sender.Name;
            PhoneNumber = sender.PhoneNumber;
        }
    }
}