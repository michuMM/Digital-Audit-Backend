﻿using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Employees.Delete;

public sealed record DeleteEmployeeCommand(Guid id) : ICommand<Guid>;
