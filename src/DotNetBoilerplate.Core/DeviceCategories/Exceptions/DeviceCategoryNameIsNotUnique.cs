using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.DeviceCategories.Exceptions;

internal sealed class DeviceCategoryNameIsNotUnique() : CustomException("Device category is not unique.");
