using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Models.OutputModel;

namespace P7CreateRestApi.Services
{
    public interface IUserService
    {
        public Task<List<UserOutputModel>> List();
        public Task<UserOutputModel?> Create(UserInputModel inputModel);
        public UserOutputModel? Get(int id);
        public Task<UserOutputModel?> Update(int id, UserInputModel inputModel);
        public Task<UserOutputModel?> Delete(int id);
    }
}
