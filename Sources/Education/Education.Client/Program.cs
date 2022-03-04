using Education.Common.ServiceContracts.ServiceContract;
using Education.Common.ServiceContracts.ServiceEntityContract;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Education.Client
{
    class Program
    {
        #region Consts
        private const string Host = "192.168.105.11";
        private const int Port = 5000;
        #endregion

        static async Task Main()
        {
            await Task.Delay(5000);
            string guid = Guid.NewGuid().ToString();
            string target = $"{Host}:{Port}";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(target);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Title = "Service Client version 1.0";
            Channel channel = new Channel(target, ChannelCredentials.Insecure);

            try
            {
                ServiceContract.ServiceContractClient client = new ServiceContract.ServiceContractClient(channel);

                #region Connection
                //------------------ Connection ------------------
                ConnectResponse response = await client.ConnectAsync(new EmptyContract());
                Console.WriteLine($"Connection: {response}");
                Console.WriteLine();
                #endregion
            }
            catch (RpcException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                channel.ShutdownAsync().Wait();
                Console.WriteLine("Client Shutdown");
                Console.ReadLine();
            }
        }
    }
}
