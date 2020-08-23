using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Model
{
    public partial class tblRecipe
    {
        public string Creator
        {
            get
            {
                return tblUserData.GivenName + " " + tblUserData.Surname;
            }
        }
        public string Date_Created
        {
            get
            {
                if(DateCreated.HasValue)
                    return ((DateTime)DateCreated).ToShortDateString();
                return null;
            }
        }
    }
}
