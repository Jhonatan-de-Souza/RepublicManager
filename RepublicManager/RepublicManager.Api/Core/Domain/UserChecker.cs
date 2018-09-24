using Microsoft.Extensions.Configuration;

namespace RepublicManager.Api.Core.Domain
{
    public class UserChecker
    {
        private IConfiguration _configuration;

        public UserChecker(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User Find(string userID,IUnitOfWork _unitOfWork)
        {
            var usuario = _unitOfWork.Users.GetById(userID);
            //implement finding the user here
            //return conexao.QueryFirstOrDefault<User>(
            //    "SELECT UserID, AccessKey " +
            //    "FROM dbo.Users " +
            //    "WHERE UserID = @UserID", new { UserID = userID });
            return usuario;

        }
    }
}
