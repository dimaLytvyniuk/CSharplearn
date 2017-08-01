using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreAboutDelegates
{
    class Suzanne
    {
        public GetSecretIngredient MySecretIngredientMethod
        {
            get
            {
                return new GetSecretIngredient(SuzanneSecretIngredient);
            }
        }

        private string SuzanneSecretIngredient(int amount)
        {
            return amount + " onces of cloves";
        }
    }
}
