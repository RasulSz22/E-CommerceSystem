using E_CommerceSystem.BLL.Model;
using E_CommerceSystem.DTOs.AppUserDTO;
using E_CommerceSystem.Entities.Identity;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.BLL.Servicess.Interfaces 
{
    public interface IAccountService
    {
        public Task<IDataResult<string>> SignUp(UserCreateDTO dto, string role);
        public Task<IResult> VerifyEmail(string token, string email);
        public Task<IResult> Login(LoginDTO dto, bool IsAdminPanel);
        public Task<IResult> Logout();
        public Task<IResult> ForgetPassword(string email);
        public Task<IDataResult<ResetPasswordDTO>> GetResetPassword(string email, string token);
        public Task<IResult> ResetPasswordPost(ResetPasswordDTO dto);
        public Task<IResult> Update(UserUpdateDTO dto);
        public Task<PagginatedResponse<AppUser>> GetAllUsers(int count, int page);
        public Task<PagginatedResponse<AppUser>> GetAllAdmin(int count, int page);
        public Task<AppUser> GetUser(string id);
        public Task<bool> ChangeRole(string userId, string newRoleId);
        //public Task<IResult> RegisterWithGoogle(string returnUrl = null);
        //public Task<IResult> GoogleCallback(string returnUrl = null);
        //public Task<IResult> ChangeUserActivationStatus(string email, bool activate);
    }
}
