using task.core.DTOs.Authentication;
using task.core.DTOs.Response;
using task.core.DTOs.Users;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;

namespace task.Infrastructure.UseCases.Authentication
{
    public class AuthenticationUseCase(
        IUserRepository userRepository,
        ILogService logService,
        ITokenService tokenService,
        ISecurityService securityService) : IAuthenticationUseCase
    {
        private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        private readonly ILogService _logService = logService ?? throw new ArgumentNullException(nameof(logService));
        private readonly ITokenService _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        private readonly ISecurityService _securityService = securityService ?? throw new ArgumentNullException(nameof(securityService));

        public async Task<ResponseDTO> Authentication(LoginRequestDTO loginRequestDTO)
        {
            var response = new ResponseDTO { IsSuccess = false };

            try
            {

                if (string.IsNullOrWhiteSpace(loginRequestDTO.Email) || string.IsNullOrWhiteSpace(loginRequestDTO.Password))
                {
                    response.Message = "Invalid credentials.";
                    await SimulatePasswordVerificationAsync();
                    return response;
                }

                var normalizedEmail = loginRequestDTO.Email.Trim().ToLowerInvariant();
                var userResponse = await _userRepository.GetUserByEmail(normalizedEmail);

                bool isValidUser = userResponse.IsSuccess && userResponse.Data != null;
                bool isValidPassword = false;
                UserMapDataByIdDTO? user = null;

                if (isValidUser)
                {
                    user = userResponse.Data as UserMapDataByIdDTO;

                    if (user != null)
                    {
                        if (!user.IsActiveUser)
                        {
                            _ = _securityService.VerifyPassword(loginRequestDTO.Password, user.PasswordHashUser, user.PasswordSaltUser);
                            response.Message = "Invalid credentials.";
                            return response;
                        }

                        if (loginRequestDTO.IsStudent)
                        {
                            if (user.SpecialitiesUser != "Estudiante")
                            {
                                _ = _securityService.VerifyPassword(loginRequestDTO.Password, user.PasswordHashUser, user.PasswordSaltUser);
                                response.Message = "Invalid credentials.";
                                return response;
                            }
                        }
                        else
                        {
                            if (user.SpecialitiesUser == "Estudiante")
                            {
                                _ = _securityService.VerifyPassword(loginRequestDTO.Password, user.PasswordHashUser, user.PasswordSaltUser);
                                response.Message = "Invalid credentials.";
                                return response;
                            }
                        }

                        isValidPassword = _securityService.VerifyPassword(
                            loginRequestDTO.Password,
                            user.PasswordHashUser,
                            user.PasswordSaltUser
                        );
                    }
                }
                else
                {
                    await SimulatePasswordVerificationAsync();
                }

                if (isValidPassword && user != null)
                {
                    var tokenResult = await _tokenService.GenerateTokenAsync(user);

                    response.IsSuccess = true;
                    response.Message = "Authentication successful.";
                    response.Data = new
                    {
                        tokenResult.Token,
                        ExpiresIn = 21600,
                        TokenType = "Bearer",
                        User = new
                        {
                            user.UserId,
                            user.NameUser,
                            user.EmailUser,
                            user.IsActiveUser,
                            UserType = user.SpecialitiesUser 
                        }
                    };

                }
                else
                {
                    response.Message = "Invalid credentials.";
                }
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync($"Authentication error for email: {loginRequestDTO.Email}", ex);
                response.Message = "An error occurred during authentication. Please try again later.";
            }

            return response;
        }

        private async Task SimulatePasswordVerificationAsync()
        {
            var dummyPassword = Guid.NewGuid().ToString();
            var dummySalt = Convert.ToBase64String(new byte[16]);
            var dummyHash = Convert.ToBase64String(new byte[32]);

            _ = _securityService.VerifyPassword(dummyPassword, dummyHash, dummySalt);

            await Task.CompletedTask;
        }
    }
}