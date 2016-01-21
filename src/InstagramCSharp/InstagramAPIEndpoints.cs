namespace InstagramCSharp
{
    public static class InstagramAPIEndpoints
    {
        public static readonly string SelfUserInfoEndpoint = "/users/self";
        public static readonly string UserBasicInfoEndpoint = "/users/{0}";
        public static readonly string SelfRecentMediaEndpoint = "/users/self/media/recent";
        public static readonly string UserRecentMediaEndpoint = "/users/{0}/media/recent";
        public static readonly string UserLikedMediaEndpoint = "/users/self/media/liked";
        public static readonly string SearchUsersEndpoint = "/users/search";

        public static readonly string UserFollowsEndpoint = "/users/self/follows";
        public static readonly string UserFollowedByEndpoint = "/users/self/followed-by";
        public static readonly string RequestedByEndpoint = "/users/self/requested-by";
        public static readonly string RelationshipEndpoint = "/users/{0}/relationship";

        public static readonly string MediaInfoEndpoint = "/media/{0}";
        public static readonly string ShortCodeMediaInfoEndpoint = "/media/shortcode/{0}";
        public static readonly string SearchMediaEndpoint = "/media/search";

        public static readonly string CommentsEndpoint = "/media/{0}/comments";
        public static readonly string CommentEndpoint = "/media/{0}/comments/{1}";

        public static readonly string LikesEndpoint = "/media/{0}/likes";

        public static readonly string TagInfoEndpoint = "/tags/{0}";
        public static readonly string RecentTaggedMediaEndpoint = "/tags/{0}/media/recent";
        public static readonly string SearchTagEndpoint = "/tags/search";

        public static readonly string LocationInfoEndpoint = "/locations/{0}";
        public static readonly string RecentLocationgedMediaEndpoint = "/locations/{0}/media/recent";
        public static readonly string SearchLocationEndpoint = "/locations/search";
    }
}
