using Rodriguez_Camani_Feresin_Backend.Models;
using Rodriguez_Camani_Feresin_Backend;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces;

namespace TPI_Integrador_Prog3.Data.Implementations
{
    public class ClientRepository : Repository, IClientRepository
    {
        public ClientRepository(RodriguezCamaniFeresinContext context) : base(context)
        {
        }
        public void CreateClient(User user)
        {
            _context.Users.Add(user);
            //_context.SaveChanges();
        }

        //public BaseResponse ValidateUser(AuthenticateDto authenticatedto)
        //{
        //    BaseResponse response = new BaseResponse();
        //    User? user = _context.Users.SingleOrDefault(u => u.UserName == authenticatedto.UserName);
        //    if (user != null)
        //    {
        //        if (user.Password == authenticatedto.Password)
        //        {
        //            response.Result = true;
        //            response.Message = "Logged In";
        //        }
        //        else
        //        {
        //            response.Result = false;
        //            response.Message = "Incorrect Password";
        //        }
        //    }
        //    else
        //    {
        //        response.Result = false;
        //        response.Message = "Incorrect Email";
        //    }
        //    return response;
        //}

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        //public void CreateReview(Review review)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateReview(Review updatereview)
        //{
        //    throw new NotImplementedException();
        //}
    }
}