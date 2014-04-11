using InstagramCSharp.Endpoints;

namespace InstagramCSharp
{
    public class InstagramClient
    {
        private string clientId;
        private string accessToken;
        private CommentEndpoints commentEndpoints;
        private GeographyEndpoints geographyEndpoints;
        private LocationEndpoints locationEndpoints;
        private LikeEndpoints likeEndpoints;
        private MediaEndpoints mediaEndpoints;
        private UserEndpoints userEndpoints;
        private TagEndpoints tagEndpoints;
        private RelationshipEndpoints relationshipEndpoints;
        public string ClientId { get { return this.clientId; } }
        public string AccessToken { get { return this.accessToken; } }
        public CommentEndpoints CommentEndpoints { get { return this.commentEndpoints; } }
        public GeographyEndpoints GeographyEndpoints { get { return this.geographyEndpoints; } }
        public LocationEndpoints LocationEndpoints { get { return this.locationEndpoints; } }
        public LikeEndpoints LikeEndpoints { get { return this.likeEndpoints; } }
        public MediaEndpoints MediaEndpoints { get { return this.mediaEndpoints; } }
        public UserEndpoints UserEndpoints { get { return this.userEndpoints; } }
        public TagEndpoints TagEndpoints { get { return this.tagEndpoints; } }
        public RelationshipEndpoints RelationshipEndpoints { get { return this.relationshipEndpoints; } }
        public InstagramClient(string clientId, string accessToken)
        {
            this.clientId = clientId;
            this.accessToken = accessToken;
            CreateEndpointsObjects();
        }        public void SetAccessToken(string accessToken)
        {
            this.accessToken = accessToken;
            CreateEndpointsObjects();
        }
        private void CreateEndpointsObjects()
        {
            this.commentEndpoints = new CommentEndpoints(this.accessToken);
            this.geographyEndpoints = new GeographyEndpoints(this.clientId);
            this.locationEndpoints = new LocationEndpoints(this.accessToken);
            this.likeEndpoints = new LikeEndpoints(this.accessToken);
            this.mediaEndpoints = new MediaEndpoints(this.accessToken);
            this.userEndpoints = new UserEndpoints(this.clientId, this.accessToken);
            this.tagEndpoints = new TagEndpoints(this.accessToken);
            this.relationshipEndpoints = new RelationshipEndpoints(this.accessToken);
        }

    }
}
