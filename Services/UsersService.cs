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

    public async Task<UserResponse> SaveAsync(Users user)
    {
      try
      {
        await _usersRepository.AddAsync(user);
        await _unitOfWork.CompleteAsync();

        return new UserResponse(user);
      }
      catch (Exception ex)
      {
        return new UserResponse($"error: {ex.Message}");
      }
    }

    public async Task<UserResponse> UpdateAsync(int id, Users user)
    {
      var userExists = await _usersRepository.FindByIdAsync(id);

      if (userExists == null)
      {
        return new UserResponse("User not found");
      }

      userExists.Name = user.Name;

      try
      {
        _usersRepository.Update(userExists);
        await _unitOfWork.CompleteAsync();

        return new UserResponse(userExists);
      }
      catch (Exception e)
      {
        return new UserResponse($"error : {e.Message}");
      }
    }

    public async Task<UserResponse> DeleteAsync(int id)
    {
      var userExists = await _usersRepository.FindByIdAsync(id);

      if (userExists == null)
      {
        return new UserResponse("User not found");
      }

      try
      {
        _usersRepository.Remove(userExists);
        await _unitOfWork.CompleteAsync();

        return new UserResponse(userExists);
      }
      catch (Exception e)
      {
        return new UserResponse($"error: {e.Message}");
      }
    }
  }
}