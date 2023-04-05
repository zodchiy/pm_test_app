using TestApp.Core.Entities.UserAggregade;
using TestApp.Core.Interfaces;

namespace TestApp.Core.Entities;

public class User : BaseEntity, IAggregateRoot
{
    public string IdentityGuid { get; private set; }
	public int CountrydId { get; private set; }
	public Country? Country { get; private set; }
	public int ProvinceId { get; private set; }
	public Province? Province { get; private set; }

	private User() { }

    public User(string identity) : this()
    {
        IdentityGuid = identity;
    }
}