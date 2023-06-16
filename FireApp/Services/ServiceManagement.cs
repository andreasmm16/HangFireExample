namespace FireApp.Services
{
    public class ServiceManagement : IServiceManagement
    {
        public void GenerateMerchandise()
        {
            Console.WriteLine($"Generate player Merchandise: Task Running at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }

        public void SendContract()
        {
            Console.WriteLine($"Sending player contract: Task Running at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }

        public void UpdateDatabase()
        {
            Console.WriteLine($"Updating database....: Task Running at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }
    }
}
