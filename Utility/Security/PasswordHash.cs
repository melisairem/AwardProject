﻿using Microsoft.AspNetCore.Identity;

namespace Utility.Security
{
    public class PasswordHash
    {
        private static readonly PasswordHasher<string> _passwordHasher = new();

        public static string Hash(string password)
        {
            return _passwordHasher.HashPassword(user: "", password);
        }

        public static bool Verify(string hashedPassword, string password)
        {
            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user: "", hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}