using System;

namespace Messenger.Lib.Extentions
{
    public static class InstanceExtentions
    {
        public static void Validate(this Object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException($"Object {nameof(obj)} is null");
            }
        }
    }
}
