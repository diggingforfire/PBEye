namespace PBEye.Service
{
    public class VsServiceFactory
    {
        public static IVsService GetService()
        {
            return new VsService();
        }
    }
}