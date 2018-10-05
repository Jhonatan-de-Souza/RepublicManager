using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public object Post( [FromBody]Usuario usuario, [FromServices]UserChecker userChecker, [FromServices]SigningConfigurations signingConfigurations, [FromServices]TokenConfigurations tokenConfigurations)
        {
            bool credenciaisValidas = false;
            string nomeUsuario = "";
            
            if (usuario != null)
            {
                var usuarioBase = _unitOfWork.Usuarios.GetByEmail(usuario.Email);
                credenciaisValidas = (usuarioBase != null &&
                    usuario.Email == usuarioBase.Email &&
                    usuario.Senha == usuarioBase.Senha);
                if (usuarioBase == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Não temos cadastro deste usuário no sistema."
                    };
                }
                nomeUsuario = usuarioBase.Nome;
            }

            if (credenciaisValidas)
            {
                //ClaimsIdentity identity = new ClaimsIdentity(
                //    new GenericIdentity(usuario.Email, "Login"),
                //    new[] {
                //        new Claim(ClaimTypes.Name, usuario.Email),
                //        new Claim("Manager","")
                //    }
                //);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, usuario.Email),
                    new Claim("Manager", "")
                };
                ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(usuario.Email, "Login"), claims);

                DateTime creationDate = DateTime.Now;
                DateTime expirationDate = creationDate +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = creationDate,
                    Expires = expirationDate
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = creationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK",
                    nome = nomeUsuario

                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Senha ou Usuário incorreto."
                };
            }
        }
    }
}
