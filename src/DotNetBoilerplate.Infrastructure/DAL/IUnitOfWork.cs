﻿namespace DotNetBoilerplate.Infrastructure.DAL;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action);
    Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> action);
}