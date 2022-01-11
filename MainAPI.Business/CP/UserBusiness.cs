using MainAPI.Data.Interface;
using MainAPI.Models;
using MainAPI.Models.CP;
using MainAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Business.CP
{
    public class UserBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseMessage<List<User>>> GetUsers()
        {
            ResponseMessage<List<User>> responseMessage = new ResponseMessage<List<User>>();
            try
            {
                responseMessage.Data = await _unitOfWork.CpUsers.GetAll();
                responseMessage.StatusCode = 200;
                responseMessage.Message = "Request successful";
            }
            catch (Exception ex)
            {
                responseMessage.StatusCode = 203;
                responseMessage.Message = "Something went wrong; Error = "+ex;
                responseMessage.Data = default;
            }
                return responseMessage;
        }
        public async Task<User> GetUserByID(Guid id) =>
           await _unitOfWork.CpUsers.Find(id);

        public async Task<User> GetUserByUsername(string username) =>
           await _unitOfWork.CpUsers.GetOneBy(x => x.Username == username);

        public async Task<User> GetUserByEmail(string email) =>
           await _unitOfWork.CpUsers.GetOneBy(x => x.Email == email);

        public async Task<ResponseMessage<int>> Create(User user, Person person)
        {
            ResponseMessage<int> responseMessage = new ResponseMessage<int>();
            try
            {
                user.ID = Guid.NewGuid();
                user.Password = EncryptionService.Encrypt(user.Password);

                person.UserID = user.ID;
                person.ID = Guid.NewGuid();

                await _unitOfWork.CpUsers.Create(user);
                await _unitOfWork.CpPersons.Create(person);

                if (await _unitOfWork.Commit() > 0)
                {
                    responseMessage.StatusCode = 200;
                    responseMessage.Message = "Request successful";
                }
                else
                {
                    responseMessage.StatusCode = 201;
                    responseMessage.Message = "Request not successful";
                    responseMessage.Data = default;
                }
            }
            catch (Exception)
            {
                responseMessage.StatusCode = 203;
                responseMessage.Message = "Something went wrong.";
                responseMessage.Data = default;
            }

            return responseMessage;
        }

        public async Task<ResponseMessage<LogInParams>> VerifyUser(LogInParams logInParams)
        {
            ResponseMessage<LogInParams> responseMessage = new ResponseMessage<LogInParams>();
            try
            {
                User user = await GetUserByEmail(logInParams.UsernameOrEmail);

                responseMessage.StatusCode = 201;
                responseMessage.Message = "Request not successful";
                responseMessage.Data = default;

                if (user == null)
                    user = await GetUserByUsername(logInParams.UsernameOrEmail);
                string Password = user.Password;

                logInParams.User = user;

                if (user != null)
                {
                    if (EncryptionService.Validate(logInParams.Password, Password))
                    {
                        logInParams.IsVerified = true;
                        responseMessage.Data = logInParams;
                        responseMessage.StatusCode = 200;
                        responseMessage.Message = "Request successful";
                    }
                }
            }
            catch (Exception)
            {
                responseMessage.StatusCode = 203;
                responseMessage.Message = "Something went wrong";
                responseMessage.Data = default;
            }

            return responseMessage;
        }

        //public async Task Update(User user)
        //{
        //    _UnitOfWork.User.Update(user);
        //    int response = await _UnitOfWork.Commit();
        //    if (response != 1) _UnitOfWork.Dispose();
        //}

        //public async Task Delete(Guid id)
        //{
        //    var entity = await GetAccountByID(id);
        //    _UnitOfWork.User.Delete(entity);
        //}
    }
}
