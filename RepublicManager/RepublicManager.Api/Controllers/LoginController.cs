using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

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
        public async Task<object> Post([FromBody]Usuario usuario, [FromServices]SigningConfigurations signingConfigurations, [FromServices]TokenConfigurations tokenConfigurations)
        {
            if (usuario != null)
            {
                Usuario usuarioDessaRequisicao = _unitOfWork.Usuarios.GetByEmail(usuario.Email);

                if (usuarioDessaRequisicao == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Não temos cadastro deste usuário no sistema."
                    };
                }

                List<UsuarioRole> permissoesDesteUsuario = _unitOfWork.UsuarioRoles.GetUsuarioWithRolesById(usuarioDessaRequisicao.Id);
                var roles = new List<Role>();
                bool credenciaisValidas = (usuarioDessaRequisicao != null && usuario.Email == usuarioDessaRequisicao.Email && usuario.Senha == usuarioDessaRequisicao.Senha);

                foreach (UsuarioRole usuarioRole in permissoesDesteUsuario)
                {
                    Role role = await _unitOfWork.Roles.GetByIdAsync(usuarioRole.RoleId);
                    roles.Add(role);
                }

                

                if (credenciaisValidas)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, usuario.Email));
                    foreach (Role role in roles)
                    {
                        claims.Add(new Claim("Role", role.RoleName));
                    }

                    ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(usuarioDessaRequisicao.Nome, "Login"), claims);

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
                        nome = usuarioDessaRequisicao.Nome

                    };
                }
                {
                    return new
                    {
                        authenticated = false,
                        message = "Senha ou Usuário incorreto."
                    };
                }
            }

            return new
            {
                authenticated = false,
                message = "Senha ou Usuário incorreto."
            };
        }
    }
}
