using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
           // Uri baseAddress = new Uri("http://localhost:63271");
            Uri baseAddressTcp = new Uri("net.tcp://localhost:6790");


            //ServiceHost host = new ServiceHost(typeof(TestService.Service), new Uri[] { baseAddress, baseAddressTcp });

            ServiceHost host = new ServiceHost(typeof(TestService.Service), baseAddressTcp);

            ServiceEndpoint seTcp = host.AddServiceEndpoint(typeof(TestService.IService), new NetTcpBinding(), baseAddressTcp);
            seTcp.Name = "TcpEndPoint";

            //ServiceEndpoint se = host.AddServiceEndpoint(typeof(TestService.IService), new BasicHttpBinding(), baseAddress);

            ServiceMetadataBehavior b = new ServiceMetadataBehavior();
            host.Description.Behaviors.Add(b);


            ServiceEndpoint seMexTcp = host.AddServiceEndpoint(typeof(IMetadataExchange),
                                                                MetadataExchangeBindings.CreateMexTcpBinding(),
                                                                "net.tcp://localhost:6790/mex");
            

            host.Open();

            foreach (var item in host.Description.Endpoints)
            {
                Console.WriteLine("Starteddd Your Service.....");
                Console.WriteLine(item.Address);
                Console.WriteLine(item.Binding.Name);
                Console.WriteLine(item.Contract.ContractType);
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();

            host.Close();

        }
    }
}
