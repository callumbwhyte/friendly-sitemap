using NPoco;

namespace Our.Umbraco.FriendlySitemap.Images.Persistence.Dtos
{
    [TableName("umbracoRelation")]
    internal class RelationDto
    {
        [Column("parentId")]
        public int ParentId { get; set; }

        [Column("childId")]
        public int ChildId { get; set; }

        [Column("relType")]
        public int RelationType { get; set; }
    }
}