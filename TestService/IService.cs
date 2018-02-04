using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{

    [ServiceContract(SessionMode = SessionMode.Required)]
    //[ServiceContract]
    public interface IService
    {
        [OperationContract(IsInitiating =true)]
       // [OperationContract(IsInitiating = true)]
        void OpenConnection();

        [OperationContract(IsTerminating = true)]
       // [OperationContract]
        void CloseConnection();

        [OperationContract]
        void AddCountry(Country country);

        [OperationContract]
        List<Country> GetCountriesAdded();

        [OperationContract]
        string GetData();

        [OperationContract]
        string GetMessage(string sName);

        [OperationContract]
        string GetAverage(Student s);

        [OperationContract]
        int[] GetSortArray(int[] arr);

        [OperationContract]
        Student GetTopper(List<Student> s);

        [OperationContract]
        List<Country> GetCountries();
    }




}
