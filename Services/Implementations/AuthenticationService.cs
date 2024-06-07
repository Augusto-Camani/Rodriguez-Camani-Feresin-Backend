namespace Rodriguez_Camani_Feresin_Backend;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public AuthenticationService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequest)
    {
        var user = _userRepository.GetUserByName(authenticationRequest.UserName);
        if (user == null)
        {
            return new BaseResponse { Result = false, Message = "wrong username" };
        }

        var isPasswordValid = _passwordHasher.Verify(user.PasswordHash, authenticationRequest.Password);
        if (!isPasswordValid)
        {
            return new BaseResponse { Result = false, Message = "wrong password" };
        }

        return new BaseResponse { Result = true, Message = "success" };
    }
}