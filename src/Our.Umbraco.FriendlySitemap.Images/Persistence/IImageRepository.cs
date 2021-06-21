using System.Collections.Generic;

namespace Our.Umbraco.FriendlySitemap.Images.Persistence
{
    public interface IImageRepository
    {
        IEnumerable<int> GetImages(int nodeId);

        IDictionary<int, IEnumerable<int>> GetChildren(int nodeId);

        IDictionary<int, IEnumerable<int>> GetDescendants(int nodeId);
    }
}