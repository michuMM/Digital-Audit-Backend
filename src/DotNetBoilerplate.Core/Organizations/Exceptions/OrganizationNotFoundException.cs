using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Organizations.Exceptions;

public sealed class OrganizationNotFoundException() : CustomException("Organization name is not unique.");

