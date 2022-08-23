using BLL.BOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TokenService
    {
        private static readonly Random random = new Random();

        public static bool Create(TokenDTO token)
        {
            token.Token1 = RandomString(64);
            token.CreatedAt = DateTime.Now;
            token.ExpiredAt = null;

            var _token = Mapping.Mapper.Map<Token>(token);

            return DataAccessFactory.GetTokenDataAccess().Create(_token);
        }

        public static bool Delete(string key)
        {
            return DataAccessFactory.GetTokenDataAccess().Delete(key);
        }

        public static TokenDTO Get(string key)
        {
            var token = Mapping.Mapper.Map<TokenDTO>(DataAccessFactory.GetTokenDataAccess().Get(key));

            return token;
        }

        public static TokenDTO GetByTokenKeyUserIdExpiredNull(int user_id, string key)
        {
            var token = Mapping.Mapper.Map<TokenDTO>(DataAccessFactory.GetTokenDataAccess().GetByTokenKeyUserIdExpiredNull(user_id, key));

            return token;
        }

        public static List<TokenDTO> Gets()
        {
            var tokens = Mapping.Mapper.Map<List<TokenDTO>>(DataAccessFactory.GetTokenDataAccess().Gets());

            return tokens;
        }

        public static bool Update(TokenDTO token)
        {
            var _token = Mapping.Mapper.Map<Token>(token);

            return DataAccessFactory.GetTokenDataAccess().Update(_token);
        }

        public static string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
