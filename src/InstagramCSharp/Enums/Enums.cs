
namespace InstagramCSharp.Enums
{
    public enum AccessScopes
    {
        Basic=1, Comments=2,Relationships=3,Likes=4    
    }
    public enum RelationshipActions
    {
        Follow=1,Unfollow=2,Block=3,Unblock=4,Approve=5,Deny=6
    }
    public enum RealTimeAspects 
    { 
        Media = 1
    }
    public enum RealTimeObjects
    {
        User = 1, Tag = 2, Location = 3, Geography = 4, All = 5 
    }
}
