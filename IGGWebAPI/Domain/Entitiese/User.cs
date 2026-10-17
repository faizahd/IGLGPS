using System;
using System.Collections.Generic;

namespace IGGWebAPI.Domain.Entitiese;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int CompanyId { get; set; }

    public bool LogIn { get; set; }

    public bool IsActive { get; set; }

    public int GroupId { get; set; }

    public int UserTypeId { get; set; }
}
