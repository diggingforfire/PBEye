using System.Collections.Generic;
using PBEye.Service.Models;

namespace PBEye.Service
{
    internal class DummyVsService : IVsService
    {
        public IList<WorkItem> GetWorkItems()
        {
            return new List<WorkItem>
            {
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" },
                new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course" }
            };
        }
    }
}