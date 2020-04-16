using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTutorial1.ViewModels
{   
    //we need all attributes that EmployeeCreateViewModel has(inheritance)
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        public int Id { get; set; }
        public String ExistingPhotoPath { get; set; }
    }
}
