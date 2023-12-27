﻿using BarinakAPI.Application.Features.Commands.AppUser.GoogleLogin;
using BarinakAPI.Application.Features.Commands.AppUser.LoginUser;
using BarinakAPI.Application.Features.Commands.AppUser.PasswordReset;
using BarinakAPI.Application.Features.Commands.AppUser.RefreshTokenLogin;
using BarinakAPI.Application.Features.Commands.AppUser.VerifyResetToken;
using MediatR;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarinakAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
            return Ok(response);
        }


        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
        {

            GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
            return Ok(response);
        }
        [HttpPost("password-reset")]
        public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest passwordResetCommandRequest)
        {
            PasswordResetCommandRespons response = await _mediator.Send(passwordResetCommandRequest);
            return Ok(response);
        }
        [HttpPost("verify-reset-token")]
       public async Task<IActionResult> VerifyResetToken([FromQuery]VerifyResetTokenCommandRequest verifyResetTokenCommandRequest)
        {
            VerifyResetTokenCommandResponse response =await _mediator.Send(verifyResetTokenCommandRequest);
            return Ok(response);
        }

    }
}
