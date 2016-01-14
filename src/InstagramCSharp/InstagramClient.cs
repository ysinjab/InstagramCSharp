using InstagramCSharp.Endpoints;

namespace InstagramCSharp
{
    public class InstagramClient
    {
        
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }        
        public CommentEndpoints CommentEndpoints { get; private set; }       
        public LocationEndpoints LocationEndpoints { get; private set; }
        public LikeEndpoints LikeEndpoints { get; private set; }
        public MediaEndpoints MediaEndpoints { get; private set; }
        public UserEndpoints UserEndpoints { get; private set; }
        public TagEndpoints TagEndpoints { get; private set; }
        public RelationshipEndpoints RelationshipEndpoints { get; private set; }
        public SubscriptionsEndpoints SubscriptionsEndpoints { get; private set; }
        public InstagramClient(string clientId, string clientSecret)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;           
            CreateEndpointsObjects();
        }       
        private void CreateEndpointsObjects()
        {
            this.CommentEndpoints = new CommentEndpoints();            
            this.LocationEndpoints = new LocationEndpoints();
            this.LikeEndpoints = new LikeEndpoints();
            this.MediaEndpoints = new MediaEndpoints();
            this.UserEndpoints = new UserEndpoints();
            this.TagEndpoints = new TagEndpoints();
            this.RelationshipEndpoints = new RelationshipEndpoints();
            this.SubscriptionsEndpoints = new SubscriptionsEndpoints(this.ClientId, this.ClientSecret);
        }       
    }
}
