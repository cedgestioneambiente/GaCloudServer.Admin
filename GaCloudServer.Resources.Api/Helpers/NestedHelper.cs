using GaCloudServer.BusinnessLogic.Dtos.Custom;
using GaCloudServer.Resources.Api.Dtos.Custom;

namespace GaCloudServer.Resources.Api.Helpers
{
    public static class NestedHelper
    {
        public static void BuildNestedStructure(GanttItemDto parent, Dictionary<int, GanttItemDto> nestedMap)
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
