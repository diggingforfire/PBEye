using System;
using PBEye.Service;

namespace PBEye.CLI
{
	class Program
	{
		static void Main(string[] args)
		{
			var url = "";
			var username = "";
			var password = "";
			var vsService = new VsService($"https://{url}.visualstudio.com/", username, password);

			//var workItems = vsService.GetWorkItems();

			//foreach (var workItem in workItems)
			//{
			//	Console.WriteLine("#{0} - {1}", workItem.Id, workItem.Title);
			//}

			var workItem = vsService.GetWorkItem(13458);

			Console.WriteLine("#{0} - {1}", workItem.Id, workItem.Title);

			Console.ReadKey(true);

		}
	}
}
