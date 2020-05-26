using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop
{
    public static class SessionExtensions
    {
        public static void SetUserName(this ISession session, string username)
        {
            session.SetString("username", username);
        }

        public static string GetUserName(this ISession session)
        {
            return session.GetString("username");
        }

        public static void SetUserId(this ISession session, int userId)
        {
            session.SetInt32("userId", userId);
        }

        public static int GetUserId(this ISession session)
        {
            return session.GetInt32("userId").Value;
        }

        public static void SetIsAdmin (this ISession session, bool IsAdmin)
        {
            session.SetInt32("IsAdmin", IsAdmin ? 1 : 0) ;
        }

        public static bool GetIsAdmin(this ISession session)
        {
            return session.GetInt32("IsAdmin") == 1;    
        }   
    }
}
