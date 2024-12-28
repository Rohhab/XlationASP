namespace XlationASP.Models
{
    public static class RoleName
    {
        public static readonly string Admin = "Admin";
        public static readonly string Xlator = "Xlator";

        // Static method to return an array of all role names
        public static readonly string[] Roles = { Admin, Xlator };

        //public static string[] GetAllRoles()
        //{
        //    return typeof(RoleName).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
        //        .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
        //        .Select(fi => (string)fi.GetRawConstantValue()!)
        //        .ToArray();
        //}
    }
}