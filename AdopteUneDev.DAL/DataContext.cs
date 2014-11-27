using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public static class DataContext
    {
        static List<Developer> _developers { get; set; }
        static List<Client> _clients { get; set; }
        static List<Categories> _categories { get; set; }
        static List<ITLang> _iTLangs { get; set; }
        #region Propriétés

         public static List<Developer> Developers { get { return _developers = _developers ?? Load<Developer>(); } set { _developers = value; } }
         public static List<Client> Clients { get { return _clients = _clients ?? Load<Client>(); } set { _clients = value; } }
         public static List<Categories> Categories { get { return _categories = _categories ?? Load<Categories>(); } set { _categories = value; } }
         public static List<ITLang> ITLangs { get { return _iTLangs = _iTLangs ?? Load<ITLang>(); } set { _iTLangs = value; } }

         
        
        #endregion

         public static T LoadOne<T,U>(U key)
         {
             T obj =(T)Activator.CreateInstance(typeof(T));
             string Query = "select * from " + typeof(T).Name + "WHERE ";
             
             foreach(KeyValuePair<string,U> item in (key as Dictionary<string, U>))
             {
                 if (item.Value is string)
                 {
                     Query += " " + item.Key + " = '" + item.Value.ToString() + "' AND ";
                 }
                 else
                 {
                     Query += " " + item.Key + " = " + item.Value.ToString()+" AND ";
                 }
             }
             Query = Query.Substring(0, Query.Length - 1);
             List<Dictionary<string, object>> lretour = GestionConnexion.Instance.getData(Query);

             foreach (KeyValuePair<string, object> info in lretour[0])
             {
                 if (info.Value != DBNull.Value)
                 {
                     obj.GetType().GetProperty(info.Key).SetValue(obj, info.Value);
                 }
             }
             
             return obj;
         }

         public static List<T> LoadMany<T, U,V>(U key) where U : Dictionary<string,V> where V:struct
         {
            
             string Query = "select * from " + typeof(T).Name + "WHERE ";

             foreach ( var item in key)
             {
                 if (item.Value.GetType() == typeof(string))
                 {
                     Query += " " + item.Key + " = '" + item.Value.ToString() + "' AND ";
                 }
                 else
                 {
                     Query += " " + item.Key + " = " + item.Value.ToString() + " AND ";
                 }
             }
             Query = Query.Substring(0, Query.Length - 1);
             List<T> retour = (List<T>)Activator.CreateInstance(typeof(List<>).MakeGenericType(typeof(T)));
             List<Dictionary<string, object>> lretour = GestionConnexion.Instance.getData(Query);
             foreach (Dictionary<string, object> item in lretour)
             {
                 T obj = (T)Activator.CreateInstance(typeof(T));
                 foreach (KeyValuePair<string, object> info in lretour[0])
                 {
                     if (info.Value != DBNull.Value)
                     {
                         obj.GetType().GetProperty(info.Key).SetValue(obj, info.Value);
                     }
                 }
                 retour.Add(obj);
             }

             return retour;
         }

         public static List<T> Load<T>()
         {
             string Query = "select * from " + typeof(T).Name;
             List<Dictionary<string, object>> lretour =GestionConnexion.Instance.getData(Query);
             List<T> retour =(List<T>)Activator.CreateInstance(typeof(List<>).MakeGenericType(typeof(T)));

             foreach (Dictionary<string,object> item in lretour)
             {
                 T obj =(T)Activator.CreateInstance(typeof(T));
                 foreach (KeyValuePair<string, object> info in item)
                 {
                     if (info.Value != DBNull.Value)
                     {
                         obj.GetType().GetProperty(info.Key).SetValue(obj, info.Value);
                     }
                 }
                 retour.Add(obj);
             }

             return retour;
                
         }

        

       

    }
}
