using System;
using System.Collections.Generic;
using PBEye.Service;
using PBEye.Service.Models;

namespace PBEye.CLI
{
	internal class Program
	{
		private static VsService service;
		private static bool running;
		private static bool loggedIn;
		private static string team;

		private static void Main(string[] args)
		{
			running = true;
			
			Loop();
		}

		private static void Loop()
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine(Resources.Logo);

				if (!loggedIn)
				{
					Login();
					return;
				}

				Menu();

				if (!running)
				{
					break;
				}
			}
		}

		private static void Menu()
		{
			Console.WriteLine(Resources.Menu);
			Console.WriteLine(Resources.ChooseAnAction);
			Console.WriteLine(Resources.LineSeperator);

			var actions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>( Resources.SingleWorkItem, SingleWorkItem ),
				new KeyValuePair<string, Action>( Resources.AllWorkItems, AllWorkItems ),
				new KeyValuePair<string, Action>( Resources.Close, Close )
			};


			for (int i = 0; i < actions.Count; i++)
			{
				var action = actions[i];

				Console.WriteLine($"{i + 1}) {action.Key}");
			}

			var option = LabeledInput(Resources.Option);

			int o;
			if (int.TryParse(option, out o) && o > 0 && o <= actions.Count)
			{
				actions[o - 1].Value.Invoke();
			}
			else
			{
				Console.WriteLine(Resources.InvalidOption);
				Console.ReadKey(true);
			}

		}

		private static void Close()
		{
			running = false;
		}

		private static void AllWorkItems()
		{
			Console.WriteLine(Resources.AllWorkItems);

			var workItems = service.GetWorkItems();

			foreach (var workItem in workItems)
			{
				PrintWorkItem(workItem);
			}

			Console.WriteLine(Resources.PressAnyKey);
			Console.ReadKey(true);
		}

		private static void SingleWorkItem()
		{
			Console.WriteLine(Resources.SingleWorkItem);

			var workItemId = LabeledInput(Resources.WorkItemId);

			int wii = 0;

			if (!int.TryParse(workItemId, out wii))
			{
				SingleWorkItem();
			}

			var workItem = service.GetWorkItem(wii);

			PrintWorkItem(workItem);

			Console.WriteLine(Resources.PressAnyKey);
			Console.ReadKey(true);
		}

		private static void PrintWorkItem(WorkItem workItem)
		{
			Console.WriteLine($"Work Item #{workItem.Id} - {workItem.Title}");
			Console.WriteLine($"Story Points: {workItem.Effort}");
			Console.WriteLine($"Sprint: {workItem.Sprint}");
			Console.WriteLine($"State: {workItem.State}");
			Console.WriteLine($"Team: {workItem.Team}");
			Console.WriteLine($"TypeOfWork: {workItem.Raw.GetField("snappet.SnappetScrum.TypeofWork")}");
		}

		private static void Login()
		{
			var urlOrPart = LabeledInput(Resources.VisualStudioSubdomainOrFullUrl);
			var username = LabeledInput(Resources.UserName);
			var password = LabeledInput(Resources.Password);

			Uri url;
			if (!Uri.TryCreate(urlOrPart, UriKind.Absolute, out url))
			{
				url = new Uri($"https://{urlOrPart}.visualstudio.com/");
			}

			service = new VsService(url.ToString(), username, password);

			loggedIn = true;
		}

		private static string LabeledInput(string label)
		{
			Console.Write($"{label}: ");
			var value = Console.ReadLine();
			return value;
		}
	}
}
