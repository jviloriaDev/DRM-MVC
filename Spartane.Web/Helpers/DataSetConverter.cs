using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Mvc;
namespace Spartane.Web.Helpers
{
    public static class DataSetConverter
    {
        private static readonly ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;
        private static readonly ITokenManager _tokenManager;
        static DataSetConverter()
        {
            _tokenManager = DependencyResolver.Current.GetService<ITokenManager>();
            _ISpartan_MetadataApiConsumer = DependencyResolver.Current.GetService<ISpartan_MetadataApiConsumer>();
        }
        public static DataTable ToDataTable<T>(this IList<T> data, int object_id = 0)
        {
            //For Export Set this culture 
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");

            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            var resultMeta = new List<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata>();
            if (object_id != 0)
            {
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                resultMeta = _ISpartan_MetadataApiConsumer.ListaSelAll(0, 1000, "Spartan_Metadata.Object_id = " + object_id + " AND (Relation_Type is null or Relation_Type =1)", " Spartan_Metadata.ScreenOrder").Resource.Spartan_Metadatas;
            }
            string currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, props[i].PropertyType.FullName.Contains(typeof(bool).Name) ? typeof(string) : (Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType));
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (props[i].PropertyType.FullName.Contains(typeof(bool).Name) && props[i].GetValue(item) != null)
                        values[i] = (bool)props[i].GetValue(item) ? Resources.Resources.Yes : Resources.Resources.No;
                    else
                        values[i] = props[i].GetValue(item);
                }

                table.Rows.Add(values);
            }
            //Set back the original culture
            foreach (var column in table.Columns.Cast<DataColumn>().ToArray())
                if (table.AsEnumerable().All(dr => dr.IsNull(column.ColumnName)))
                    table.Columns.Remove(column);

            if (resultMeta.Count > 0)
                for (int i = 0; i < table.Columns.Cast<DataColumn>().ToArray().Count(); i++)
                    table.Columns[i].ColumnName = resultMeta[i].Logical_Name;


            return table;
        }


        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            //For Export Set this culture 
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");

            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            var resultMeta = new List<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata>();

            string currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, props[i].PropertyType.FullName.Contains(typeof(bool).Name) ? typeof(string) : (Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType));
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (props[i].PropertyType.FullName.Contains(typeof(bool).Name) && props[i].GetValue(item) != null)
                        values[i] = (bool)props[i].GetValue(item) ? Resources.Resources.Yes : Resources.Resources.No;
                    else
                        values[i] = props[i].GetValue(item);
                }

                table.Rows.Add(values);
            }
            //Set back the original culture
            foreach (var column in table.Columns.Cast<DataColumn>().ToArray())
                if (table.AsEnumerable().All(dr => dr.IsNull(column.ColumnName)))
                    table.Columns.Remove(column);

            if (resultMeta.Count > 0)
                for (int i = 0; i < table.Columns.Cast<DataColumn>().ToArray().Count(); i++)
                    table.Columns[i].ColumnName = resultMeta[i].Logical_Name;


            return table;
        }

        public static DataTable ToDataTable<T>(this IList<T> data, int object_id = 0, string[] columsVisible = null)
        {
            //For Export Set this culture 
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");

            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            var resultMeta = new List<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata>();
            if (object_id != 0)
            {
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                resultMeta = _ISpartan_MetadataApiConsumer.ListaSelAll(0, 1000, "Spartan_Metadata.Object_id = " + object_id + " AND (Relation_Type is null or Relation_Type =1)", " Spartan_Metadata.ScreenOrder").Resource.Spartan_Metadatas;
            }
            string currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, props[i].PropertyType.FullName.Contains(typeof(bool).Name) ? typeof(string) : (Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType));
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (props[i].PropertyType.FullName.Contains(typeof(bool).Name) && props[i].GetValue(item) != null)
                        values[i] = (bool)props[i].GetValue(item) ? Resources.Resources.Yes : Resources.Resources.No;
                    else
                        values[i] = props[i].GetValue(item);
                }

                table.Rows.Add(values);
            }
            //Set back the original culture
            foreach (var column in table.Columns.Cast<DataColumn>().ToArray())
                if (table.AsEnumerable().All(dr => dr.IsNull(column.ColumnName)))
                    table.Columns.Remove(column);

            if (resultMeta.Count > 0)
                for (int i = 0; i < table.Columns.Cast<DataColumn>().ToArray().Count(); i++)
                    table.Columns[i].ColumnName = resultMeta[i].Logical_Name;

            ///Delete columns not visible
            for (int i = 0; i < columsVisible.Count(); i++)
            {
                if (columsVisible[i] == "false")
                {
                    table.Columns.RemoveAt(i - 1);
                }
            }

            return table;
        }
    }
}
