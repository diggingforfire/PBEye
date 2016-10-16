using System.Collections.Generic;
using System.Threading.Tasks;
using PBEye.Service.Models;
using PBEye.Service.Models.WorkItem;

namespace PBEye.Service
{
	public interface IVsService
	{
		Task Login(string organization, string username, string password);
		void Logout();
		Task<IList<Project>> GetProjects();
		Task<IList<Team>> GetTeams(Project project);
		Task<IList<Iteration>> GetIterations(Project project, Team team);
		Task<IList<WorkItem>> GetWorkItems(Project project, Team team, Iteration iteration);
	}
}