using NPoco;

namespace Our.Umbraco.FriendlySitemap.Images.Persistence.Dtos
{
    [TableName("umbracoNode")]
    internal class NodeDto
    {
        [Column("id")]
        public int NodeId { get; set; }

        [Column("parentId")]
        public int ParentId { get; set; }

        [Column("path")]
        public string Path { get; set; }

        [Column("trashed")]
        public bool Trashed { get; set; }
    }
}