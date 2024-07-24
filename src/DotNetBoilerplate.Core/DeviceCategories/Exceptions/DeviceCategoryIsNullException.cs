using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.DeviceCategories.Exceptions
{
    public sealed class DeviceCategoryIsNullException(Guid Id) : CustomException($"Device category {Id} does not exist") { }
}
