using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstgramCSharp.Enums
{
    public enum AccessScopes
    {
        Basic=1, Comments=2,Relationships=3,Likes=4    
    }
    public enum RelationshipActions
    {
        Follow=1,Unfollow=2,Block=3,Unblock=4,Approve=5,Deny=6
    }
}
