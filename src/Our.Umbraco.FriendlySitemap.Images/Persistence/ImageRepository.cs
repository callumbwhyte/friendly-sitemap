using System.Collections.Generic;
using System.Linq;
using NPoco;
using Our.Umbraco.FriendlySitemap.Images.Persistence.Dtos;
using Umbraco.Core.Persistence;
using Umbraco.Core.Scoping;

namespace Our.Umbraco.FriendlySitemap.Images.Persistence
{
    internal class ImageRepository : IImageRepository
    {
        private readonly IScopeProvider _scopeProvider;

        public ImageRepository(IScopeProvider scopeProvider)
        {
            _scopeProvider = scopeProvider;
        }

        public IEnumerable<int> GetImages(int nodeId)
        {
            using (var scope = _scopeProvider.CreateScope())
            {
                var sql = scope.SqlContext.Sql();

                GetBaseQuery(sql);

                sql.Where<NodeDto>(node => node.NodeId == nodeId);

                var data = scope.Database.Fetch<RelationDto>(sql);

                return data.Select(x => x.ChildId);
            }
        }

        public IDictionary<int, IEnumerable<int>> GetChildren(int nodeId)
        {
            using (var scope = _scopeProvider.CreateScope())
            {
                var sql = scope.SqlContext.Sql();

                GetBaseQuery(sql);

                sql.Where<NodeDto>(node => node.ParentId == nodeId);

                var data = scope.Database.Fetch<RelationDto>(sql);

                return data
                    .GroupBy(x => x.ParentId)
                    .ToDictionary(x => x.Key, x => x.Select(y => y.ChildId));
            }
        }

        public IDictionary<int, IEnumerable<int>> GetDescendants(int nodeId)
        {
            using (var scope = _scopeProvider.CreateScope())
            {
                var sql = scope.SqlContext.Sql();

                GetBaseQuery(sql);

                sql.Where<NodeDto>(node => node.Path.Contains("," + nodeId));

                var data = scope.Database.Fetch<RelationDto>(sql);

                return data
                    .GroupBy(x => x.ParentId)
                    .ToDictionary(x => x.Key, x => x.Select(y => y.ChildId));
            }
        }

        private Sql<ISqlContext> GetBaseQuery(Sql<ISqlContext> sql)
        {
            sql.Select<RelationDto>(x => x.ParentId, x => x.ChildId);

            sql.AndSelect<RelationTypeDto>(x => x.Id);

            sql.From<RelationDto>();

            sql.LeftJoin<NodeDto>().On<RelationDto, NodeDto>((relation, node) => relation.ChildId == node.NodeId || relation.ParentId == node.NodeId);

            sql.LeftJoin<RelationTypeDto>().On<RelationDto, RelationTypeDto>((relation, relationType) => relation.RelationType == relationType.Id);

            sql.Where<RelationTypeDto>(relationType => relationType.Alias == "umbMedia");

            sql.Where<NodeDto>(x => x.Trashed == false);

            return sql;
        }
    }
}