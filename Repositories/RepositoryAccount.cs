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
    public class RepositoryAccount
    {
        /// <summary>
        /// Agrega o actualiza una entidad
        /// </summary>
        /// <param name="account">Account</param>
        /// <returns>Numero de filas agregadas o modificadas</returns>
        public static int AddOrUpdate(Account account)
        {
            using (var db = new Context())
            {
                db.Accounts.Add(account);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// Obtiene una lista de entidades
        /// </summary>
        /// <returns>Lista de <see cref="Account"/></returns>
        public static List<Account> Get()
        {
            using (var db = new Context())
            {
                return db.Accounts.Include(x => x.UserRol).Select(x => new Account
                {
                    IDAccount = x.IDAccount,
                    Email = x.Email,
                    IDUserRol = x.IDUserRol,
                    UserRol = x.UserRol,
                    CreatedAt = x.CreatedAt
                }).ToList();
            }
        }
        /// <summary>
        /// Obtiene una entidad
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        /// <returns><see cref="Account"/></returns>
        public static Account Get(string id)
        {
            using (var db = new Context())
            {
                return db.Accounts.Include(x => x.UserRol).Select(x => new Account
                {
                    IDAccount = x.IDAccount,
                    Email = x.Email,
                    IDUserRol = x.IDUserRol,
                    UserRol = x.UserRol,
                    CreatedAt = x.CreatedAt
                }).Single(x => x.IDAccount == id);
            }
        }
        /// <summary>
        /// Obtiene una entidad
        /// </summary>
        /// <param name="predicate">Expresion LINQ</param>
        /// <returns><see cref="Account"/></returns>
        public static Account Get(Expression<Func<Account, bool>> predicate)
        {
            using (var db = new Context())
            {
                return db.Accounts.Include(x => x.UserRol).Select(x => new Account
                {
                    IDAccount = x.IDAccount,
                    Email = x.Email,
                    IDUserRol = x.IDUserRol,
                    UserRol = x.UserRol,
                    CreatedAt = x.CreatedAt
                }).Single(predicate);
            }
        }

        /// <summary>
        /// Comparador de contraseñas
        /// </summary>
        /// <param name="username">Usuario de la cuenta</param>
        /// <param name="value">Cadena de comparacion</param>
        /// <returns>True: si es correcta. False: si es incorrecta</returns>
        public static bool IsPasswordCorrect(string email, string value)
        {
            using (var db = new Context())
            {
                var account = db.Accounts.Single(x => x.Email == email);
                return account.PasswordHash == Security.SHA256Hash(value) ? true : false;
            }
        }
    }
}