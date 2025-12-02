using task.core.DTOs.Paginator;
using task.core.DTOs.Response;
using task.core.DTOs.Users;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;
using WMSGlobal.Infrastructure.Helpers;

namespace task.Infrastructure.UseCases
{
    public class UserUseCase(IUserRepository userRepository, ILogService logService) : IUserUseCase
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ILogService _logService = logService;

        public async Task<ResponseDTO> CreateUser(CreateUserDTO user)
        {
            try
            {
                var (passwordHashed, salt) = PasswordHashHelper.HashPassword(user.PasswordHashUser);
                user.PasswordHashUser = passwordHashed;
                user.PasswordSaltUser = salt;

                if (!string.IsNullOrWhiteSpace(user.UserImage))
                {
                    try
                    {
                        byte[] imageBytes = Convert.FromBase64String(user.UserImage);
                        string fileName = ImagePathHelper.GenerateUniqueFileNameFromBytes(imageBytes);

                        ImagePathHelper.EnsureDirectoryExists("users", ImagePathHelper.ImageType.User);

                        string fullPath = ImagePathHelper.GetFullImagePath("users", ImagePathHelper.ImageType.User, fileName);
                        await File.WriteAllBytesAsync(fullPath, imageBytes);
                        user.UserImage = fileName;
                    }
                    catch (Exception ex)
                    {
                        await _logService.SaveLogsMessagesAsync($"Error processing user image: {ex.Message}");
                        user.UserImage = string.Empty;
                    }
                }

                return await _userRepository.CreateUser(user);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetBase64ImageByFileName(string fileName, int fileType)
        {
            try
            {
                ImagePathHelper.ImageType imageType = fileType switch
                {
                    1 => ImagePathHelper.ImageType.User,
                    _ => throw new ArgumentException($"Tipo de archivo no válido: {fileType}. Use 1 para Usuario, 2 para Proyecto.")
                };

                var filePath = ImagePathHelper.GetFullImagePath("users", imageType, fileName);

                if (!File.Exists(filePath))
                {
                    return new ResponseDTO
                    {
                        IsSuccess = false,
                        Message = "File not found."
                    };
                }

                byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
                string base64String = Convert.ToBase64String(fileBytes);

                return new ResponseDTO
                {
                    IsSuccess = true,
                    Data = base64String
                };
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> DeleteUser(int userId)
        {
            try
            {
                return await _userRepository.DeleteUser(userId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetListUsers(PaginatorDTO? paginator, GetFilterUsersDTO filters)
        {
            try
            {
                return await _userRepository.GetListUsers(paginator, filters);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetUserById(int userId)
        {
            try
            {
                return await _userRepository.GetUserById(userId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> UpdateUser(UpdateUserDTO user)
        {
            try
            {
                return await _userRepository.UpdateUser(user);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetAllStudents(PaginatorDTO? paginator, GetFilterUsersDTO filters)
        {
            try
            {
                return await _userRepository.GetAllStudents(paginator, filters);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }
    }
}