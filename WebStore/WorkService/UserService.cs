using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.Controllers;
using WebStore.Models;
using WebStoreData.Models;
using WebStoreData.Repository;

namespace WebStore.WorkService
{
    public class UserService
    {
        public UserController.Response CreateAccount(WebStore.Models.User user)
        {
             UserController.Response response=new UserController.Response();
            WebStoreData.Models.User newUser = new WebStoreData.Models.User();
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.Password = user.Password;
            newUser.UserId = user.UserId;
            newUser.Email = user.Email;
            UserRepository userRepository=new UserRepository();
            WebStoreData.Models.User userDB=userRepository.GetUserByEmail(newUser.Email);
            if (userDB != null)
            {
                response.IsCreate = false;
                response.Massange = "Fail. Account with this email already exists";
            }
            else
            {
                userRepository.Create(newUser);
                response.IsCreate = true;
                response.Massange = "Success. Account was create";
            }
            return response;
        }
    }
}