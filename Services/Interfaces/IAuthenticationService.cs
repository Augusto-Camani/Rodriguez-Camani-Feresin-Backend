﻿namespace Rodriguez_Camani_Feresin_Backend;

public interface IAuthenticationService
{
 BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequestBody);
}
