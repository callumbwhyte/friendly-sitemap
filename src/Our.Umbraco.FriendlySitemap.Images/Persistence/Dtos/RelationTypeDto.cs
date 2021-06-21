using NPoco;

namespace Our.Umbraco.FriendlySitemap.Images.Persistence.Dtos
{
    [TableName("umbracoRelationType")]
    internal class RelationTypeDto
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("alias")]
        public string Alias { get; set; }
    }
}