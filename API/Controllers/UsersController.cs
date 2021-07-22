using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.AppUsers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.AppUsers.FindAsync(id);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateUser(UserUpdateDto userDto) 
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == userDto.Userid);
            if (user == null) return BadRequest("Not found in context");
            user.Email = userDto.Email;
            user.Status = userDto.Status;
            user.UserRole = userDto.UserRole;
            try 
            {
                _context.AppUsers.Update(user);
                await _context.SaveChangesAsync();
            } 
            catch (Exception e) 
            {
                return BadRequest("Failed to update user: " + e);
            }
            return NoContent();
        }  

        [HttpPut("password")]
        public async Task<ActionResult> UpdatePassword(UserPasswordUpdateDto userPasswordUpdateDto) {
            var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == userPasswordUpdateDto.UserId);
            if (userPasswordUpdateDto == null) return BadRequest("Not found in context");
            
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userPasswordUpdateDto.Password));
            //because passwords are hashed bytes, need to loop through entire length of hashed password to authenticate
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    return Unauthorized("Invalid Password");
            }
            if (userPasswordUpdateDto.PasswordNew != userPasswordUpdateDto.PasswordConfirm) return BadRequest("New passwords should match");

            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userPasswordUpdateDto.PasswordNew));
            user.PasswordSalt = hmac.Key;
            try 
            {
                _context.AppUsers.Update(user);
                await _context.SaveChangesAsync();
            } 
            catch (Exception e) 
            {
                return BadRequest("Failed to change password: " + e);
            }
            return NoContent();
        }
    }
}