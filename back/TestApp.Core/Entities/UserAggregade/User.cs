using TestApp.Core.Entities.UserAggregade;
using TestApp.Core.Interfaces;

namespace TestApp.Core.Entities;

public class User : BaseEntity, IAggregateRoot
{
    public int Identity { get; private set; }
	public int CountrydId { get; private set; }
	public Country? Country { get; private set; }
	public int ProvinceId { get; private set; }
	public Province? Province { get; private set; }

	private User() { }

    public User(int identity, int countrydId, int provinceId) : this()
    {
        Identity = identity;
        CountrydId = countrydId;
        ProvinceId = provinceId;
    }
}