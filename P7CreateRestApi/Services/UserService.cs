using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Identity;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Models.OutputModel;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        /// <summary>User Service Create method. Add user with password and role</summary>          
        /// <param name="inputModel">POCO User inputModel class object.</param>
        /// <return>POCO User OutputModel class object.</return> 
        /// <remarks></remarks>
        public async Task<UserOutputModel?> Create(UserInputModel inputModel)
        {
            var user = new User
            {
                UserName = inputModel.UserName,
                FullName = inputModel.FullName,
                Role = inputModel.Role,
            };
            var result = await _userManager.CreateAsync(user, inputModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, user.Role);
                return ToOutputModel(user);
            }
            return null;
        }
        /// <summary>User Service Delete method.</summary>          
        /// <param name="id">Id of the user to delete.</param>
        /// <return>POCO User OutputModel class object or null.</return> 
        /// <remarks></remarks>
        public async Task<UserOutputModel?> Delete(int id)
        {
            var user = _userRepository.FindById(id);
            if (user is not null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return ToOutputModel(user);
                }
            }
            return null;
        }
        /// <summary>User Service Get method.</summary>          
        /// <param name="id">Id of the user to find.</param>
        /// <return>POCO User OutputModel class object or null.</return> 
        /// <remarks></remarks>
        public UserOutputModel? Get(int id)
        {
            var user = _userRepository.FindById(id);
            if (user is not null)
            {
                return ToOutputModel(user);
            }
            return null;
        }
        /// <summary>User Service List method.</summary>                  
        /// <return>List of all Users (POCO OutputModel class objects).</return> 
        /// <remarks></remarks>
        public async Task<List<UserOutputModel>> List()
        {
            var list = new List<UserOutputModel>();
            var users = await _userRepository.FindAll();
            foreach (var user in users)
            {
                list.Add(ToOutputModel(user));
            }
            return list;
        }
        /// <summary>User Service Update method. If user found, update user (name, fullname, role)</summary>                  
        /// <param name="id">Id of the user to find.</param>
        /// <param name="inputModel">POCO User Input Model class object.</param>
        /// <return>POCO User Output Model class object.</return> 
        /// <remarks></remarks>
        public async Task<UserOutputModel?> Update(int id, UserInputModel inputModel)
        {
            var user = _userRepository.FindById(id);
            if (user is null)
            {
                return null;
            }
            /*if (!await _userManager.CheckPasswordAsync(user, inputModel.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, inputModel.Password);
            }*/
            else
            {
                user.UserName = inputModel.UserName;
                user.FullName = inputModel.FullName;
                user.Role = inputModel.Role;
                await _userManager.UpdateAsync(user);
            }
            return ToOutputModel(user);
        }

        /// <summary>User Service ToOutputModel method. 
        /// Set User OutputModel class object from DTO User class object properties.</summary>                  
        /// <param name="user">DTO User class object.</param>        
        /// <return>POCO User Output Model class object.</return> 
        /// <remarks></remarks>
        private UserOutputModel ToOutputModel(User user) => new UserOutputModel
        {
            Id = user.Id,
            UserName = user.UserName,
            Password = user.PasswordHash,
            FullName = user.FullName,
            Role = user.Role
        };
    }
}
