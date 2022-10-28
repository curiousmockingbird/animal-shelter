using Animal_Shelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Animal_Shelter.Repository
{
	public class JWTManagerRepository : IJWTManagerRepository
	{
		Dictionary<string, string> UsersRecords = new Dictionary<string, string>
		{
			{ "Matt","Goofy"},
			{ "Don","Luna"},
			{ "Lisa","password3"},
		};

		private readonly IConfiguration iconfiguration;
		public JWTManagerRepository(IConfiguration iconfiguration)
		{
			this.iconfiguration = iconfiguration;
		}
		public Tokens Authenticate(User user)
		{
			if (!UsersRecords.Any(x => x.Key == user.Name && x.Value == user.Password)) {
				return null;
			}

			// Else we generate JSON Web Token
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
				new Claim(ClaimTypes.Name, user.Name)                    
				}),
				Expires = DateTime.UtcNow.AddMinutes(525600),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new Tokens { Token = tokenHandler.WriteToken(token) };

		}
	}
}