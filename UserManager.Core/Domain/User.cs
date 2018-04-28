using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace UserManager.Core.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; } 
        public Avatar Avatar { get; protected set; }
        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdateAt { get; protected set; }

        protected User()
        {
        }

        public User(string email, string username, 
            string password, string salt, string role)
        {
            Id = Guid.NewGuid();
            SetUsername(username);
            SetPassword(password, salt);
            SetEmail(email);
            SetRole(role);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username){
            if(!NameRegex.IsMatch(username)){
                throw new Exception("Invalid username.");
            }

            if(String.IsNullOrEmpty(username)){
                throw new Exception("Invalid username.");                
            }

            Username = username.ToLowerInvariant();
            UpdateAt = DateTime.UtcNow;
        }

        public void SetEmail(string email){
           
            try{
                MailAddress mail = new MailAddress(email);
            }catch(FormatException){
                throw new FormatException("Invalid email.");
            }

            if(Email == email){
                return;
            }

            Email = email.ToLowerInvariant();
            UpdateAt = DateTime.UtcNow;
        }

        public void SetRole(string role){
            if(String.IsNullOrWhiteSpace(role)){
                throw new Exception("Invalid role name");
            }

            if(Role == role){
                return;
            }

            Role = role;
            UpdateAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt){
            if(String.IsNullOrWhiteSpace(password)){
                throw new Exception("Invalid password.");
            }
            if(String.IsNullOrWhiteSpace(salt)){
                throw new Exception("Salt cannot be empty.");
            }
            if(password.Length < 4){
                throw new Exception("Password too short");
            }

            if(password.Length > 100){
                throw new Exception("Password cannot contains more than 100 characters.");
            }

            if(Password == password){
                return;
            }
            Password = password;
            Salt = salt;
            UpdateAt = DateTime.UtcNow;
            
        }
    }
}