﻿using System;
using System.Collections.Generic;

namespace PBEye.Service.Models.WorkItem
{
	internal class WorkItemsResult
	{
		public string QueryType { get; set; }
		public string QueryResultType { get; set; }
		public DateTime AsOf { get; set; }
		public List<WorkItemMeta> WorkItems { get; set; }
	}
}