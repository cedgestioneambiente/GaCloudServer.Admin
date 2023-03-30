using GaCloudServer.BusinnessLogic.Dtos.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Helpers
{
    public class NestedHelper
    {
        public static void BuildNestedStructure(GanttItemDto parent, Dictionary<long, GanttItemDto> nestedMap)
        {
            if (parent == null || nestedMap == null || parent.Children != null)
            {
                return;
            }

            parent.Children = new List<GanttItemDto>();
            foreach (var obj in nestedMap.Values)
            {
                if (obj.ParentId == parent.Id)
                {
                    parent.Children.Add(obj);
                    BuildNestedStructure(obj, nestedMap);
                }
            }
        }
    }
}
