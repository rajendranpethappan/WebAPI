using ItermService.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Web.Http;
using WebGrease;

namespace ItermService.Controllers
{
    public class ItemController : ApiController
    {
        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AllDetails> Get()
        {
            using (CategoryDBEntities entities = new CategoryDBEntities())
            {
                var itemResult = (from cat in entities.Categories
                                  join subcat in entities.SubCategories on cat.ID equals subcat.CategoryId
                                  join item in entities.Items on subcat.ID equals item.SubCategoryId
                                 
                                  select new AllDetails()
                                  {
                                      CategoryName = cat.CategoryName,
                                      SubCategoryName = subcat.SubCategoryName,
                                      ItemName = item.ItemName,
                                      ItemDescription = item.ItemDescription
                                  }).ToList<AllDetails>();

                return itemResult;
            }
        }


        /// <summary>
        /// Get the all Item
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<AllDetails> GetItem(string name)
        {
            using (CategoryDBEntities entities = new CategoryDBEntities())
            {
                var itemResult = (from cat in entities.Categories
                                  join subcat in entities.SubCategories on cat.ID equals subcat.CategoryId
                                  join item in entities.Items on subcat.ID equals item.SubCategoryId
                                  where item.ItemName.Contains(name)
                                  select new AllDetails()
                                  {
                                      CategoryName = cat.CategoryName,
                                      SubCategoryName = subcat.SubCategoryName,
                                      ItemName = item.ItemName,
                                      ItemDescription = item.ItemDescription
                                  }).ToList<AllDetails>();

                return itemResult;
            }
        }
      
        /// <summary>
        /// Delete API using category name
        /// </summary>
        /// <param name="name"></param>
        public void Delete(string name)
        {
            using (CategoryDBEntities entities = new CategoryDBEntities())
            {
                entities.Categories.Remove(entities.Categories.FirstOrDefault(p => p.CategoryName == name));
                entities.SaveChanges();
            }
        }
      

    }
}
