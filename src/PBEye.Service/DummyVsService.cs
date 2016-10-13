using System.Collections.Generic;
using System.Linq;
using PBEye.Service.Models;

namespace PBEye.Service
{
	internal class DummyVsService : IVsService
	{
		public IList<WorkItem> GetWorkItems()
		{
			return new List<WorkItem>
			{
				new WorkItem
				{
					Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course",
					Description = "Currently, rainbow charts & blue growth bar on Check page are a bit misleading, because they use user\'s ability on a subject immediately when pupil start answering in a subject (or maybe after 25 exercises, which is still too soon to be really reliable).\r\nSee attached screenshot for an example: at the start of the black line, the ability is changing very rapidly still.\r\n\r\nWe want to imporve this, and show the ability line only after 300 exercises have been answered. And use the same logic for calculating growth & target growth.\r\n\r\nIn scope of this PBI:\r\nHide line before 300th exercises made on the subject\r\nHide the target ability circle until we show a line\r\nShow a message in the rainbow until we have a line"
				   ,AcceptanceCriteria = "Line:\r\nIn rainbow chart, the pupil ability line (black line) must start at the 300th exercise in a subject (start of school carreer). Before that, the pupil ability line must be hidden. \r\n\r\nHide target ability circle\r\nBecause the message is over the rainbow we need to hide the target ability circle until we have a line.\r\nTarget ability circle should be hidden, until the 300th exercise\r\nMessage in rainbow\r\nUntil the 300th exercise on the subject, a message should be shown with some explanation."
				},
				new WorkItem { Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
				new WorkItem { Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
				new WorkItem { Id = "12332", Title = "Short description" },
				new WorkItem { Id = "12332", Title = "LOOOOOOOOOO OOOOOOOOOOOOOOOOOOOO OOOOOOOOOOOOOOOOOOOO OOOOOOOOnG [Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructionsaaaaaaaa a aaaaaaaaaaaaaaaa from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
				new WorkItem { Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
				new WorkItem { Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
				new WorkItem { Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
				new WorkItem { Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
				new WorkItem { Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
				new WorkItem { Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
				new WorkItem { Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
				new WorkItem { Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
				new WorkItem { Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
				new WorkItem { Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
				new WorkItem { Id = "12332", Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" }
			};
		}

		public WorkItem GetWorkItem(int id)
		{
			return GetWorkItems().FirstOrDefault(x => x.Id == id.ToString());
		}
	}
}