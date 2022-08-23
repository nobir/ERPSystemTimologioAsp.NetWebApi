using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TokenRepo : IRepoToken<Token, string, bool>
    {
        private static TimologioContext db;
        public TokenRepo(TimologioContext db)
        {
            TokenRepo.db = db;
        }

        public bool Create(Token obj)
        {
            db.Tokens.Add(obj);

            return db.SaveChanges() > 0;
        }

        public bool Delete(string key)
        {
            var token = db.Tokens.Where(t => t.Token1 == key).SingleOrDefault();

            if (token == null)
            {
                return false;
            }

            db.Users.Attach(token.User);

            return db.SaveChanges() > 0;
        }

        public Token Get(string key)
        {
            return db.Tokens.Where(t => t.Token1.Equals(key)).SingleOrDefault();
        }

        public Token GetByTokenKeyUserIdExpiredNull(int user_id, string key)
        {
            return db.Tokens.SingleOrDefault(t => t.UserId == user_id && t.Token1.Equals(key) && t.ExpiredAt == null);
        }

        public List<Token> Gets()
        {
            return db.Tokens.ToList();
        }

        public bool Update(Token obj)
        {
            var token = db.Tokens.Where(t => t.Id == obj.Id).SingleOrDefault();

            if (token == null)
            {
                return false;
            }

            db.Entry(token).CurrentValues.SetValues(obj);

            return db.SaveChanges() > 0;
        }
    }
}
