using Codebehind;
using Database;
using Microsoft.EntityFrameworkCore;
using Models.Endpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories
{
    public class RepositorySession
    {
        /// <summary>
        /// Agrega o actualiza una entidad
        /// </summary>
        /// <param name="account">Account</param>
        /// <returns>Numero de filas agregadas o modificadas</returns>
        public static int AddOrUpdate(Session session)
        {
            if (!Exist(x => x.IDAccount == session.IDAccount))
                using (var db = new Context())
                {
                    db.Sessions.Add(session);
                    return db.SaveChanges();
                }
            else
                return Update(session);
        }

        public static int Update(Session session)
        {
            using (var db = new Context())
            {
                db.Sessions.Update(session);
                return db.SaveChanges();
            }
        }

        public static Session Get(Expression<Func<Session, bool>> predicate)
        {
            using (var db = new Context())
            {
                return db.Sessions.SingleOrDefault(predicate);
            }
        }

        public static bool OnSession(string sessionToken, string idAccount)
        {
            using (var db = new Context())
            {
                if (Exist(x => x.IDAccount == idAccount))
                {
                    var session = db.Sessions.Single(x => x.IDAccount == idAccount);

                    if (session != null)
                        return session.SessionToken == sessionToken;
                }
                return false;
            }
        }

        public static bool Exist(Expression<Func<Session, bool>> predicate)
        {
            using (var db = new Context())
            {
                return db.Sessions.Any(predicate);
            }
        }
    }
}