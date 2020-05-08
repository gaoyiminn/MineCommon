using System;

namespace Ruanmou.Libraries.Model
{
    /// <summary>
    /// LM_User
    /// UserModel
    /// </summary>

    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int? CompanyId { get; set; }

    }
}
