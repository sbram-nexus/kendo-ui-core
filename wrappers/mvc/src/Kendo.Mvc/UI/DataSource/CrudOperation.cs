using System.Collections.Generic;
using System.Web.Routing;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Infrastructure;

namespace Kendo.Mvc.UI
{
    public class CrudOperation : JsonObject, INavigatable
    {
        private string routeName;
        private string controllerName;
        private string actionName;        

        public CrudOperation()
        {            
            RouteValues = new RouteValueDictionary();
            Url = string.Empty;
        }

        protected override void Serialize(IDictionary<string, object> json)
        {
            json["url"] = Url;

            if (DataType.HasValue())
            {
                json["dataType"] = DataType;
            }
        }        

        public string DataType { get; set; }               

        public string ActionName
        {
            get
            {
                return actionName;
            }
            set
            {
                Guard.IsNotNullOrEmpty(value, "value");

                actionName = value;

                routeName = null;
            }
        }

        public string ControllerName
        {
            get
            {
                return controllerName;
            }
            set
            {
                Guard.IsNotNullOrEmpty(value, "value");

                controllerName = value;

                routeName = null;
            }
        }

        public RouteValueDictionary RouteValues
        {
            get;
            set;
        }

        public string RouteName
        {
            get
            {
                return routeName;
            }
            set
            {
                Guard.IsNotNullOrEmpty(value, "value");

                routeName = value;
                controllerName = actionName = null;
            }
        }

        public string Url
        {
            get;
            set;
        }        
    }
}