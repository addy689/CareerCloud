﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyDescriptionRepository : IDataRepository<CompanyDescriptionPoco>
    {
        public void Add(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=ADDY-PC\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True"))
            {
                conn.Open();

                foreach (var poco in items)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Descriptions]
                                                        (
                                                           [Id]
                                                          ,[Company]
                                                          ,[LanguageID]
                                                          ,[Company_Name]
                                                          ,[Company_Description]
                                                        )
                                                        VALUES
                                                        (
                                                           @Id
                                                          ,@Company
                                                          ,@LanguageID
                                                          ,@Company_Name
                                                          ,@Company_Description
                                                        )";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            CompanyDescriptionPoco[] result = new CompanyDescriptionPoco[700];

            using (SqlConnection conn = new SqlConnection(@"Data Source=ADDY-PC\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                                ,[Company]
                                                ,[LanguageID]
                                                ,[Company_Name]
                                                ,[Company_Description]
                                                ,[Time_Stamp]
                                                FROM [JOB_PORTAL_DB].[dbo].[Company_Descriptions]";

                SqlDataReader rdr = cmd.ExecuteReader();

                int i = 0;
                while (rdr.Read())
                {
                    CompanyDescriptionPoco poco = new CompanyDescriptionPoco();
                    poco.Id = rdr.GetGuid(0);
                    poco.Company = rdr.GetGuid(1);
                    poco.LanguageId = rdr.GetString(2);
                    poco.CompanyName = rdr.GetString(3);
                    poco.CompanyDescription = rdr.GetString(4);

                    int bufferSize = (int)rdr.GetBytes(5, 0, null, 0, 0);
                    poco.TimeStamp = new byte[bufferSize];
                    rdr.GetBytes(5, 0, poco.TimeStamp, 0, bufferSize);

                    result[i++] = poco;
                }

                conn.Close();
            }

            return result.Where(t => t != null).ToList();
        }

        public IList<CompanyDescriptionPoco> GetAllSorted<TKey>(params Tuple<Func<CompanyDescriptionPoco, TKey>, ListSortDirection>[] orderProperties)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyDescriptionPoco> GetList(Func<CompanyDescriptionPoco, bool> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyDescriptionPoco> GetSearchResults<TKey>(Func<CompanyDescriptionPoco, bool> where, params Tuple<Func<CompanyDescriptionPoco, TKey>, ListSortDirection>[] orderProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Func<CompanyDescriptionPoco, bool> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            IList<CompanyDescriptionPoco> pocos = GetAll();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=ADDY-PC\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True"))
            {
                conn.Open();

                foreach (var poco in items)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = @"DELETE FROM [dbo].[Company_Descriptions]
                                                      WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=ADDY-PC\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True"))
            {
                conn.Open();

                foreach (var poco in items)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = @"UPDATE [dbo].[Company_Descriptions]
                                                 SET [Company] = @Company
                                                    ,[LanguageID] = @LanguageID
                                                    ,[Company_Name] = @Company_Name
                                                    ,[Company_Description] = @Company_Description
                                               WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}