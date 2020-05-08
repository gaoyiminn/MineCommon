using Ruanmou.Libraries.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Libraries.DAL
{
    public class BaseDAL : IBaseDAL
    {

        private static string ConnectionStringCustomers = ConfigurationManager.ConnectionStrings["Customers"].ConnectionString;

        public bool Add<T>(T t) where T : Libraries.Model.BaseModel
        {
            Type type = t.GetType();
            string insertColumns = string.Join(",", type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Select(p => $"[{p.Name}]"));

            string valuesColums = string.Join(",", type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Select(p => $"@{p.Name}"));

            string sql = $"INSERT INTO [{type.Name}] ({insertColumns}) VALUES ({valuesColums})";

            var paras = type
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                .Select(p => new SqlParameter($"@{p.Name}", p.GetValue(t))).ToArray();

            using (SqlConnection conn = new SqlConnection(ConnectionStringCustomers))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddRange(paras);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete<T>(T t) where T : Libraries.Model.BaseModel
        {
            throw new NotImplementedException();
        }

        public T Find<T>(int id) where T : Libraries.Model.BaseModel
        {
            Type type = typeof(T);
            string sql = $"SELECT {string.Join(",", type.GetProperties().Select(p => $"[{p.Name}]"))} FROM {type.Name} where ID={id}";

            using (SqlConnection conn = new SqlConnection(ConnectionStringCustomers))
            {

                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return this.Trans<T>(type, reader);
                }
                else
                {
                    return null;
                }
            }
        }

        private T Trans<T>(Type type, SqlDataReader reader)
        {
            Object obj = Activator.CreateInstance(type);
            foreach (var prop in type.GetProperties())
            {
                prop.SetValue(obj, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
            }
            return (T)obj;
        }

        public List<T> FindAll<T>() where T : Libraries.Model.BaseModel
        {
            Type type = typeof(T);
            string sql = $"SELECT {string.Join(",", type.GetProperties().Select(p => $"[{p.Name}]"))} FROM [{type.Name}]";

            List<T> tList = new List<T>();
            using (SqlConnection conn = new SqlConnection(ConnectionStringCustomers))
            {

                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tList.Add(this.Trans<T>(type, reader));
                }

            }
            return tList;
        }

        public bool Update<T>(T t) where T : Libraries.Model.BaseModel
        {
            throw new NotImplementedException();
        }
    }
}
