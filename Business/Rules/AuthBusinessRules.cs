﻿using Business.Abstract;
using Business.DTOs.Instructors;
using Business.DTOs.Users;
using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concretes;

namespace Business.Rules;

public class AuthBusinessRules : BaseBusinessRules
{
    private readonly IUserService _userService;
    private readonly IEmployeeService _employeeService;
    private readonly IInstructorService _ınstructorService;

    public AuthBusinessRules(IUserService userService, IEmployeeService employeeService, IInstructorService ınstructorService)
    {
        _userService = userService;
        _employeeService = employeeService;
        _ınstructorService = ınstructorService;
    }

    public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
    {
        var userToCheck = await _userService.GetByMail(email);
        if (userToCheck != null) throw new BusinessException(BusinessMessages.UserAlreadyExists);
    }

    public async Task<UserAuth> LoginInformationCheck(UserForLoginRequest userForLoginRequest)
    {
        var userToCheck = await _userService.GetByMail(userForLoginRequest.Email);
        if (userToCheck == null)
        {
            throw new BusinessException(BusinessMessages.UserNotFound);
        }
        if (!HashingHelper.VerifyPasswordHash(userForLoginRequest.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
        {
            throw new BusinessException(BusinessMessages.PasswordError);
        }
        return userToCheck;
    }

    public async Task EmailCanNotBeDuplicatedWhenAdminRegistered(string email)
    {
        var userToCheck = await _employeeService.GetByMail(email);
        if (userToCheck != null) throw new BusinessException(BusinessMessages.UserAlreadyExists);
    }

    public async Task<UserAuth> AdminLoginInformationCheck(UserForLoginRequest userForLoginRequest)
    {
        var userToCheck = await _employeeService.GetByMail(userForLoginRequest.Email);
        if (userToCheck == null)
        {
            throw new BusinessException(BusinessMessages.UserNotFound);
        }
        if (!HashingHelper.VerifyPasswordHash(userForLoginRequest.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
        {
            throw new BusinessException(BusinessMessages.PasswordError);
        }
        return userToCheck;
    }
    
    public async Task EmailCanNotBeDuplicatedWhenInstructorRegistered(string email)
    {
        var userToCheck = await _ınstructorService.GetByMail(email);
        if (userToCheck != null) throw new BusinessException(BusinessMessages.UserAlreadyExists);
    }

    public async Task<UserAuth> InstructorLoginInformationCheck(InstructorForLoginRequest ınstructorForLoginRequest)
    {
        var userToCheck = await _ınstructorService.GetByMail(ınstructorForLoginRequest.Email);
        if (userToCheck == null)
        {
            throw new BusinessException(BusinessMessages.UserNotFound);
        }
        if (!HashingHelper.VerifyPasswordHash(ınstructorForLoginRequest.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
        {
            throw new BusinessException(BusinessMessages.PasswordError);
        }
        return userToCheck;
    }
    public Task ThrowExceptionIfCreateAccessTokenIsNull(AccessToken accessToken)
    {
        if (accessToken == null)
            throw new BusinessException(BusinessMessages.CreateAccessTokenNot);
        return Task.CompletedTask;
    }
}
