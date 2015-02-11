using InstagramCSharp.Endpoints;

namespace InstagramCSharp
{
    public class InstagramClient
    {
        private string accessToken;
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }
        public string AccessToken { get { return this.accessToken; } set { this.accessToken = value; CreateEndpointsObjects(); } }
        public CommentEndpoints CommentEndpoints { get; private set; }
        public GeographyEndpoints GeographyEndpoints { get; private set; }
        public LocationEndpoints LocationEndpoints { get; private set; }
        public LikeEndpoints LikeEndpoints { get; private set; }
        public MediaEndpoints MediaEndpoints { get; private set; }
        public UserEndpoints UserEndpoints { get; private set; }
        public TagEndpoints TagEndpoints { get; private set; }
        public RelationshipEndpoints RelationshipEndpoints { get; private set; }
        public SubscriptionsEndpoints SubscriptionsEndpoints { get; private set; }
        public InstagramClient(string clientId, string clientSecret, string accessToken)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.AccessToken = accessToken;
            CreateEndpointsObjects();
        }       
        private void CreateEndpointsObjects()
        {
            this.CommentEndpoints = new CommentEndpoints(this.AccessToken);
            this.GeographyEndpoints = new GeographyEndpoints(this.ClientId);
            this.LocationEndpoints = new LocationEndpoints(this.AccessToken);
            this.LikeEndpoints = new LikeEndpoints(this.AccessToken);
            this.MediaEndpoints = new MediaEndpoints(this.AccessToken);
            this.UserEndpoints = new UserEndpoints(this.ClientId, this.AccessToken);
            this.TagEndpoints = new TagEndpoints(this.AccessToken);
            this.RelationshipEndpoints = new RelationshipEndpoints(this.AccessToken);
            this.SubscriptionsEndpoints = new SubscriptionsEndpoints(this.ClientId, this.ClientSecret);
        }       
    }
}
