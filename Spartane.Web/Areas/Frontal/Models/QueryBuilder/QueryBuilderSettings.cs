using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;


namespace Spartane.Web.Areas.Frontal.Models
{

    public enum QueryBuilderDataType
    {
        @string,
        @integer,
        @double,
        @date,
        @time,
        @datetime,
        @boolean
    }

    public enum QueryBuilderFilterOperators
    {
        [Description("==")]
        equal,
        [Description("<>")]
        not_equal,
        @in,
        not_in,
        [Description("<")]
        less,
        [Description("<=")]
        less_or_equal,
        [Description(">")]
        greater,
        [Description(">=")]
        greater_or_equal,
        between,
        not_between,
        begins_with,
        not_begins_with,
        contains,
        not_contains,
        ends_with,
        not_ends_with,
        is_empty,
        is_not_empty,
        is_null,
        is_not_null
    }

    public enum QueryBuilderInputType
    {
        text,
        textarea,
        radio,
        checkbox,
        select
    }

    public enum Tipo_De_Campo
    {
        integer = 1,
        Double = 2,
        String = 3,
        datetime = 4,
        date = 5,
        time = 6,
        checkbox = 7,
        radio = 8,
        textarea = 9,
        select = 10,

    }

    [Serializable]
    public class QueryBuilderSettings
    {
        public List<QueryBuilderFilter> filters { get; set; }
        public List<string> plugins { get; set; }

        public QueryBuilderSettings()
        {
            this.filters = new List<QueryBuilderFilter>();
            this.plugins = new List<string>();
        }
    }
    public class pluginConfig
    {
        public string format { get; set; }
         public string todayBtn { get; set; }
        public bool todayHighlight { get; set; }
        public bool autoclose { get; set; }
    }
     

    public class QueryBuilderFilter
    {
        public string id { get; set; }
        public string label { get; set; }
        public string type { get; set; }
       // public List<string> operators { get; set; }
        public string input { get; set; }
        public string plugin { get; set; }
        public pluginConfig pluginConfig { get; set; }
        //public List<object> values { get; set; }



        public Dictionary<string, string> values { get; set; }

        public QueryBuilderFilter()
        {

        }

        public QueryBuilderFilter(string id, string label, QueryBuilderDataType type,  QueryBuilderInputType input, Dictionary<string, string> values, string plugin, pluginConfig conFigPlugin)
        {
            this.id = id;
            this.label = label;
            this.type = type.ToString();
           // this.operators = ops;
          
            this.input = input.ToString();
            this.values = values;
            this.plugin = plugin;
            this.pluginConfig = conFigPlugin;
        }

        public static QueryBuilderDataType GetQueryBuilderDataType(string PropertyInputType)
        {
            QueryBuilderDataType QBFilterType;

            switch (PropertyInputType.ToLower())
            {
                case "checkbox":
                    QBFilterType = QueryBuilderDataType.boolean;
                    break;
                case "datetime":
                    QBFilterType = QueryBuilderDataType.datetime;
                    break;
                case "date":
                    QBFilterType = QueryBuilderDataType.date;
                    break;
                case "time":
                    QBFilterType = QueryBuilderDataType.time;
                    break;
                case "double":
                    QBFilterType = QueryBuilderDataType.@double;
                    break;
                case "integer":
                    QBFilterType = QueryBuilderDataType.integer;
                    break;
                case "enum_dropdown":
                case "select":
                case "html":
                case "stringChar":
                case "stringLine":
                    QBFilterType = QueryBuilderDataType.@string;
                    break;
                default:
                    QBFilterType = QueryBuilderDataType.@string;
                    break;
            }

            return QBFilterType;
        }

        public static QueryBuilderInputType GetQueryBuilderInputType(string PropertyType)
        {
            QueryBuilderInputType QBInputType;

            switch (PropertyType.ToLower())
            {
                case "bool":
                    QBInputType = QueryBuilderInputType.checkbox;
                    break;

                case "select":
                    QBInputType = QueryBuilderInputType.select;
                    break;

                case "datetime":
                case "double":
                case "int":
                case "string":
                    QBInputType = QueryBuilderInputType.text;
                    break;
                default:
                    QBInputType = QueryBuilderInputType.text;
                    break;
            }

            return QBInputType;
        }

        public static string GePluginType(string PropertyType)
        {
            string plugin;

            switch (PropertyType.ToLower())
            {
               
                case "datetime":
                case "date":
                    plugin = "datepicker";
                    break;
                default:
                    plugin = null;
                    break;
            }

            return plugin;
        }
        public static pluginConfig GePluginConfig(string plugin)
        {
            pluginConfig pluginConfig= null;

            switch (plugin.ToLower())
            {

                case "datepicker":
                    pluginConfig = new pluginConfig() { format = "yyyy/mm/dd", todayBtn = "linked", todayHighlight = true, autoclose = true };
                    break;
                default:
                    pluginConfig = null;
                    break;
            }

            return pluginConfig;
        }

       


