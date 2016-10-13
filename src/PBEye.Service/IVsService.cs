using System.Collections.Generic;
using PBEye.Service.Models;

namespace PBEye.Service
{
	public interface IVsService
	{
		IList<WorkItem> GetWorkItems();
		WorkItem GetWorkItem(int id);
	}
}