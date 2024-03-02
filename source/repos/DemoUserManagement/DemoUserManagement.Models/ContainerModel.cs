using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.Models
{
    public class ContainerModel
    {
        public UserModel User { get; set; }

        public AddressModel PresentAddress { get; set; }

        public CountryModel PresentCountry { get; set; }

        public StateModel PresentState { get; set; }
        public AddressModel PermanentAddress { get; set; }

        public CountryModel PermanentCountry { get; set; }

        public StateModel PermanentState { get; set; }

      

    }
}
