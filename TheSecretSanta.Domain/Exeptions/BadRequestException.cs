﻿namespace TheSecretSanta.Domain.Exeptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message) { }
}
