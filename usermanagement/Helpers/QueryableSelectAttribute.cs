
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using UserManager.Common.Models;
using UserManager.Services.Interfaces;
using UserManager.Services.Source;

namespace UserManager.Api.Helpers
{
    public class QueryableSelectAttribute : ActionFilterAttribute
    {
        private const string ODataSelectOption = "$select=";
        private StringValues selectValue;
        private StringValues authorizationToken;
        public IDataAccesService DataAccesService { get; set; }
        public QueryableSelectAttribute(IDataAccesService dataAccesService)
        {
            DataAccesService = dataAccesService;
        }
        public QueryableSelectAttribute()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            var request = actionContext.HttpContext.Request;
            var username = GetUsername(request);

            IQueryable<Colonne> colonnes = DataAccessHelper.GetColonnes(username);

            var newSelectStringValues = getAllowedProperties(colonnes,request);
            var parvalues = "Nom,Prenom,Nas";
            // conserver le queryString de la request
            
            request.QueryString = new QueryString("?$select=" + newSelectStringValues);
            var queryString = request.QueryString.ToString();

            base.OnActionExecuting(actionContext);
        }

        private string GetUsername(HttpRequest request)
        {
            bool uname = request.Headers.TryGetValue("Authorization", out authorizationToken);
            string subs = authorizationToken.ToString().Substring(6, authorizationToken.ToString().Length - 6);
            byte[] data = Convert.FromBase64String(subs);
            string base64Decoded = System.Text.Encoding.ASCII.GetString(data);
            var arrUserNameandPassword = base64Decoded.Split(':');
            return arrUserNameandPassword[0];
        }

        private string initialQueryString(HttpRequest request)
        {
            if (request.QueryString.HasValue == false) { return null; }

            return request.QueryString.Value;
        }

        private string initialSelect(string query)
        {
            Uri myUri = new Uri("http://www.example.com" + query);
            return System.Web.HttpUtility.ParseQueryString(myUri.Query).Get("$select");
        }

        private List<string> getStringArray(string data)
        {
            if(data == "" || data == null) { return null; }
            List<string> res = data.Split(',').ToList();

            return res;
        }
        private string getAllowedProperties(IQueryable<Colonne> colonnes, HttpRequest request)
        {
            string allowedProperties;
            string intialQueryString = initialQueryString(request);
            string selectValue = initialSelect(intialQueryString);
            List<string> selectListValues = getStringArray(selectValue);
            List<string> employePropertyList = GetEmployePropertyNamesList();

            // si select list values est null j'envoie tous les propriétés de Employe moins les propriétés interdits
            if(selectListValues == null)
            {
                var propertyData = removeForbiddenProperties(employePropertyList, colonnes);
                allowedProperties = string.Join(",", propertyData);
                return allowedProperties;
            }
            // si select list values n'est pas null, j'envoie les propriétés du select moins les propriétés interdits
            var propertyData_ = removeForbiddenProperties(selectListValues, colonnes);
            allowedProperties = string.Join(",", propertyData_);
            return allowedProperties;
        }

        public List<String> removeForbiddenProperties(List<string> data , IQueryable<Colonne> colonnes)
        {
            foreach (String name in data.ToList())
            {
                string nameLowered = name.Trim().ToLower();
                foreach (Colonne col in colonnes)
                {
                    string colLowered = col.Nom.ToString().Trim().ToLower();
                    if (nameLowered.Equals(colLowered))
                    {
                        data.Remove(name);
                    }
                }
            }

            return data;
        }
        public List<string> GetEmployePropertyNamesList()
        {
            // get Employe properties
            Type t = typeof(Employe);
            PropertyInfo[] myPropertyInfo;
            // Get the properties of 'Type' class object.
           // myPropertyInfo = Type.GetType("Employe").GetProperties();
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            List<string> res = new List<string>();
            foreach (var propInfo in propInfos)
            {
                res.Add(propInfo.Name);                
            
            }
            return res;
        }
    }
}
