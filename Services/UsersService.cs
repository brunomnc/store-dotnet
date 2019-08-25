using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Domain.Services;
using meetapp_dotnet.Domain.Repositories;
using meetapp_dotnet.Domain.Services.Communication;

namespace meetapp_dotnet.Services
{
  public class UsersService : IUsersService
  {
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UsersService(IUsersRepository categoryRepository, IUnitOfWork unitOfWork)
    {
      _usersRepository = categoryRepository;
      _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Users>> ListAsync()
    {
      return await _usersRepository.ListAsync();
    }

    public async Task<SaveUserResponse> SaveAsync(Users user)
    {
      try
      {
        await _usersRepository.AddAsync(user);
        await _unitOfWork.CompleteAsync();

        return new SaveUserResponse(user);
      }
      catch (Exception ex)
      {
        return new SaveUserResponse($"error: {ex.Message}");
      }
    }
  }
}