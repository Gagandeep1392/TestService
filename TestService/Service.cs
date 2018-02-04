using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true,InstanceContextMode =InstanceContextMode.PerSession)]
    public class Service : IService
    {
        List<Country> m_lstCountry;

        public Service()
        {
            m_lstCountry = new List<Country>();
        }

        public void OpenConnection()
        {
        }

        public void CloseConnection()
        {

        }

        public void AddCountry(Country country)
        {
            m_lstCountry.Add(country);
        }

        public List<Country> GetCountriesAdded()
        {
            return m_lstCountry;
        }

        public string GetData()
        {
            return "Hello Gagandeep Kaur!!!";
        }

        public string GetMessage(string sName)
        {
            return "Mr/Ms " + sName;
        }

        public string GetAverage(Student objStudent)
        {
            double Avg = ((objStudent.Max1 + objStudent.Max2 + objStudent.Max3) / 3);
            if (Avg < 35)
                return "Fail";
            else
                return "Pass";
        }

        public int[] GetSortArray(int[] arr)
        {
            Array.Sort(arr);
            return arr;
        }

        public Student GetTopper(List<Student> s)
        {
            int iMax = 0;
            Student obj = s[0];

            foreach (Student stu in s)
            {
                int Avg = ((stu.Max1 + stu.Max2 + stu.Max3) / 3);
                if (Avg > iMax)
                {
                    iMax = Avg;
                    obj = stu;
                }
            }
            return obj;
        }


        public List<Country> GetCountries()
        {
            List<Country> lst = new List<Country>();

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SDO7QCB\MSSQLSERVER01;Initial Catalog=master;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("SELECT  * FROM [dbo].[Table] ", con);

            con.Open();

            SqlDataReader sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                Country country = new Country();
                country.Id = int.Parse(sqlReader[0].ToString());
                country.CountryName = sqlReader[1].ToString();
                lst.Add(country);
            }
            return lst;
        }


       
    }


    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Max1 { get; set; }
        [DataMember]
        public int Max2 { get; set; }
        [DataMember]
        public int Max3 { get; set; }

        [DataMember]
        public int Max4 { get; set; }
    }

    [DataContract]
    public class Country
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CountryName { get; set; }
    }
}
