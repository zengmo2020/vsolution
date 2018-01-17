using v.CMS.Core.Domain.Posts;

namespace v.CMS.Data.Mapping.Posts
{
    public partial class PostMap : VEntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            this.ToTable("Post");
            this.HasKey(o => o.Id);
            this.Property(o => o.Title);
            this.Property(o => o.Content);
        }
    }
}
