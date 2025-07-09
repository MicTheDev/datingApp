using System;
using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Extenstions;

public static class AppUserExtensions
{
    public static UserDto ToDto(this AppUser user, ITokenService tokenService)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (tokenService == null) throw new ArgumentNullException(nameof(tokenService));

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            DisplayName = user.DisplayName,
            Token = tokenService.CreateToken(user)
        };
    }
}
