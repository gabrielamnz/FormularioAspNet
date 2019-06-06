using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormularioAspNetNew.Binders
{
    public class DecimalModelBinder : IModelBinder
    {
        //Para que essa classe funcione é necessário registra-lá no Global.asax
        public object BindModel( ControllerContext controllerContext,ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualvalue = null;
            try
            {
                //CurrentCulture só funciona incluindo a propriedade >uiCulture< no web config
                actualvalue = Convert.ToDecimal(valueResult.AttemptedValue, CultureInfo.CurrentCulture);
            }
            catch(FormatException e)
            {
                modelState.Errors.Add(e);
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualvalue;

        }

    }
}