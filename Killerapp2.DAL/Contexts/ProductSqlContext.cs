using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.DAL.Interfaces;
using Killerapp2.DAL.Base;
using Killerapp2.Domain;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Killerapp2.DAL.Contexts
{
    public class ProductSqlContext : BaseRepository, IProductRepository
    {
        public IEnumerable<Product> GetAllProduct()
        {
            using (IDbConnection db = OpenConnection())
            {
                db.Open();
                string query =
                    "Select p.ID, p.Naam, p.Price, p.Omschrijving, p.CategoryID, a.ID, a.Path FROM Product p, ProductAfbeelding a WHERE p.ProductAfbeeldingID = a.ID";
                return db.Query<Product>(query);
            }
        }
        public Product GetDetailPro(string id)
        {
            using (IDbConnection db = OpenConnection())
            {
                db.Open();
                string query = $"Select p.ID, p.Naam, p.Price, p.Omschrijving, p.CategoryID, a.ID, a.Path FROM Product p, ProductAfbeelding a WHERE p.ProductAfbeeldingID = a.ID AND p.ID = '{id}'";
                return db.QuerySingle<Product>(query);
            }
        }
        public void InsertIntoOrder(Order order)
        {
            using (IDbConnection db = OpenConnection())
            {
                    string s1Query = $"INSERT INTO [Order] VALUES('{order.GebruikerID}', '{order.ProductID}', '{order.Datum}', '{order.Status}')";
                    db.Execute(s1Query);
            }
            }
        }
    }
