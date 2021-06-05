using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Managing_Program.Model
{
    class Model
    {
        public static string connection;

        //-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲

        Model instance = null;

        public Model Instance { get { if (this.instance == null) { this.instance = new Model(); } return this.instance; } }

        //-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲

        public static void Create_Object(object obj, Type type)
        {
            if (type == typeof(Car))
            {
                using (IDbConnection connect = new SqlConnection(connection))
                {
                    Car car = (Car)obj;
                    connect.Query<Car>("INSERT INTO Car(Name,Color,Year) VALUES(@Name,@Color,@Year);", car);
                }
            }
            else if (type == typeof(_Order))
            {
                using (IDbConnection connect = new SqlConnection(connection))
                {
                    _Order order = (_Order)obj;
                    connect.Query<Car>("INSERT INTO _Order(Car_value,End_date_of_order,End_date_string) VALUES(@Car_value,@End_date_of_order,@End_date_string);", order);
                }
            }
        }

        //-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲

        public static List<T> Read_Objects<T>()
        {
            if (typeof(T) == typeof(Car))
            {
                using (IDbConnection connect = new SqlConnection(connection))
                {
                    return connect.Query<T>("SELECT * FROM Car;").ToList();
                }
            }
            else if (typeof(T) == typeof(_Order))
            {
                using (IDbConnection connect = new SqlConnection(connection))
                {
                    return connect.Query<T>("SELECT * FROM _Order;").ToList();
                }
            }
            return null;
        }

        //-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲

        public static void Update_Objects(object obj, Type type)
        {
            if (type == typeof(Car))
            {
                using (IDbConnection connect = new SqlConnection(connection))
                {
                    Car car = (Car)obj;
                    connect.Query<Car>("UPDATE Car SET Name=@Name, Color=@Color, Year=@Year WHERE Id=@Id;", car);
                }
            }
            else if (type == typeof(_Order))
            {
                using (IDbConnection connect = new SqlConnection(connection))
                {
                    _Order order = (_Order)obj;
                    connect.Query<Car>("UPDATE Order SET Car_value=@Car_value, Name=@Name, End_date_of_order=@End_date_of_order, End_date_string=@End_date_string WHERE Id=@Id;", order);
                }
            }
        }

        //-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲-̲

        public static void Delete_Objects(object obj, Type type)
        {

            if (type == typeof(Car))
            {
                using (IDbConnection connect = new SqlConnection(connection))
                {
                    Car car = (Car)obj;
                    connect.Query<Car>("DELETE FROM Car WHERE Id=@Id;", car);
                }
            }
            else if (type == typeof(_Order))
            {
                using (IDbConnection connect = new SqlConnection(connection))
                {
                    _Order order = (_Order)obj;
                    connect.Query<Car>("DELETE FROM Order WHERE Id=@Id;", order);
                }
            }
        }

    }
}
