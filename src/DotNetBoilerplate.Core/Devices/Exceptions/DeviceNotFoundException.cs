using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Devices.Exceptions;

public sealed class DeviceNotFoundException() : CustomException("Device not found.");