        public static List<QueryBuilderFilterOperators> GetQueryBuilderFilterOperator2(string PropertyType)
        {
            List<QueryBuilderFilterOperators> QBFilterOps = new List<QueryBuilderFilterOperators>();
            switch (PropertyType.ToLower())
            {
                case "bool":
                    QBFilterOps = DefaultCheckBoxOperators;
                    break;
                case "select":
                    QBFilterOps = DefaultSelectOperators;
                    break;
                case "datetime":
                case "double":
                case "int":
                    QBFilterOps = DefaultOperators;
                    break;
                case "string":
                    QBFilterOps = DefaultTextOperators;
                    break;
                default:
                    QBFilterOps = DefaultTextOperators;
                    break;
            }

            return QBFilterOps;
        }


        public static List<string> GetQueryBuilderFilterOperator(string PropertyType)
        {
            List<string> QBFilterOps = new List<string>();
            switch (PropertyType.ToLower())
            {
                case "bool":
                    QBFilterOps = new List<string>() { "=", "<>"};
                    break;
                case "select":
                    QBFilterOps= new List<string>() { "=", "<>"};
                    break;
                case "datetime":
                case "double":
                case "integer":
                    QBFilterOps = new List<string>() { "=", "<>", ">=", "<=" };
                    break;
                case "string":
                    QBFilterOps = new List<string>() { "=", "<>" };
                    break;
                default:
                    QBFilterOps = new List<string>() { "=", "<>" };
                    break;
            }

            return QBFilterOps;
            

        }



     public static List<QueryBuilderFilterOperators> DefaultTextOperators = new List<QueryBuilderFilterOperators>
    {
        QueryBuilderFilterOperators.equal,
        QueryBuilderFilterOperators.not_equal
    };

    public static List<QueryBuilderFilterOperators> DefaultTextAreaOperators = new List<QueryBuilderFilterOperators>
    {
        QueryBuilderFilterOperators.equal,
        QueryBuilderFilterOperators.not_equal,
        QueryBuilderFilterOperators.@in,
        QueryBuilderFilterOperators.not_in,
        QueryBuilderFilterOperators.less,
        QueryBuilderFilterOperators.less_or_equal,
        QueryBuilderFilterOperators.greater,
        QueryBuilderFilterOperators.greater_or_equal,
        QueryBuilderFilterOperators.between,
        QueryBuilderFilterOperators.not_between,
        QueryBuilderFilterOperators.begins_with,
        QueryBuilderFilterOperators.not_begins_with,
        QueryBuilderFilterOperators.contains,
        QueryBuilderFilterOperators.not_contains,
        QueryBuilderFilterOperators.ends_with,
        QueryBuilderFilterOperators.not_ends_with,
        QueryBuilderFilterOperators.is_empty,
        QueryBuilderFilterOperators.is_not_empty,
        QueryBuilderFilterOperators.is_null,
        QueryBuilderFilterOperators.is_not_null
    };

        public static List<QueryBuilderFilterOperators> DefaultRadioOperators = new List<QueryBuilderFilterOperators>
{
    QueryBuilderFilterOperators.equal,
    QueryBuilderFilterOperators.not_equal,
    QueryBuilderFilterOperators.is_empty,
    QueryBuilderFilterOperators.is_not_empty,
    QueryBuilderFilterOperators.is_null,
    QueryBuilderFilterOperators.is_not_null
};

    
        public static List<QueryBuilderFilterOperators> DefaultCheckBoxOperators = new List<QueryBuilderFilterOperators>
{
    QueryBuilderFilterOperators.@in,
    QueryBuilderFilterOperators.not_in,
    QueryBuilderFilterOperators.is_empty,
    QueryBuilderFilterOperators.is_not_empty,
    QueryBuilderFilterOperators.is_null,
    QueryBuilderFilterOperators.is_not_null
};

        public static List<QueryBuilderFilterOperators> DefaultSelectOperators = new List<QueryBuilderFilterOperators>
{    
    QueryBuilderFilterOperators.equal,
    QueryBuilderFilterOperators.not_equal
};

        public static List<QueryBuilderFilterOperators> DefaultOperators = new List<QueryBuilderFilterOperators>()
        {
    QueryBuilderFilterOperators.equal,
    QueryBuilderFilterOperators.not_equal,   
    QueryBuilderFilterOperators.less_or_equal,
    QueryBuilderFilterOperators.greater_or_equal
};


        public static List<QueryBuilderFilterOperators> DefaultAllOperators = new List<QueryBuilderFilterOperators>
{
    QueryBuilderFilterOperators.equal,
    QueryBuilderFilterOperators.not_equal,
    QueryBuilderFilterOperators.@in,
    QueryBuilderFilterOperators.not_in,
    QueryBuilderFilterOperators.less,
    QueryBuilderFilterOperators.less_or_equal,
    QueryBuilderFilterOperators.greater,
    QueryBuilderFilterOperators.greater_or_equal,
    QueryBuilderFilterOperators.between,
    QueryBuilderFilterOperators.not_between,
    QueryBuilderFilterOperators.begins_with,
    QueryBuilderFilterOperators.not_begins_with,
    QueryBuilderFilterOperators.contains,
    QueryBuilderFilterOperators.not_contains,
    QueryBuilderFilterOperators.ends_with,
    QueryBuilderFilterOperators.not_ends_with,
    QueryBuilderFilterOperators.is_empty,
    QueryBuilderFilterOperators.is_not_empty,
    QueryBuilderFilterOperators.is_null,
    QueryBuilderFilterOperators.is_not_null
};

    }

  

}