using EmergencyManagementSystem.SAMU.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class Result<T> : Result where T : class
    {
        public T Model { get; private set; }

        public Result()
        {
            Messages = new List<string>();
        }

        public static new Result<T> BuildError(string message)
            => new Result<T>
            {
                Success = false,
                Messages = new List<string> { message }
            };

        public static new Result<T> BuildError(List<string> messages)
            => new Result<T>
            {
                Success = false,
                Messages = messages
            };

        public static new Result<T> BuildError(string message, Exception error)
            => new Result<T>
            {
                Success = false,
                Messages = new List<string>
                {
                   $"Message: {message}",
                   $"BaseException : {error.GetBaseException().Message}",
                   $"StackTrace: {error.GetBaseException().StackTrace} "
                }
            };

        public static Result<T> BuildSuccess(T model, string message = "", long idGerado = 0)
            => new Result<T>
            {
                Id = idGerado,
                Model = model,
                Success = true,
                Messages = new List<string> { message }
            };
    }
    public class Result
    {
        public bool Success { get; protected set; }
        public List<string> Messages { get; protected set; }
        public long Id { get; set; }

        public static Result BuildError(string message)
            => new Result
            {
                Success = false,
                Messages = new List<string> { message }
            };

        public static Result BuildError(List<string> messages)
            => new Result
            {
                Success = false,
                Messages = messages
            };

        public static Result BuildError(string message, Exception error)
            => new Result
            {
                Success = false,
                Messages = new List<string>
                {
                   $"Message: {message}",
                   $"BaseException : {error.GetBaseException().Message}",
                   $"StackTrace: {error.GetBaseException().StackTrace} "
                }
            };

        public static Result BuildSuccess(string message = "", long idGerado = 0)
            => new Result
            {
                Id = idGerado,
                Success = true,
                Messages = new List<string> { message }
            };
    }
}
