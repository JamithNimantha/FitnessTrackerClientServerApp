using FitnessTrackerClientApp.DTO;
using System;
using System.Linq;
using System.Net.Http;

namespace FitnessTrackerClientApp.Service
{
    public class UserService
    {
        private static UserService instance;
        private static readonly object lockObject = new object();

        public static UserService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new UserService();
                        }
                    }
                }
                return instance;
            }
        }

        public bool Authenticate(string Username, string Password)
        {
            try
            {
                var dto = new LoginUserDTO()
                {
                    UserName = Username,
                    Password = Password
                };

                var client = new RestClient(RestClient.BaseUrl + RestClient.AuthUrl);
                string token = client.PostData<string>(dto);
                if (token != null && !string.IsNullOrEmpty(token))
                {
                    RestClient.BearerToken = token;
                    return true;
                }
                return false;
            } catch (HttpRequestException)
            {
               return false;
            }
        }

        

        public UserDTO AddUser(RegisterUserDTO User)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.RegisterUserUrl);
            var _user = client.PostData<UserDTO>(User);

            return _user;
        }


        public UserDTO UpdateUser(UserDTO UpdatedUser)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.UserUrl + "/" + UpdatedUser.UserName, RestClient.BearerToken);
            UpdatedUser = client.PutData<UserDTO>(UpdatedUser);

            return UpdatedUser;
        }

        public UserDTO UpdateUserPassword(UpdatePasswordDTO UpdatedPassword)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.UserUrl + "/ChangePassword", RestClient.BearerToken);
            var UpdatedUser = client.PutData<UserDTO>(UpdatedPassword);

            return UpdatedUser;
        }

        internal UserDTO FindUserByUserName(string userName)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.UserUrl + "/" + userName, RestClient.BearerToken);
            var UpdatedUser = client.FetchData<UserDTO>();

            return UpdatedUser;
        }
    }




    
}
