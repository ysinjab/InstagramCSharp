using InstagramCSharp.Endpoints;
using System;

namespace InstagramCSharp
{
    public class InstagramClient
    {

        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }
        public bool EnforceSignedRequests { get; private set; }
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
            if (string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentException("clientId can't be null or empty.");
            }
            if (string.IsNullOrEmpty(clientSecret))
            {
                throw new ArgumentException("clientSecret can't be null or empty.");
            }
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            CreateEndpointsObjects();
        }
        public InstagramClient(string clientId, string clientSecret, bool enforceSignedRequests)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentException("clientId can't be null or empty.");
            }
            if (string.IsNullOrEmpty(clientSecret))
            {
                throw new ArgumentException("clientSecret can't be null or empty.");
            }
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.EnforceSignedRequests = enforceSignedRequests;
            CreateEndpointsObjects();
        }
        private void CreateEndpointsObjects()
        {
            this.CommentEndpoints = new CommentEndpoints(this.ClientSecret, this.EnforceSignedRequests);
            this.LocationEndpoints = new LocationEndpoints(this.ClientSecret, this.EnforceSignedRequests);
            this.LikeEndpoints = new LikeEndpoints(this.ClientSecret, this.EnforceSignedRequests);
            this.MediaEndpoints = new MediaEndpoints(this.ClientSecret, this.EnforceSignedRequests);
            this.UserEndpoints = new UserEndpoints(this.ClientSecret, this.EnforceSignedRequests);
            this.TagEndpoints = new TagEndpoints(this.ClientSecret, this.EnforceSignedRequests);
            this.RelationshipEndpoints = new RelationshipEndpoints(this.ClientSecret, this.EnforceSignedRequests);
            this.SubscriptionsEndpoints = new SubscriptionsEndpoints(this.ClientId, this.ClientSecret);
        }
    }
}
