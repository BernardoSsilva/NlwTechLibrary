﻿namespace TechLibrary.Comunication.Response
{
    public class UserRegisterResponseJson
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string AccessToken { get; set;  } = string.Empty;
    }
}
