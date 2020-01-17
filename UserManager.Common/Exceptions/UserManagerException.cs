using System;

namespace UserManager.Common.Exceptions
{
    public abstract class UserManagerException : Exception
    {
        public string Code { get; set; }

        protected UserManagerException()
        {

        }

        public UserManagerException(string code)
        {
            Code = code;
        }

        public UserManagerException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public UserManagerException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public UserManagerException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public UserManagerException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }

    }
}
