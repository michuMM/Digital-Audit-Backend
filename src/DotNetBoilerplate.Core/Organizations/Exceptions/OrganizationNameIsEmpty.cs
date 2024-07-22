using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Organizations.Exceptions;

public sealed class OrganizationNameIsEmpty() : CustomException("Organization name is empty.");
